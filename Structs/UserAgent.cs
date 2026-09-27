using System.ComponentModel;

namespace XBLMarketplace_For_PC.Structs
{
    public struct UserAgent
    {
        public string Name { get; set; }

        [Browsable(false)]
        public string Value { get; set; }
    }
}
