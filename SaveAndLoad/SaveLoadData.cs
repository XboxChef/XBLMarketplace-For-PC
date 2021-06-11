using System;
using System.Collections.Generic;
using System.IO;
using JasonNS.GenericFunctions;
using Newtonsoft.Json;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.SaveAndLoad
{
    public class SaveLoadData
    {
        private bool _badData=false;
        private bool _dataLoaded;
        //todo:Fix OfferEntry? (Its creating an empty offer instead of using the initialzed one;
        private List<OfferEntry> _offers = new List<OfferEntry>() { new OfferEntry() };

        private string _productId;
        [JsonIgnore] public bool DataLoaded => _dataLoaded && !_badData;

        public string ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
            }
        }

        public List<OfferEntry> Offers
        {
            get { return _offers; }
            set { if (value.Count > 0) _offers = value; }
        }

        [JsonIgnore]
        public bool Urlchecked
        {
            get
            {//Todo:Return if Offer is true
                return Offers[0].Urlchecked;
            }
            set
            {
                Offers[0].Urlchecked = value;
            }
        }

        [JsonIgnore]
        public string Reason {
            get
            {
                return Offers[0].Reason;
            }
            set
            {
                Offers[0].Reason = value;
            }
        }

        [JsonIgnore]
        public string DownloadUrl
        {
            get
            {
                return Offers[0].DownloadUrl;
            }
            set
            {
                Offers[0].DownloadUrl = value;
            }
        }

        [JsonIgnore]
        public int Offercount => Offers.Count;

        public void Save()
        {
            //todo:Change Save Method to Single File, Scan Line by line for product ID If Product ID Exists Do nothing Else append to the end of the file
            //todo:Only Save Offers That are Valid
            if (ProductId == null) return;
            var path = Constants.Envpath + "\\DataCache\\" + ProductId.MakeFileSystemSafe().Replace("-", String.Empty) + ".pid";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string json = JsonConvert.SerializeObject(this);
            if (File.Exists(path)) File.Delete(path);
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this);
            }
            //File.WriteAllText(path, json);
            
        }

        public void Load()
        {
            if (ProductId == null) return;
            var path = Constants.Envpath + "\\DataCache\\" + ProductId.MakeFileSystemSafe().Replace("-", String.Empty) + ".pid";
            try
            {
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    SaveLoadData loadedData = JsonConvert.DeserializeObject<SaveLoadData>(json);
                    //todo:Fix the Get/Set Parameters of SaveLoadData So they no longer point to a possible null object
                    if(loadedData.Offers.Count> 1) loadedData.Offers.RemoveAt(0);
                    _productId = loadedData._productId;
                    Offers = loadedData.Offers;
                    /*
                    if (loadedData.Offers.Any(offer => offer.ContentId != null))
                    {
                        Offers = loadedData.Offers.FindAll(offer => offer.ContentId != null);
                        Reason = loadedData.Offers.Find(offer => offer.ContentId != null).Reason;
                    }
                    else if(loadedData.Offers.Any(offer => offer.Reason != "Unchecked"))
                    {
                        Offers = loadedData.Offers.FindAll(offer => offer.Reason != "Unchecked");
                        Reason = loadedData.Offers[0].Reason;
                    }
                    else
                    {
                        Offers = loadedData.Offers;
                        Reason = loadedData.Offers[0].Reason;
                    }
                    */
                    //_urlchecked = loadedData._urlchecked;
                    //_downloadurl = loadedData._downloadurl;
                    _dataLoaded = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        /*
        public void Delete()
        {
            throw new NotImplementedException();
            var path = Constants.envpath + "\\DataCache\\" + GeneralFunctions.MakeFileSystemSafe(productID).Replace("-", String.Empty) + ".pid";
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }*/
    }
}