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
                if (Offers.Count <= 0 || Offers[0].Xcpfilename == null)
                    return null;
                if (_fullDownloadUrl == "http://download.xboxlive.com/content/0/" || _fullDownloadUrl == null)
                    _fullDownloadUrl = new UriBuilder()
                    {
                        Scheme = "http",
                        Host = Host,
                        Path = (Location + "/" + (HexTitleId ?? AltTitleId) + "/" + Offers[0].Xcpfilename)
                    }.ToString();
                return _fullDownloadUrl;
            }
        }

        public string ProductInstanceId
        {
            get => _productInstanceId;
            set => _productInstanceId = value.ToAlphaNumeric();
        }
        /// <summary>
        /// 
        /// </summary>
        public string HexTitleId
        {
            get
            {
                return _hexTitleId;
            }
            set
            {
                string x = value;
                if (x == string.Empty)
                {
                    value = "Error";
                    return;
                }
                else
                {
                    _hexTitleId = value.Remove(0, 2);
                }
            }
        }
        public string AltTitleId
        {
            get => _altTitleId.ToString("x");
            set => _altTitleId = Convert.ToInt32(value);
        }

        [Browsable(false)]
        public List<OfferEntry> Offers
        {
            get => FileCache.Offers;
            set => FileCache.Offers = value;
        }
    }
}
