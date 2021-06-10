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
    private string _bodytypes = "1.3";
    private UriBuilder _catalogueUri;
    private string _detailview = "detaillevel5";
    private string _offerfilter = "1";
    private string _pagenum = "1";
    private string _pagesize = "1";
    private NameValueCollection _parameters = HttpUtility.ParseQueryString(string.Empty);
    private string _producttypes = "1.5.18.19.20.21.22.23.30.34.37.46.47.61";
    private string _stores = "1";
    private string _tiers = "2.3";
    private string _userAgent = "Xbox Live Client/2.0.15574.0";
    public Language Currentlang;
    public DownloadAssist Download = new DownloadAssist();

    public CatalogueAssist(Language currentlang, string productId)
    {
      this.Currentlang = currentlang;
      this.Download.FileCache.ProductId = productId;
      this._parameters.Add("bodytypes", this._bodytypes);
      this._parameters.Add("detailview", this._detailview);
      this._parameters.Add("pagenum", this._pagenum);
      this._parameters.Add("pagesize", this._pagesize);
      this._parameters.Add("stores", this._stores);
      this._parameters.Add("tiers", this._tiers);
      this._parameters.Add("offerfilter", this._offerfilter);
      this._parameters.Add("producttypes", this._producttypes);
      this._catalogueUri = new UriBuilder()
      {
        Scheme = "http",
        Host = "marketplace-xb.xboxlive.com",
        Path = this.CataLocation,
        Query = this._parameters.ToString()
      };
    }

    public string ProductId
    {
      get => this.Download.FileCache.ProductId;
      set => this.Download.FileCache.ProductId = value;
    }

    public string CataLocation
    {
      get
      {
        if (this.ProductId == null)
          throw new ArgumentNullException(this.ToString());
        return "/marketplacecatalog/v1/product/" + this.Currentlang.Code + "/" + this.ProductId;
      }
    }

    private XDocument DownloadCatalogueXDoc()
    {
      try
      {
        HttpWebRequest httpWebRequest = WebRequest.Create(this._catalogueUri.ToString()) as HttpWebRequest;
        httpWebRequest.UserAgent = this._userAgent;
        StreamReader streamReader = new StreamReader((httpWebRequest.GetResponse() as HttpWebResponse).GetResponseStream());
        string text = streamReader.ReadToEnd().Trim();
        streamReader.Close();
        return XDocument.Parse(text);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
        return (XDocument) null;
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
      XElement xelement4 = (XElement) null;
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
            Reason = "NoContentID",
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
          this.Download.FileCache.Load();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
          throw;
        }
      }
      if (((!this.Download.FileCache.DataLoaded ? 1 : (!this.Download.FileCache.Urlchecked ? 1 : 0)) | (force ? 1 : 0)) == 0)
        return;
      TitleIDs titleIds = this.ParseproductInstance(this.DownloadCatalogueXDoc());
      this.Download.HexTitleId = titleIds.HextitleId;
      this.Download.AltTitleId = titleIds.Alttitleid;
      this.Download.ProductInstanceId = titleIds.ProductInstanceId;
      this.Download.Offers = titleIds.Offers;
    }

    public void CheckDownloadUrl(bool isCanceled, bool force = false)
    {
      if (this.Download.FileCache.DataLoaded && !force && this.Download.FileCache.Urlchecked || isCanceled)
        return;
      this.InitializeUrl(force);
      using (ExtendedClient extendedClient = new ExtendedClient()
      {
        HeadOnly = true
      })
      {
        try
        {
          int num = this.Download.FullDownloadUrl == null ? 1 : 0;
          if (num == 0)
            extendedClient.DownloadStringAsync(this.Download.FullDownloadUrl, isCanceled);
          this.Download.FileCache.DownloadUrl = this.Download.FullDownloadUrl;
          this.Download.FileCache.ProductId = this.ProductId;
          this.Download.FileCache.Urlchecked = true;
          if (num == 0)
            this.Download.FileCache.Reason = "True";
          this.Download.FileCache.Save();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
          this.Download.FileCache.DownloadUrl = this.Download.FullDownloadUrl;
          this.Download.FileCache.ProductId = this.ProductId;
          this.Download.FileCache.Urlchecked = true;
          this.Download.FileCache.Reason = "Invalid";
          this.Download.FileCache.Save();
        }
        finally
        {
          extendedClient.Dispose();
        }
      }
    }
  }
}
