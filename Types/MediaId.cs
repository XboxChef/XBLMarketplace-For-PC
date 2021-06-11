using System.ComponentModel;

namespace XBLMarketplace_For_PC.Types
{
    public class MediaId
    {
        public MediaId(string displayName, string idValue)
        {
            Name = displayName;
            Id = idValue;
        }

        public string Name { get; private set; }

        [Browsable(false)]
        public string Id { get; private set; }

        [Browsable(false)]
        public int TotalCount { get; set; }
    }
}