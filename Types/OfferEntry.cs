// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.OfferEntry
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using Newtonsoft.Json;
using System;

namespace XBLMarketplace_For_PC.Types
{
    public class OfferEntry
    {
        public string Tier { get; set; }

        public string Price { get; set; }

        public bool IsAcquirable { get; set; }

        public string ContentId { get; set; }

        [JsonIgnore]
        private byte[] ContentIdByteArray => ContentId != null ? Convert.FromBase64String(ContentId) : null;

        [JsonIgnore]
        public string Xcpfilename => ContentId != null ? BitConverter.ToString(ContentIdByteArray).Replace("-", string.Empty).ToLower() + ".xcp" : null;

        public bool Urlchecked { get; set; }

        public string Reason { get; set; } = "Unchecked";

        public string DownloadUrl { get; set; }
    }
}
