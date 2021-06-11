// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.MediaId
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

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
