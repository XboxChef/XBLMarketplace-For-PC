// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Helpers.Webhelper
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
  public class Webhelper
  {
    public const string Useragent = "Xbox Live Client/2.0.15574.0";
    public const string Host = "catalog.xboxlive.com";
    public const string Location = "/Catalog/Catalog.asmx/Query";
    public const string MethodName = "FindGames";
    private XDocument _xmldoc = new XDocument();

    public RegionId Locales { get; set; } = new RegionId()
    {
      Name = "Default",
      LegalId = "en-US",
      Flag = (Image) Resources.us
    };

    public Language Language { get; set; } = new Language()
    {
      Id = "Default",
      Code = "en-US"
    };

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

    public XDocument XmlDoc
    {
      get => this._xmldoc;
      private set
      {
        if (value == this._xmldoc)
          return;
        this._xmldoc = value;
        this.OnxmlDocLoaded((EventArgs) null);
      }
    }

    public event EventHandler XmlDocLoaded;

    protected virtual void OnxmlDocLoaded(EventArgs e)
    {
      if (this.XmlDocLoaded == null)
        return;
      this.XmlDocLoaded((object) this, e);
    }

    public XDocument SubmitQuery()
    {
      this.QueryXboxCatalogue("Xbox Live Client/2.0.15574.0", "catalog.xboxlive.com", "/Catalog/Catalog.asmx/Query", "FindGames", this.Language.Code, this.Locales.LegalId, this.Store, this.PageSize, this.PageNum, this.DetailView, this.OfferFilterLevel, this.CategoryIDs, this.OrderBy, this.OrderDirection, this.ImageFormats, this.ImageSizes, this.UserTypes, this.MediaTypes.Id);
      return this.XmlDoc;
    }

    private XDocument QueryXboxCatalogue(
      string userAgent,
      string host,
      string location,
      string methodName,
      string locale,
      string legalLocale,
      string store,
      string pageSize,
      string pageNum,
      string detailView,
      string offerFilterLevel,
      string categoryIDs,
      string orderBy,
      string orderDirection,
      string imageFormats,
      string imageSizes,
      string userTypes,
      string mediaTypes)
    {
      NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add(nameof (methodName), methodName);
      queryString.Add("Names", "Locale");
      queryString.Add("Values", locale);
      queryString.Add("Names", "LegalLocale");
      queryString.Add("Values", legalLocale);
      queryString.Add("Names", "Store");
      queryString.Add("Values", store.ToString());
      queryString.Add("Names", "PageSize");
      queryString.Add("Values", pageSize.ToString());
      queryString.Add("Names", "PageNum");
      queryString.Add("Values", pageNum.ToString());
      queryString.Add("Names", "DetailView");
      queryString.Add("Values", detailView.ToString());
      queryString.Add("Names", "OfferFilterLevel");
      queryString.Add("Values", offerFilterLevel.ToString());
      queryString.Add("Names", "CategoryIDs");
      queryString.Add("Values", categoryIDs.ToString());
      queryString.Add("Names", "OrderBy");
      queryString.Add("Values", orderBy.ToString());
      queryString.Add("Names", "OrderDirection");
      queryString.Add("Values", orderDirection.ToString());
      queryString.Add("Names", "ImageFormats");
      queryString.Add("Values", imageFormats.ToString());
      queryString.Add("Names", "ImageSizes");
      queryString.Add("Values", imageSizes.ToString());
      queryString.Add("Names", "UserTypes");
      queryString.Add("Values", userTypes.ToString());
      queryString.Add("Names", "MediaTypes");
      queryString.Add("Values", mediaTypes.ToString());
      UriBuilder uriBuilder = new UriBuilder()
      {
        Scheme = "http",
        Host = host,
        Path = location,
        Query = queryString.ToString()
      };
      try
      {
        HttpWebRequest httpWebRequest = WebRequest.Create(uriBuilder.ToString()) as HttpWebRequest;
        httpWebRequest.UserAgent = userAgent;
        this.XmlDoc = XDocument.Parse(new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream()).ReadToEnd().Trim());
        return this.XmlDoc;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        Console.Read();
        return (XDocument) null;
      }
    }
  }
}
