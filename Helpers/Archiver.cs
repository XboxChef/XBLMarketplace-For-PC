using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using JasonNS.GenericFunctions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XBLMarketplace_For_PC.Types;
using XCPpackage;

namespace XBLMarketplace_For_PC.Helpers
{
    /// <summary>
    /// Saves marketplace items for preservation exactly as Xbox Live serves them: every package (XCP) byte for byte,
    /// encrypted ones included since they can only be kept as distributed, plus the catalogue and product records,
    /// every public image, and a metadata.json with sizes and SHA-1 hashes. metadata.json is written last, so running
    /// it again skips finished items and resumes partly downloaded packages.
    /// </summary>
    public static class Archiver
    {
        private const int Attempts = 3;
        private const int Buffer = 1 << 20;
        //images\ + "2_" + name + a sniffed extension + .part stays within the room ItemFolder leaves for files
        private const int ImageNameLength = 36;
        private static readonly XNamespace Live = Constants.NetworkConnectivity.Namespaces.Live;
        private static readonly XNamespace Market = Constants.NetworkConnectivity.Namespaces.Market;

        /// <summary>
        /// Archives one item into root\category\title [product id]. Returns false when it was already archived.
        /// Blocking, run it off the UI thread.
        /// </summary>
        public static bool Archive(MarketPlaceContent item, string root, string category, IProgress<ArchiveProgress> progress, CancellationToken token)
        {
            string title = DisplayTitle(item);
            string folder = ItemFolder(root, category, title, item.ProductId);
            string metadataPath = Path.Combine(folder, "metadata.json");
            if (IsComplete(metadataPath))
            {
                progress.Report(new ArchiveProgress(title, "already archived", 0, 0));
                return false;
            }
            Directory.CreateDirectory(folder);

            progress.Report(new ArchiveProgress(title, "catalogue records", 0, 0));
            File.WriteAllText(Path.Combine(folder, "catalog.xml"), item.Entry.ToString(), Encoding.UTF8);
            string productXml = DownloadString(item.ProductUrl, token);
            File.WriteAllText(Path.Combine(folder, "product.xml"), productXml, Encoding.UTF8);
            XDocument product = XDocument.Parse(productXml);

            var images = new JArray();
            List<string> imageUrls = item.Entry.Descendants(Live + "fileUrl").Select(u => u.Value.Trim()).Where(u => u.Length > 0).Distinct().ToList();
            var usedNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            string imageFolder = Path.Combine(folder, "images");
            for (int i = 0; i < imageUrls.Count; i++)
            {
                token.ThrowIfCancellationRequested();
                progress.Report(new ArchiveProgress(title, "image " + (i + 1) + " of " + imageUrls.Count, 0, 0));
                images.Add(ArchiveImage(imageUrls[i], imageFolder, usedNames, token));
            }

            var packages = new JArray();
            bool complete = true;
            List<PackageInfo> packageInfos = ParsePackages(product);
            for (int i = 0; i < packageInfos.Count; i++)
            {
                PackageInfo package = packageInfos[i];
                string stage = "package " + (i + 1) + " of " + packageInfos.Count;
                string file = Path.Combine(folder, package.FileName);
                var record = new JObject
                {
                    ["contentId"] = package.ContentId,
                    ["file"] = package.FileName,
                    ["url"] = package.Url,
                    ["expectedSize"] = package.Size
                };
                try
                {
                    EnsureSpace(folder, package.Size - (File.Exists(file) ? new FileInfo(file).Length : 0), package.FileName);
                    Download(package.Url, file, package.Size, token, done => progress.Report(new ArchiveProgress(title, stage, done, package.Size)));
                    progress.Report(new ArchiveProgress(title, stage + ", hashing", package.Size, package.Size));
                    record["size"] = new FileInfo(file).Length;
                    record["sha1"] = Sha1(file, token);
                    record["format"] = XcpUnpack.DetectFormat(new FileInfo(file)).ToString();
                    record["status"] = "complete";
                }
                catch (WebException e) when (Status(e) == HttpStatusCode.NotFound)
                {
                    //Gone from the CDN, nothing to retry, but the record of what existed is kept
                    record["status"] = "unavailable (HTTP 404)";
                }
                catch (Exception e) when (!token.IsCancellationRequested)
                {
                    record["status"] = "incomplete: " + e.Message;
                    complete = false;
                }
                packages.Add(record);
            }
            token.ThrowIfCancellationRequested();

            var metadata = new JObject
            {
                ["title"] = title,
                ["game"] = item.Entry.Descendants(Live + "gameReducedTitle").FirstOrDefault()?.Value,
                ["category"] = category,
                ["productId"] = item.ProductId,
                ["titleId"] = HexTitleId(product),
                ["developer"] = item.Developer,
                ["publisher"] = item.Publisher,
                ["releaseDate"] = item.Releasedate,
                ["description"] = item.Description,
                ["productUrl"] = item.ProductUrl,
                ["packages"] = packages,
                ["images"] = images,
                ["archivedUtc"] = DateTime.UtcNow,
                ["userAgent"] = Constants.NetworkConnectivity.Useragent,
                ["complete"] = complete
            };
            File.WriteAllText(metadataPath, metadata.ToString(Formatting.Indented), Encoding.UTF8);
            if (!complete) throw new IOException("Some packages didn't finish, archive again to resume");
            return true;
        }

