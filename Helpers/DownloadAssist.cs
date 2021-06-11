using System;
using System.Collections.Generic;
using System.ComponentModel;
using JasonNS.GenericFunctions;
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
        public string Host = Constants.NetworkConnectivity.DlHost;
        public string Location = Constants.NetworkConnectivity.DlLocation;

        public string FullDownloadUrl {
            get {
                if (Offers.Count<=0 || Offers[0].Xcpfilename == null)
                {
                    return null;
                }
                if(_fullDownloadUrl == "http://download.xboxlive.com/content/0/" || _fullDownloadUrl == null)
                    _fullDownloadUrl = new UriBuilder
                    {
                        Scheme = "http",
                        Host = Host,
                        Path = Location + '/' + (HexTitleId ?? AltTitleId) + '/' + Offers[0].Xcpfilename
                    }.ToString();

                return _fullDownloadUrl;
            }
        }

        public string ProductInstanceId
        {
            get { return _productInstanceId; }
            set { _productInstanceId = value.ToAlphaNumeric(); }
        }

        public string HexTitleId
        {
            get
            {
                return _hexTitleId;
            }
            set { _hexTitleId = value.Remove(0, 2); }
        }

        public string AltTitleId {
            get { return _altTitleId.ToString("x"); }
            set { _altTitleId = Convert.ToInt32(value); }
                
        }

        [Browsable(false)]
        public List<OfferEntry> Offers
        {
            get { return FileCache.Offers; }
            set { FileCache.Offers = value; }
        }
    }
}