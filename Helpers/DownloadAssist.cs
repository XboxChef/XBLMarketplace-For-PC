// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Helpers.DownloadAssist
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.GenericFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XBLMarketplace_For_PC.SaveAndLoad;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Helpers
{
  public class DownloadAssist
  {
    private int _altTitleId;
    private string _fullDownloadUrl;
    private string _hexTitleId;
    private string _productInstanceId;
    public SaveLoadData FileCache = new SaveLoadData();
    public string Host = "download.xboxlive.com";
    public string Location = "/content";

    public string FullDownloadUrl
    {
      get
      {
        if (this.Offers.Count <= 0 || this.Offers[0].Xcpfilename == null)
          return (string) null;
        if (this._fullDownloadUrl == "http://download.xboxlive.com/content/0/" || this._fullDownloadUrl == null)
          this._fullDownloadUrl = new UriBuilder()
          {
            Scheme = "http",
            Host = this.Host,
            Path = (this.Location + "/" + (this.HexTitleId ?? this.AltTitleId) + "/" + this.Offers[0].Xcpfilename)
          }.ToString();
        return this._fullDownloadUrl;
      }
    }

    public string ProductInstanceId
    {
      get => this._productInstanceId;
      set => this._productInstanceId = value.ToAlphaNumeric();
    }

    public string HexTitleId
    {
      get => this._hexTitleId;
      set => this._hexTitleId = value.Remove(0, 2);
    }

    public string AltTitleId
    {
      get => this._altTitleId.ToString("x");
      set => this._altTitleId = Convert.ToInt32(value);
    }

    [Browsable(false)]
    public List<OfferEntry> Offers
    {
      get => this.FileCache.Offers;
      set => this.FileCache.Offers = value;
    }
  }
}
