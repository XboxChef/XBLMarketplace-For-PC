using System.ComponentModel;
using System.Drawing;

namespace XBLMarketplace_For_PC.Structs
{
    public struct RegionId
    {
        public string Name { get; set; }

        [Browsable(false)]
        public Image Flag { get; set; }
  
        [Browsable(false)]
        public string LegalId { get; set; }
    }
}