// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.SaveAndLoad.SaveLoadData
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.GenericFunctions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.SaveAndLoad
{
    public class SaveLoadData
    {
        private readonly bool _badData;
        private bool _dataLoaded;
        private List<OfferEntry> _offers = new List<OfferEntry>()
    {
      new OfferEntry()
    };
        private string _productId;

        [JsonIgnore]
        public bool DataLoaded => _dataLoaded && !_badData;

        public string ProductId
        {
            get => _productId;
            set => _productId = value;
        }

        public List<OfferEntry> Offers
        {
            get => _offers;
            set
            {
                if (value.Count <= 0)
                    return;
                _offers = value;
            }
        }

        [JsonIgnore]
        public bool Urlchecked
        {
            get => Offers[0].Urlchecked;
            set => Offers[0].Urlchecked = value;
        }

        [JsonIgnore]
        public string Reason
        {
            get => Offers[0].Reason;
            set => Offers[0].Reason = value;
        }

        [JsonIgnore]
        public string DownloadUrl
        {
            get => Offers[0].DownloadUrl;
            set => Offers[0].DownloadUrl = value;
        }

        [JsonIgnore]
        public int Offercount => Offers.Count;

        public void Save()
        {
            if (ProductId == null)
                return;
            string path = Constants.Envpath + "\\DataCache\\" + ProductId.MakeFileSystemSafe().Replace("-", string.Empty) + ".pid";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            JsonConvert.SerializeObject(this);
            if (File.Exists(path))
                File.Delete(path);
            using (StreamWriter text = File.CreateText(path))
                new JsonSerializer().Serialize(text, this);
        }

        public void Load()
        {
            if (ProductId == null)
                return;
            string path = Constants.Envpath + "\\DataCache\\" + ProductId.MakeFileSystemSafe().Replace("-", string.Empty) + ".pid";
            try
            {
                if (!File.Exists(path))
                    return;
                SaveLoadData saveLoadData = JsonConvert.DeserializeObject<SaveLoadData>(File.ReadAllText(path));
                if (saveLoadData.Offers.Count > 1)
                    saveLoadData.Offers.RemoveAt(0);
                _productId = saveLoadData._productId;
                Offers = saveLoadData.Offers;
                _dataLoaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
