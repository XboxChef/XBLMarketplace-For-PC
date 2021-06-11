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
        private string _bodytypes = Constants.NetworkConnectivity.Bodytypes;
        private UriBuilder _catalogueUri;
        private string _detailview = Constants.NetworkConnectivity.Detailview;
        private string _offerfilter = Constants.NetworkConnectivity.Offerfilter;
        private string _pagenum = Constants.NetworkConnectivity.Pagenum;
        private string _pagesize = Constants.NetworkConnectivity.Pagesize;
        private NameValueCollection _parameters = HttpUtility.ParseQueryString(string.Empty);
        private string _producttypes = Constants.NetworkConnectivity.Producttypes;
        private string _stores = Constants.NetworkConnectivity.Stores;
        private string _tiers = Constants.NetworkConnectivity.Tiers;
        private string _userAgent = Constants.NetworkConnectivity.Useragent;

        public Language Currentlang;
        public DownloadAssist Download = new DownloadAssist();

        public CatalogueAssist(Language currentlang, string productId)
        {
            this.Currentlang = currentlang;
            Download.FileCache.ProductId = productId;
            _parameters.Add("bodytypes",_bodytypes);
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
                Host = Constants.NetworkConnectivity.CataHost,
                Path = CataLocation,
                Query = _parameters.ToString()
            };
        }

        public string ProductId
        {
            get { return Download.FileCache.ProductId; }
            set { Download.FileCache.ProductId = value; }
        }

        public string CataLocation
        {
            get
            {
                if (ProductId == null) throw new ArgumentNullException(ToString());
                return Constants.NetworkConnectivity.CataLocation + Currentlang.Code + '/' + ProductId;
            }
        }

        /// <summary>
        ///     Returns XMLDoc Containing the ContentID
        /// </summary>
        private XDocument DownloadCatalogueXDoc()
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(_catalogueUri.ToString()) as HttpWebRequest;
                request.UserAgent = _userAgent;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd().Trim();
                sr.Close();
                var xmlDoc = XDocument.Parse(result);
                return xmlDoc;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private TitleIDs ParseproductInstance(XDocument node)
        {
            //<productInstance> is Similiar to <Entry>
            var retIds = new TitleIDs();
            var firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "hexTitleId").FirstOrDefault();
            if (firstOrDefault != null) retIds.HextitleId = firstOrDefault.Value;
            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "productInstanceId").FirstOrDefault();
            if (firstOrDefault != null) retIds.ProductInstanceId = firstOrDefault.Value;
            firstOrDefault = node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "titleId").FirstOrDefault();
            if (firstOrDefault != null) retIds.Alttitleid = firstOrDefault.Value;
            //todo:Change contentId to array and retrieve all Content for product
            XElement previousContentId;
                previousContentId = null;
            foreach (XElement offers in node.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "offerInstance"))
            {
                var contentIdElement = offers.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "contentId").FirstOrDefault();
                if (contentIdElement != null)
                {
                    if (previousContentId?.Value != contentIdElement.Value)
                    {
                        var tierElement = offers.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "tier").FirstOrDefault();
                        var priceElement = offers.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "price").FirstOrDefault();
                        var acquirableElement = offers.Descendants(Constants.NetworkConnectivity.Namespaces.Market + "isAcquirable").FirstOrDefault();
                        //var priceElement = offers.Descendants(Namespaces.Market + "price").FirstOrDefault();

                        retIds.Offers.Add(new OfferEntry
                        {
                            Tier = tierElement?.Value,
                            Price = priceElement?.Value,
                            IsAcquirable = acquirableElement != null && (Convert.ToInt32(acquirableElement.Value) > 0),
                            ContentId = contentIdElement.Value
                        });
                    }
                }
                previousContentId = contentIdElement;
            }
            if (retIds.Offers.Count <= 0)
            {
                retIds.Offers = new List<OfferEntry> {new OfferEntry() {Reason = "NoContentID",Urlchecked = true}};
            }

            return retIds;
        }

        public void InitializeUrl(bool force=false)
        {
            if (!force)
            {
                try
                {
                    Download.FileCache.Load();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
            if(!Download.FileCache.DataLoaded || !Download.FileCache.Urlchecked || force) 
            {TitleIDs tempIDs = ParseproductInstance(DownloadCatalogueXDoc());
                Download.HexTitleId = tempIDs.HextitleId;
                Download.AltTitleId = tempIDs.Alttitleid;
                Download.ProductInstanceId = tempIDs.ProductInstanceId;
                Download.Offers = tempIDs.Offers;
            }
        }

        public void CheckDownloadUrl(bool isCanceled, bool force = false)
        {
            if (Download.FileCache.DataLoaded && !force && Download.FileCache.Urlchecked) return;
            if (isCanceled) return;
            InitializeUrl(force);

            using (ExtendedClient exist = new ExtendedClient {HeadOnly = true})
            {
                try
                {
                    bool fduNull = Download.FullDownloadUrl == null;
                    if (!fduNull) exist.DownloadStringAsync(Download.FullDownloadUrl, isCanceled);
                    Download.FileCache.DownloadUrl = Download.FullDownloadUrl;
                    Download.FileCache.ProductId = ProductId;
                    Download.FileCache.Urlchecked = true;
                    if (!fduNull) Download.FileCache.Reason = "True";
                    Download.FileCache.Save();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Download.FileCache.DownloadUrl = Download.FullDownloadUrl;
                    Download.FileCache.ProductId = ProductId;
                    Download.FileCache.Urlchecked = true;
                    Download.FileCache.Reason = "Invalid";
                    Download.FileCache.Save();
                }
                finally
                {
                    exist.Dispose();
                }
            }
        }
    }
}