using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace XBLMarketplace_For_PC.Helpers
{
    /// <summary>
    /// On-disk caches: catalogue query pages, banner images and per-title download checks.
    /// Cache failures are never fatal, a bad or missing entry is treated as a miss.
    /// </summary>
    public static class ContentCache
    {
        public static readonly string CatalogDirectory = Constants.Envpath + "\\CatalogCache\\";
        public static readonly string BannerDirectory = Constants.Envpath + "\\BannerCache\\";
        public static readonly string DataDirectory = Constants.Envpath + "\\DataCache\\";

        private static readonly string[] AllDirectories = { CatalogDirectory, BannerDirectory, DataDirectory };

        /// <summary>
        /// Loads the cached catalogue page for <paramref name="url"/>, and when it was saved.
        /// </summary>
        public static bool TryLoadPage(string url, out XDocument page, out DateTime savedUtc)
        {
            page = null;
            savedUtc = DateTime.MinValue;
            string path = PagePath(url);
            if (!File.Exists(path)) return false;
            try
            {
                savedUtc = File.GetLastWriteTimeUtc(path);
                page = XDocument.Load(path);
                return true;
            }
            catch (Exception e)
            {
                //Corrupt entry, drop it so it is fetched again
                Console.WriteLine(e.ToString());
                TryDelete(path);
                page = null;
                return false;
            }
        }

        public static void SavePage(string url, string xml)
        {
            string path = PagePath(url);
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                Directory.CreateDirectory(CatalogDirectory);
                //Write then swap in, so a crash never leaves a half written page behind
                File.WriteAllText(temp, xml, Encoding.UTF8);
                if (File.Exists(path)) File.Delete(path);
                File.Move(temp, path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                TryDelete(temp);
            }
        }

        public static CacheStats GetStats()
        {
            var stats = new CacheStats();
            foreach (string directory in AllDirectories)
            {
                if (!Directory.Exists(directory)) continue;
                foreach (FileInfo file in new DirectoryInfo(directory).EnumerateFiles())
                {
                    stats.Bytes += file.Length;
                    if (directory == CatalogDirectory) stats.Pages++;
                    else if (directory == BannerDirectory) stats.Banners++;
                    else stats.Titles++;
                }
            }
            return stats;
        }

        /// <summary>
        /// Deletes every cached file. Files that are in use are skipped.
        /// </summary>
        public static void Clear()
        {
            foreach (string directory in AllDirectories.Where(Directory.Exists))
            {
                foreach (string file in Directory.EnumerateFiles(directory).ToList())
                    TryDelete(file);
            }
        }

        private static string PagePath(string url)
        {
            using (SHA1 sha = SHA1.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(url));
                return CatalogDirectory + BitConverter.ToString(hash).Replace("-", string.Empty) + ".xml";
            }
        }

        private static void TryDelete(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public class CacheStats
        {
            public int Pages;
            public int Banners;
            public int Titles;
            public long Bytes;
        }
    }
}
