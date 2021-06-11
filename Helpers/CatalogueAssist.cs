// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Helpers.CatalogueAssist
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;
using XBLMarketplace_For_PC.FormComponents;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    public class CatalogueAssist
    {
        private readonly string _bodytypes = "1.3";
        private readonly UriBuilder _catalogueUri;
        private readonly string _detailview = "detaillevel5";
        private readonly string _offerfilter = "1";
        private readonly string _pagenum = "1";
        private readonly string _pagesize = "1";
        private readonly NameValueCollection _parameters = HttpUtility.ParseQueryString(string.Empty);
        private readonly string _producttypes = "1.5.18.19.20.21.22.23.30.34.37.46.47.61";
        private readonly string _stores = "1";
        private readonly string _tiers = "2.3";
        private readonly string _userAgent = "Xbox Live Client/2.0.15574.0";
        public Language Currentlang;
        public DownloadAssist Download = new DownloadAssist();

        public CatalogueAssist(Language currentlang, string productId)
        {
            Currentlang = currentlang;
            Download.FileCache.ProductId = productId;
            _parameters.Add("bodytypes", _bodytypes);
            _parameters.Add("detailview", _detailview);
            _parameters.Add("pagenum", _pagenum);
            _parameters.Add("pagesize", _pagesize);
            _parameters.Add("stores", _stores);
            _parameters.Add("tiers", _tiers);
            _parameters.Add("offerfilter", _offerfilter);
            _parameters.Add("producttypes", _producttypes);
            _catalogueUri = new UriBuilder()
            {
                Scheme = "http",
                Host = "marketplace-xb.xboxlive.com",
                Path = CataLocation,
                Query = _parameters.ToString()
            };
        }

        public string ProductId
        {
            get => Download.FileCache.ProductId;
            set => Download.FileCache.ProductId = value;
        }

        public string CataLocation
        {
            get
            {
                if (ProductId == null)
                    throw new ArgumentNullException(ToString());
                return "/marketplacecatalog/v1/product/" + Currentlang.Code + "/" + ProductId;
            }
        }

        private XDocument DownloadCatalogueXDoc()
        {
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(_catalogueUri.ToString()) as HttpWebRequest;
                httpWebRequest.UserAgent = _userAgent;
                StreamReader streamReader = new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream());
                string text = streamReader.ReadToEnd().Trim();
                streamReader.Close();
                return XDocument.Parse(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private TitleIDs ParseproductInstance(XDocument node)
        {
            TitleIDs titleIds = new TitleIDs();
            XElement xelement1 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "hexTitleId").FirstOrDefault<XElement>();
            if (xelement1 != null)
                titleIds.HextitleId = xelement1.Value;
            XElement xelement2 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "productInstanceId").FirstOrDefault<XElement>();
            if (xelement2 != null)
                titleIds.ProductInstanceId = xelement2.Value;
            XElement xelement3 = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "titleId").FirstOrDefault<XElement>();
            if (xelement3 != null)
                titleIds.Alttitleid = xelement3.Value;
            XElement xelement4 = null;
            foreach (XElement descendant in node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "offerInstance"))
            {
                XElement xelement5 = descendant.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "contentId").FirstOrDefault<XElement>();
                if (xelement5 != null && xelement4?.Value != xelement5.Value)
                {
                    XElement xelement6 = descendant.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "tier").FirstOrDefault<XElement>();
                    XElement xelement7 = descendant.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "price").FirstOrDefault<XElement>();
                    XElement xelement8 = descendant.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "isAcquirable").FirstOrDefault<XElement>();
                    titleIds.Offers.Add(new OfferEntry()
                    {
                        Tier = xelement6?.Value,
                        Price = xelement7?.Value,
                        IsAcquirable = xelement8 != null && Convert.ToInt32(xelement8.Value) > 0,
                        ContentId = xelement5.Value
                    });
                }
                xelement4 = xelement5;
            }
            if (titleIds.Offers.Count <= 0)
                titleIds.Offers = new List<OfferEntry>()
        {
          new OfferEntry()
          {
            Reason = "Unavailable",
           
            Urlchecked = true
          }
        };
            return titleIds;
        }

        public void InitializeUrl(bool force = false)
        {
            if (!force)
            {
                try
                {
                    Download.FileCache.Load();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
            if (((!Download.FileCache.DataLoaded ? 1 : (!Download.FileCache.Urlchecked ? 1 : 0)) | (force ? 1 : 0)) == 0)
                return;
            TitleIDs titleIds = ParseproductInstance(DownloadCatalogueXDoc());
            
            Download.HexTitleId = titleIds.HextitleId;
            Download.AltTitleId = titleIds.Alttitleid;
            Download.ProductInstanceId = titleIds.ProductInstanceId;
            Download.Offers = titleIds.Offers;
        }

        public void CheckDownloadUrl(bool isCanceled, bool force = false)
        {
            if (Download.FileCache.DataLoaded && !force && Download.FileCache.Urlchecked || isCanceled)
                return;
            InitializeUrl(force);
            using (ExtendedClient extendedClient = new ExtendedClient()
            {
                HeadOnly = true
            })
            {
                try
                {
                    int num = Download.FullDownloadUrl == null ? 1 : 0;
                    if (num == 0)
                        extendedClient.DownloadStringAsync(Download.FullDownloadUrl, isCanceled);
                    Download.FileCache.DownloadUrl = Download.FullDownloadUrl;
                    Download.FileCache.ProductId = ProductId;
                    Download.FileCache.Urlchecked = true;
                    if (num == 0)
                        Download.FileCache.Reason = "True";
                    Download.FileCache.Save();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Download.FileCache.DownloadUrl = Download.FullDownloadUrl;
                    Download.FileCache.ProductId = ProductId;
                    Download.FileCache.Urlchecked = true;
                    Download.FileCache.Reason = "Invalid";
                    Download.FileCache.Save();
                }
                finally
                {
                    extendedClient.Dispose();
                }
            }
        }
    }
}
