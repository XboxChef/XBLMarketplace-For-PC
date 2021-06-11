using System;
using Newtonsoft.Json;

namespace XBLMarketplace_For_PC.Types
{
    public class OfferEntry
    {
        public string Tier { get; set; }
        public string Price { get; set; }
        public bool IsAcquirable { get; set; }
        public string ContentId { get; set; }

        [JsonIgnore]
        private byte[] ContentIdByteArray
        {
            get
            {
                if(ContentId!=null) return Convert.FromBase64String(ContentId);
                return null;
            }
        }

        [JsonIgnore]
        public string Xcpfilename
        {
            get
            {
                if(ContentId!=null) return BitConverter.ToString(ContentIdByteArray).Replace("-", string.Empty).ToLower() + ".xcp";
                return null;
            }
        }

        public bool Urlchecked { get; set; }

        public string Reason { get; set; } = "Unchecked";

        public string DownloadUrl { get; set; }
    }
}