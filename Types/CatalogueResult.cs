using System;
using System.Xml.Linq;

namespace XBLMarketplace_For_PC.Types
{
    public enum CatalogueSource
    {
        Network,
        Cache,
        //Network failed, fell back to an expired cached copy
        StaleCache,
        Failed
    }

    public class CatalogueResult
    {
        public CatalogueResult(XDocument page, CatalogueSource source, DateTime savedUtc)
        {
            Page = page;
            Source = source;
            SavedUtc = savedUtc;
        }

        public XDocument Page { get; }
        public CatalogueSource Source { get; }
        public DateTime SavedUtc { get; }
    }
}
