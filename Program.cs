// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Program
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.Windows.Forms;

namespace XBLMarketplace_For_PC
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XBLMarketplace_For_PC.Forms.Main());
        }
    }
}
