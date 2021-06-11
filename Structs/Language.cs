using System.ComponentModel;

namespace XBLMarketplace_For_PC.Structs
{
    public struct Language
    {
        public string Id { get; set; }

        [Browsable(false)]
        public string Code { get; set; }
    }
}