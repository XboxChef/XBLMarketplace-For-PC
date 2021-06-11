// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.MarketPlaceContent
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.GenericFunctions;
using JasonNS.Types;
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

        public MarketPlaceContent(XElement node, Language lang)
          : base()
        {
            XElement xelement1 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameTitleMediaId").FirstOrDefault<XElement>();
            if (xelement1 != null)
                _catalogue = new CatalogueAssist(lang, xelement1.Value.Remove(0, 9));
            XElement xelement2 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "reducedDescription").FirstOrDefault<XElement>() ?? node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "description").FirstOrDefault<XElement>();
            Description = xelement2 == null ? "undefined" : xelement2.Value;
            XElement xelement3 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "titleId").FirstOrDefault<XElement>() ?? node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "effectiveTitleId").FirstOrDefault<XElement>();
            TitleId = xelement3 == null ? "Undefined" : xelement3.Value;
            XElement xelement4 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "publisher").FirstOrDefault<XElement>();
            Publisher = xelement4 == null ? "Undefined" : xelement4.Value;
            XElement xelement5 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "developer").FirstOrDefault<XElement>();
            Developer = xelement5 == null ? "Undefined" : xelement5.Value;
            XElement xelement6 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "releaseDate").FirstOrDefault<XElement>() ?? node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "availabilityDate").FirstOrDefault<XElement>();
            Releasedate = xelement6 == null ? DateTime.MinValue : Convert.ToDateTime(xelement6.Value);
            XElement xelement7 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "reducedTitle").FirstOrDefault<XElement>() ?? node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameReducedTitle").FirstOrDefault<XElement>();
            if (xelement7 != null)
                Title = xelement7.Value;
            else
                Description = "Undefined";
            XElement xelement8 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "fileUrl").FirstOrDefault<XElement>();
            Thumburl = xelement8 == null ? null : xelement8.Value;
            _catalogue.ProductId = (node.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "id").FirstOrDefault<XElement>() ?? throw new NullReferenceException()).Value.Substring(9);
            if (node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault<XElement>() == null)
                return;
            Capabilities = new GameCapabilities(node.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "gameCapabilities").FirstOrDefault<XElement>());
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
            get => _thumb != null ? _thumb : null;
            private set => _thumb = value;
        }

        private SaveLoadData SingleDataCache => _catalogue.Download.FileCache;

        public string OffersCount => _catalogue.Download.FileCache.Offercount != 0 ? Convert.ToString(_catalogue.Download.FileCache.Offercount) : "None";

        public async Task<Image> InitImageAsync(string url)
        {
            MarketPlaceContent marketPlaceContent = this;
            string cacheLocation = Constants.Envpath + "\\BannerCache\\" + marketPlaceContent.Title.MakeFileSystemSafe() + ".banner";
            if (!Directory.Exists(Constants.Envpath + "\\BannerCache\\"))
                Directory.CreateDirectory(Constants.Envpath + "\\BannerCache\\");
            marketPlaceContent.Tokensource = new CancellationTokenSource();
            TaskCompletionSource<Image> tcs = new TaskCompletionSource<Image>();
            if (System.IO.File.Exists(cacheLocation))
            {
                marketPlaceContent._thumb = Image.FromFile(cacheLocation);
                tcs.TrySetResult(marketPlaceContent._thumb);
                return marketPlaceContent._thumb;
            }
            Image webImage = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.UserAgent = "Xbox Live Client/2.0.15574.0";
            httpWebRequest.Method = "GET";
            await Task.Factory.FromAsync<WebResponse>(new Func<AsyncCallback, object, IAsyncResult>(((WebRequest)httpWebRequest).BeginGetResponse), new Func<IAsyncResult, WebResponse>(((WebRequest)httpWebRequest).EndGetResponse), null).ContinueWith(task =>
         {
             HttpWebResponse result = (HttpWebResponse)task.Result;
             Stream stream = result.GetResponseStream();
             if (result.ContentEncoding.ToLower().Contains("gzip"))
                 stream = new GZipStream(stream, CompressionMode.Decompress);
             else if (result.ContentEncoding.ToLower().Contains("deflate"))
                 stream = new DeflateStream(stream, CompressionMode.Decompress);
             if (stream != null)
                 webImage = Image.FromStream(stream);
             tcs.TrySetResult(webImage);
             result?.Dispose();
             stream?.Dispose();
         });
            marketPlaceContent._thumb = tcs.Task.Result;
            marketPlaceContent._thumb.Save(cacheLocation, ImageFormat.Jpeg);
            if (marketPlaceContent.Tokensource.IsCancellationRequested)
            {
                marketPlaceContent.Tokensource.Dispose();
                return null;
            }
            marketPlaceContent.Tokensource.Dispose();
            return tcs.Task.Result;
        }

        public void CheckDownloadUrl(bool isCanceled, bool force = false) => _catalogue.CheckDownloadUrl(isCanceled, force);

        public void Load() => SingleDataCache.Load();
    }
}