        /// <summary>
        /// One line per item in root\archive.log, so a long run can be reviewed afterwards.
        /// </summary>
        public static void Log(string root, string category, MarketPlaceContent item, string result)
        {
            try
            {
                Directory.CreateDirectory(root);
                File.AppendAllText(Path.Combine(root, "archive.log"),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + category + "\t" + DisplayTitle(item) + "\t" + item.ProductId + "\t" + result + Environment.NewLine,
                    Encoding.UTF8);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //Windows paths stop at 260 characters, so the title is shortened to leave room for the files inside
        //(images\name and the 40 hex digit package names). The product id always stays, it is the identity.
        private static string ItemFolder(string root, string category, string title, string productId)
        {
            const int longestChild = 1 + ImageNameLength + 20;
            string categoryFolder = Path.Combine(Path.GetFullPath(root), Safe(category, 60));
            string suffix = " [" + productId + "]";
            int room = 259 - categoryFolder.Length - 1 - suffix.Length - longestChild;
            if (room < 0) throw new PathTooLongException("The archive path is too long for Windows, choose a shorter Archive Path in Settings");
            string name = Safe(title, Math.Min(80, room));
            return Path.Combine(categoryFolder, name.Length > 0 ? name + suffix : productId);
        }

        private static bool IsComplete(string metadataPath)
        {
            try
            {
                return File.Exists(metadataPath) && (bool?)JObject.Parse(File.ReadAllText(metadataPath))["complete"] == true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private static JObject ArchiveImage(string url, string imageFolder, HashSet<string> usedNames, CancellationToken token)
        {
            var record = new JObject { ["url"] = url };
            try
            {
                Directory.CreateDirectory(imageFolder);
                string name = Safe(Path.GetFileName(new Uri(url).AbsolutePath), ImageNameLength);
                if (name.Length == 0) name = "image";
                string unique = name;
                for (int n = 2; !usedNames.Add(unique); n++) unique = n + "_" + name;
                //Kept from an earlier run, possibly with the extension it was given by its content
                string file = Directory.GetFiles(imageFolder, unique + "*").FirstOrDefault(f =>
                    !f.EndsWith(".part", StringComparison.OrdinalIgnoreCase) &&
                    (Path.GetFileName(f).Equals(unique, StringComparison.OrdinalIgnoreCase) || Path.GetFileNameWithoutExtension(f).Equals(unique, StringComparison.OrdinalIgnoreCase)));
                if (file == null)
                {
                    //Downloaded aside so an interrupted image is never mistaken for a finished one
                    string part = Path.Combine(imageFolder, unique + ".part");
                    Download(url, part, 0, token, null);
                    //Some image urls have no extension, name them by their content
                    file = Path.Combine(imageFolder, Path.GetExtension(unique).Length == 0 ? unique + Sniff(part) : unique);
                    if (File.Exists(file)) File.Delete(file);
                    File.Move(part, file);
                }
                record["file"] = "images/" + Path.GetFileName(file);
                record["size"] = new FileInfo(file).Length;
                record["sha1"] = Sha1(file, token);
            }
            catch (Exception e) when (!token.IsCancellationRequested)
            {
                record["status"] = e is WebException we && Status(we) == HttpStatusCode.NotFound ? "unavailable (HTTP 404)" : "failed: " + e.Message;
            }
            return record;
        }

        private static List<PackageInfo> ParsePackages(XDocument product)
        {
            string hexTitleId = HexTitleId(product);
            var packages = new List<PackageInfo>();
            foreach (XElement instance in product.Descendants(Market + "productInstance"))
            {
                string contentId = instance.Element(Market + "contentId")?.Value;
                if (string.IsNullOrEmpty(contentId) || hexTitleId == null || packages.Any(p => p.ContentId == contentId)) continue;
                long size;
                long.TryParse(instance.Element(Market + "packageSize")?.Value, out size);
                string fileName = BitConverter.ToString(Convert.FromBase64String(contentId)).Replace("-", string.Empty).ToLowerInvariant() + ".xcp";
                packages.Add(new PackageInfo
                {
                    ContentId = contentId,
                    FileName = fileName,
                    Size = size,
                    Url = "http://" + Constants.NetworkConnectivity.DlHost + Constants.NetworkConnectivity.DlLocation + "/" + hexTitleId + "/" + fileName
                });
            }
            return packages;
        }

        private static string HexTitleId(XDocument product)
        {
            string hex = product.Descendants(Market + "hexTitleId").FirstOrDefault()?.Value;
            if (hex != null && hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) return hex.Substring(2);
            int titleId;
            return int.TryParse(product.Descendants(Market + "titleId").FirstOrDefault()?.Value, out titleId) ? titleId.ToString("x8") : hex;
        }

        private static string DownloadString(string url, CancellationToken token)
        {
            for (int attempt = 1; ; attempt++)
            {
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = Constants.NetworkConnectivity.Useragent;
                    request.Timeout = 30000;
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (token.Register(request.Abort))
                    using (WebResponse response = request.GetResponse())
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string text = reader.ReadToEnd();
                        if (XDocument.Parse(text).Root?.Name.LocalName != "feed") throw new InvalidDataException("Xbox Live didn't return a product record");
                        return text;
                    }
                }
                catch (Exception e) when (!token.IsCancellationRequested && attempt < Attempts && e is WebException)
                {
                    Thread.Sleep(2000 * attempt);
                }
            }
        }

        /// <summary>
        /// Downloads to file. With a known expectedSize it resumes from what is already there, 0 means unknown.
        /// </summary>
        private static void Download(string url, string file, long expectedSize, CancellationToken token, Action<long> onProgress)
        {
            for (int attempt = 1; ; attempt++)
            {
                token.ThrowIfCancellationRequested();
                //Only a known size can be resumed safely, anything else starts over
                long have = expectedSize > 0 && File.Exists(file) ? new FileInfo(file).Length : 0;
                if (expectedSize > 0 && have == expectedSize) return;
                if (expectedSize > 0 && have > expectedSize)
                {
                    File.Delete(file);
                    have = 0;
                }
                try
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.UserAgent = Constants.NetworkConnectivity.Useragent;
                    request.Timeout = 30000;
                    request.ReadWriteTimeout = 60000;
                    if (have > 0) request.AddRange(have);
                    using (token.Register(request.Abort))
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        bool resumed = response.StatusCode == HttpStatusCode.PartialContent;
                        if (!resumed) have = 0;
                        using (var output = new FileStream(file, resumed ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.Read, Buffer))
                        using (Stream input = response.GetResponseStream())
                        {
                            var buffer = new byte[Buffer];
                            int read;
                            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                output.Write(buffer, 0, read);
                                have += read;
                                onProgress?.Invoke(have);
                            }
                        }
                    }
                    if (expectedSize <= 0 || have == expectedSize) return;
                    throw new IOException("Download stopped at " + have + " of " + expectedSize + " bytes");
                }
                catch (Exception e) when (!token.IsCancellationRequested && attempt < Attempts && (e is IOException || (e is WebException we && Status(we) != HttpStatusCode.NotFound)))
                {
                    //Keep what arrived and resume from there
                    Thread.Sleep(2000 * attempt);
                }
            }
        }

