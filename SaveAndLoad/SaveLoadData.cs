using System;
using System.Collections.Generic;
using System.IO;
using JasonNS.GenericFunctions;
using Newtonsoft.Json;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.SaveAndLoad
{
    public class SaveLoadData
    {
        //2: add-ons are looked up by their own product id instead of their parent game's
        public const int CurrentVersion = 2;

        private bool _badData=false;
        private bool _dataLoaded;
        //todo:Fix OfferEntry? (Its creating an empty offer instead of using the initialzed one;
        private List<OfferEntry> _offers = new List<OfferEntry>() { new OfferEntry() };

        private string _productId;
        [JsonIgnore] public bool DataLoaded => _dataLoaded && !_badData;

        public int Version { get; set; }

        /// <summary>
        /// Ignore files saved before <see cref="CurrentVersion"/>, set for add-ons whose old entries hold the parent game's link.
        /// </summary>
        [JsonIgnore] public bool DiscardOldVersions { get; set; }

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
            var path = ContentCache.DataDirectory + ProductId.MakeFileSystemSafe().Replace("-", String.Empty) + ".pid";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            Version = CurrentVersion;
            string json = JsonConvert.SerializeObject(this);
            //Written aside and swapped in, closing the app mid write used to leave an empty file behind
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllText(temp, json);
                if (File.Exists(path)) File.Replace(temp, path, null);
                else File.Move(temp, path);
            }
            catch (IOException e)
            {
                //Another check of the same title is writing it, the result is still used from memory
                Console.WriteLine(e.ToString());
                try { File.Delete(temp); } catch (IOException) { }
            }
            //File.WriteAllText(path, json);
            
        }

        public void Load()
        {
            if (ProductId == null) return;
            var path = ContentCache.DataDirectory + ProductId.MakeFileSystemSafe().Replace("-", String.Empty) + ".pid";
            if (!File.Exists(path)) return;
            SaveLoadData loadedData;
            try
            {
                loadedData = JsonConvert.DeserializeObject<SaveLoadData>(File.ReadAllText(path));
            }
            catch (IOException e)
            {
                //Being written by a check right now, treat it as not cached
                Console.WriteLine(e.ToString());
                return;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.ToString());
                loadedData = null;
            }
            if (loadedData?.Offers == null || loadedData.Offers.Count == 0)
            {
                //Empty or damaged, one bad file used to stop the whole page loading. Drop it so the title is checked again
                try { File.Delete(path); } catch (IOException e) { Console.WriteLine(e.ToString()); }
                return;
            }
            if (DiscardOldVersions && loadedData.Version < CurrentVersion) return;
            Version = loadedData.Version;
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