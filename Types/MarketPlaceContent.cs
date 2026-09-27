using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using JasonNS.GenericFunctions;
using JasonNS.Types;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.SaveAndLoad;
using XBLMarketplace_For_PC.Structs;

namespace XBLMarketplace_For_PC.Types
{
    public class MarketPlaceContent : PackageBase
    {
        private readonly CatalogueAssist _catalogue;
        public readonly GameCapabilities Capabilities;
        public readonly string Thumburl;
        private Image _thumb;

        public CancellationTokenSource Tokensource;

        public MarketPlaceContent(XElement node,Language lang)
        {
            Entry = node;
            //Required
            var firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "id").FirstOrDefault();
            if (firstOrDefault == null) throw new NullReferenceException();
            _catalogue = new CatalogueAssist(lang, firstOrDefault.Value.Substring(9));

            //Add-ons (DLC, themes, etc.) point at their parent game, games point at themselves
            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameTitleMediaId").FirstOrDefault();
            if (firstOrDefault != null && !string.Equals(firstOrDefault.Value.Substring(9), _catalogue.ProductId, StringComparison.OrdinalIgnoreCase))
                _catalogue.Download.FileCache.DiscardOldVersions = true;

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "reducedDescription").FirstOrDefault();
            if (firstOrDefault == null) firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "description").FirstOrDefault();
            if (firstOrDefault != null) Description = firstOrDefault.Value;
            else Description = "undefined";

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "titleId").FirstOrDefault();
            if (firstOrDefault == null) firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "effectiveTitleId").FirstOrDefault();
            if (firstOrDefault != null) TitleId = firstOrDefault.Value;
            else TitleId = "Undefined";

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "publisher").FirstOrDefault();
            if (firstOrDefault != null) Publisher = firstOrDefault.Value;
            else Publisher = "Undefined";

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "developer").FirstOrDefault();
            if (firstOrDefault != null) Developer = firstOrDefault.Value;
            else Developer = "Undefined";

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "releaseDate").FirstOrDefault();
            if (firstOrDefault == null) firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "availabilityDate").FirstOrDefault();
            if (firstOrDefault != null) Releasedate = Convert.ToDateTime(firstOrDefault.Value);
            else Releasedate = DateTime.MinValue;

            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "reducedTitle").FirstOrDefault();
            if (firstOrDefault == null) firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameReducedTitle").FirstOrDefault();
            if (firstOrDefault != null) Title = firstOrDefault.Value;
            else Description = "Undefined";
            
            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "fileUrl").FirstOrDefault();
            if (firstOrDefault != null) Thumburl = firstOrDefault.Value;
            else Thumburl = null;

            if (node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault()!=null)
                Capabilities = new GameCapabilities(node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault());
        }

        /// <summary>
        /// The catalogue entry this item was built from, kept for archiving.
        /// </summary>
        public XElement Entry { get; }

        public string ProductId => _catalogue.ProductId;

        /// <summary>
        /// The product record listing this item's packages (content ids, sizes, title id).
        /// </summary>
        public string ProductUrl => _catalogue.CatalogueUrl;

        /// <summary>
        /// Shown in place of the cached result while a check runs or after it failed. Never saved.
        /// </summary>
        public string CheckStatus { get; set; }

        public string CanDownload => CheckStatus ?? _catalogue.Download.FileCache.Reason;
        public bool DownloadChecked => _catalogue.Download.FileCache.Urlchecked;
        public string DownloadUrl => _catalogue.Download.FileCache.DownloadUrl;
        public string Description { get; private set; }
        public string TitleId { get; private set; }
        public string Publisher { get; private set; }
        public string Developer { get; private set; }
        public DateTime Releasedate { get; private set; }

        public Image Thumb
        {
            get 
            {
                if (_thumb != null)
                {
                    return _thumb;
                    //If Image Already Downloaded
                }
                else
                {
                    return null;
                }
            }
            private set { _thumb = value; }
        }

        private SaveLoadData SingleDataCache => _catalogue.Download.FileCache;

        public string OffersCount
        {
            get
            {
                return _catalogue.Download.FileCache.Offercount == 0 ? "None" : Convert.ToString(_catalogue.Download.FileCache.Offercount);
            }
        }


        public async Task<Image> InitImageAsync(string url)
        {
            string cacheLocation = ContentCache.BannerDirectory + Title.MakeFileSystemSafe() + ".banner";
            if(!Directory.Exists(ContentCache.BannerDirectory))
            {
                Directory.CreateDirectory(ContentCache.BannerDirectory);
            }

            Tokensource = new CancellationTokenSource();
            var tcs = new TaskCompletionSource<Image>();
            if (File.Exists(cacheLocation))
            {
                try
                {
                    _thumb = LoadCachedImage(cacheLocation);
                    tcs.TrySetResult(_thumb);
                    return _thumb;
                }
                catch (Exception e)
                {
                    //Unreadable banner, fetch it again below
                    Console.WriteLine(e.ToString());
                    File.Delete(cacheLocation);
                }
            }
            Image webImage = null;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.UserAgent = Constants.NetworkConnectivity.Useragent;
            request.Method = "GET";
            await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse,null)
                .ContinueWith(task =>
                {
                    var webResponse = (HttpWebResponse) task.Result;
                    Stream responseStream = webResponse.GetResponseStream();
                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                    if (responseStream != null) webImage = Image.FromStream(responseStream);
                    tcs.TrySetResult(webImage);
                    webResponse?.Dispose();
                    responseStream?.Dispose();
                });
            _thumb = tcs.Task.Result;
            _thumb?.Save(cacheLocation, ImageFormat.Jpeg);

            if (Tokensource.IsCancellationRequested)
            {
                Tokensource.Dispose();
                return null;
            }
            Tokensource.Dispose();
            return tcs.Task.Result;
        }

        //Image.FromFile keeps the file locked until disposed, which blocks clearing the cache
        private static Image LoadCachedImage(string path)
        {
            using (var stream = new MemoryStream(File.ReadAllBytes(path)))
            using (var image = Image.FromStream(stream))
            {
                return new Bitmap(image);
            }
        }

        public void CheckDownloadUrl(bool isCanceled, bool force = false) => _catalogue.CheckDownloadUrl(isCanceled, force);

        public void Load()
        {
            SingleDataCache.Load();
        }
    }
}