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
            var firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameTitleMediaId").FirstOrDefault();
            if (firstOrDefault != null) _catalogue = new CatalogueAssist(lang, firstOrDefault.Value.Remove(0,9));

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

            //Required
            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "id").FirstOrDefault();
            if (firstOrDefault == null) throw new NullReferenceException();
            _catalogue.ProductId = firstOrDefault.Value.Substring(9);

            if (node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault()!=null)
                Capabilities = new GameCapabilities(node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault());
        }

        public string CanDownload => _catalogue.Download.FileCache.Reason;
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
            string cacheLocation = Constants.Envpath + "\\BannerCache\\" + Title.MakeFileSystemSafe() + ".banner";
            if(!Directory.Exists(Constants.Envpath + "\\BannerCache\\"))
            {
                Directory.CreateDirectory(Constants.Envpath + "\\BannerCache\\");
            }

            Tokensource = new CancellationTokenSource();
            var tcs = new TaskCompletionSource<Image>();
            if (File.Exists(cacheLocation))
            {
                _thumb = Image.FromFile(cacheLocation);
                tcs.TrySetResult(_thumb);
                return _thumb;
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
            _thumb.Save(cacheLocation, ImageFormat.Jpeg);

            if (Tokensource.IsCancellationRequested)
            {
                Tokensource.Dispose();
                return null;
            }
            Tokensource.Dispose();
            return tcs.Task.Result;
        }

        public void CheckDownloadUrl(bool isCanceled, bool force = false) => _catalogue.CheckDownloadUrl(isCanceled, force);

        public void Load()
        {
            SingleDataCache.Load();
        }
    }
}