using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
    public class Webhelper
    {
        public const string Host = Constants.NetworkConnectivity.Host;
        public const string Location = Constants.NetworkConnectivity.Location;
        public const string MethodName = Constants.NetworkConnectivity.MethodName;
        //public string MediaTypes { get; set; } = "23";
        private XDocument _xmldoc = new XDocument();
        private int _querySerial;

        public Webhelper()
        {
        }

        public RegionId Locales { get; set; } = new RegionId() {Name = "Default", LegalId = "en-US", Flag = Resources.us};
        public Language Language { get; set; } = new Language() {Id = "Default", Code = "en-US"};
        public string Store { get; set; } = "1";
        public string PageSize { get; set; } = "1";
        public string PageNum { get; set; } = "1";
        public string DetailView { get; set; } = "5";
        public string OfferFilterLevel { get; set; } = "1";
        public string CategoryIDs { get; set; } = "3027";
        public string OrderBy { get; set; } = "1";
        public string OrderDirection { get; set; } = "1";
        public string ImageFormats { get; set; } = "5";
        public string ImageSizes { get; set; } = "15";
        public string UserTypes { get; set; } = "1";
        public MediaId MediaTypes { get; set; } = new MediaId("Default", "23");

        /// <summary>
        /// Cached pages younger than this are used without asking Xbox Live.
        /// Older pages are still used if Xbox Live can't be reached.
        /// </summary>
        public TimeSpan CacheMaxAge { get; set; } = TimeSpan.FromDays(7);

        public XDocument XmlDoc
        {
            get { return _xmldoc; }
            private set
            {
                if (value != _xmldoc)
                {
                    _xmldoc = value;
                    OnxmlDocLoaded(null);
                }
            }
        }

        public event EventHandler XmlDocLoaded;

        protected virtual void OnxmlDocLoaded(EventArgs e)
        {
            if (XmlDocLoaded != null) XmlDocLoaded(this, e);
        }

        /// <summary>
        /// Loads the current page off the UI thread, from cache when possible.
        /// Returns null when a newer query was submitted before this one finished.
        /// </summary>
        public async Task<CatalogueResult> SubmitQueryAsync()
        {
            string url = BuildUrl(PageSize, PageNum, DetailView);
            int serial = ++_querySerial;
            TimeSpan maxAge = CacheMaxAge;

            CatalogueResult result = await Task.Run(() => FetchCatalogue(url, maxAge));
            if (serial != _querySerial) return null;
            if (result.Page != null) XmlDoc = result.Page;
            return result;
        }

        /// <summary>
        /// Makes a page load still in flight be ignored, used when a search replaces the list.
        /// </summary>
        public void CancelPendingQuery() => _querySerial++;

        /// <summary>
        /// A query for the current category, region and language with the given paging and detail,
        /// optionally narrowed to specific items.
        /// </summary>
        internal string BuildUrl(string pageSize, string pageNum, string detailView, IEnumerable<string> mediaIds = null)
        {
            return BuildQueryUrl(Host, Location, MethodName, Language.Code, Locales.LegalId, Store, pageSize, pageNum, detailView,
                OfferFilterLevel, CategoryIDs, OrderBy, OrderDirection, ImageFormats, ImageSizes, UserTypes, MediaTypes.Id, mediaIds);
        }

        internal static CatalogueResult FetchCatalogue(string url, TimeSpan maxAge)
        {
            XDocument cached;
            DateTime savedUtc;
            bool haveCache = ContentCache.TryLoadPage(url, out cached, out savedUtc);
            if (haveCache && DateTime.UtcNow - savedUtc < maxAge)
                return new CatalogueResult(cached, CatalogueSource.Cache, savedUtc);

            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.UserAgent = Constants.NetworkConnectivity.Useragent;
                request.Timeout = 20000;
                request.ReadWriteTimeout = 20000;
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string result;
                using (WebResponse response = request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd().Trim();
                }
                XDocument page = XDocument.Parse(result);
                if (!page.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "totalItems").Any())
                    throw new InvalidDataException("Catalogue response is not a product feed");
                ContentCache.SavePage(url, result);
                return new CatalogueResult(page, CatalogueSource.Network, DateTime.UtcNow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                if (haveCache) return new CatalogueResult(cached, CatalogueSource.StaleCache, savedUtc);
                return new CatalogueResult(null, CatalogueSource.Failed, DateTime.MinValue);
            }
        }

        private static string BuildQueryUrl(
            string host, string location
            , string methodName, string locale, string legalLocale
            , string store, string pageSize, string pageNum 
            , string detailView , string offerFilterLevel , string categoryIDs 
            , string orderBy , string orderDirection , string imageFormats
            , string imageSizes, string userTypes , string mediaTypes
            , IEnumerable<string> mediaIds = null
            ){
            //parse uri
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            #region Parameters
            parameters.Add("methodName", methodName);
            parameters.Add("Names", "Locale");
            parameters.Add("Values", locale);
            parameters.Add("Names", "LegalLocale");
            parameters.Add("Values", legalLocale);
            parameters.Add("Names", "Store");
            parameters.Add("Values", store.ToString());
            parameters.Add("Names", "PageSize");
            parameters.Add("Values", pageSize.ToString());
            parameters.Add("Names", "PageNum");
            parameters.Add("Values", pageNum.ToString());
            parameters.Add("Names", "DetailView");
            parameters.Add("Values", detailView.ToString());
            parameters.Add("Names", "OfferFilterLevel");
            parameters.Add("Values", offerFilterLevel.ToString());
            parameters.Add("Names", "CategoryIDs");
            parameters.Add("Values", categoryIDs.ToString());
            parameters.Add("Names", "OrderBy");
            parameters.Add("Values", orderBy.ToString());
            parameters.Add("Names", "OrderDirection");
            parameters.Add("Values", orderDirection.ToString());
            parameters.Add("Names", "ImageFormats");
            parameters.Add("Values", imageFormats.ToString());
            parameters.Add("Names", "ImageSizes");
            parameters.Add("Values", imageSizes.ToString());
            parameters.Add("Names", "UserTypes");
            parameters.Add("Values", userTypes.ToString());
            parameters.Add("Names", "MediaTypes");
            parameters.Add("Values", mediaTypes.ToString());
            if (mediaIds != null)
            {
                foreach (string id in mediaIds)
                {
                    parameters.Add("Names", "MediaIds");
                    parameters.Add("Values", id);
                }
            }
            #endregion
            #region OldParameters
            /*var parameter0 = HttpUtility.ParseQueryString(string.Empty);var parameter1 = HttpUtility.ParseQueryString(string.Empty);
            var parameter2 = HttpUtility.ParseQueryString(string.Empty);var parameter3 = HttpUtility.ParseQueryString(string.Empty);
            var parameter4 = HttpUtility.ParseQueryString(string.Empty);var parameter5 = HttpUtility.ParseQueryString(string.Empty);
            var parameter6 = HttpUtility.ParseQueryString(string.Empty);var parameter7 = HttpUtility.ParseQueryString(string.Empty);
            var parameter8 = HttpUtility.ParseQueryString(string.Empty);var parameter9 = HttpUtility.ParseQueryString(string.Empty);
            var parameter10 = HttpUtility.ParseQueryString(string.Empty);var parameter11 = HttpUtility.ParseQueryString(string.Empty);
            var parameter12 = HttpUtility.ParseQueryString(string.Empty);var parameter13 = HttpUtility.ParseQueryString(string.Empty);
            var parameter14 = HttpUtility.ParseQueryString(string.Empty);
            parameter0["methodName"] = methodName;parameter1["Names"] = "Locale";parameter1["Values"] = locale;parameter2["Names"] = "LegalLocale";
            parameter2["Values"] = legalLocale;parameter3["Names"] = "Store";parameter3["Values"] = store.ToString();parameter4["Names"] = "PageSize";
            parameter4["Values"] = pageSize.ToString();parameter5["Names"] = "PageNum";parameter5["Values"] = pageNum.ToString();parameter6["Names"] = "DetailView";
            parameter6["Values"] = detailView.ToString();parameter7["Names"] = "OfferFilterLevel";parameter7["Values"] = offerFilterLevel.ToString();
            parameter8["Names"] = "CategoryIDs";parameter8["Values"] = categoryIDs.ToString();parameter9["Names"] = "OrderBy";
            parameter9["Values"] = orderBy.ToString();parameter10["Names"] = "OrderDirection";parameter10["Values"] = orderDirection.ToString();
            parameter11["Names"] = "ImageFormats";parameter11["Values"] = imageFormats.ToString();parameter12["Names"] = "ImageSizes";
            parameter12["Values"] = imageSizes.ToString();parameter13["Names"] = "UserTypes";parameter13["Values"] = userTypes.ToString();
            parameter14["Names"] = "MediaTypes";parameter14["Values"] = mediaTypes.ToString();*/

            /*Query = parameter0+ "&" + parameter1+ "&" + parameter2+ "&" + parameter3+ "&" + parameter4+ "&" 
            + parameter5+ "&" + parameter6+ "&" + parameter7+ "&" + parameter8+ "&" + parameter9+ "&" + parameter10
            + "&" + parameter11+ "&" + parameter12+ "&" + parameter13+ "&" + parameter14*/
            #endregion

            UriBuilder uri = new UriBuilder()
            {
                Scheme = "http",
                Host = host,
                Path = location,
                Query = parameters.ToString()
            };
            return uri.ToString();
        }
    }
}