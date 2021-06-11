// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Structs.RegionId
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

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