        private static void EnsureSpace(string folder, long needed, string what)
        {
            if (needed <= 0) return;
            var drive = new DriveInfo(Path.GetPathRoot(Path.GetFullPath(folder)));
            const long margin = 64L << 20;
            if (drive.AvailableFreeSpace < needed + margin)
                throw new IOException("Not enough disk space for " + what + ": needs " + (needed >> 20) + " MB, " + (drive.AvailableFreeSpace >> 20) + " MB free");
        }

        private static string Sha1(string file, CancellationToken token)
        {
            using (SHA1 sha = SHA1.Create())
            using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, Buffer))
            {
                var buffer = new byte[Buffer];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    token.ThrowIfCancellationRequested();
                    sha.TransformBlock(buffer, 0, read, null, 0);
                }
                sha.TransformFinalBlock(new byte[0], 0, 0);
                return BitConverter.ToString(sha.Hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        private static string Sniff(string file)
        {
            var head = new byte[4];
            using (FileStream stream = File.OpenRead(file)) stream.Read(head, 0, head.Length);
            if (head[0] == 0x89 && head[1] == 'P' && head[2] == 'N' && head[3] == 'G') return ".png";
            if (head[0] == 0xFF && head[1] == 0xD8) return ".jpg";
            return ".bin";
        }

        private static HttpStatusCode? Status(WebException e) => (e.Response as HttpWebResponse)?.StatusCode;

        private static string DisplayTitle(MarketPlaceContent item)
        {
            if (!string.IsNullOrWhiteSpace(item.Title)) return item.Title.Trim();
            string game = item.Entry.Descendants(Live + "gameReducedTitle").FirstOrDefault()?.Value;
            return string.IsNullOrWhiteSpace(game) ? "Untitled" : game.Trim();
        }

        //Folder and file names: no characters Windows rejects, and short enough to stay under the path limit
        private static string Safe(string name, int maxLength)
        {
            string safe = name.MakeFileSystemSafe().Trim().TrimEnd('.');
            return safe.Length > maxLength ? safe.Substring(0, maxLength).Trim() : safe;
        }

        private class PackageInfo
        {
            public string ContentId;
            public string FileName;
            public string Url;
            public long Size;
        }
    }

    public class ArchiveProgress
    {
        public ArchiveProgress(string title, string stage, long done, long total)
        {
            Title = title;
            Stage = stage;
            Done = done;
            Total = total;
        }

        public string Title { get; }
        public string Stage { get; }
        public long Done { get; }
        public long Total { get; }
    }
}
