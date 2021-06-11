// Decompiled with JetBrains decompiler
// Type: XCPpackage.CreditDue
// Assembly: XCPpackage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03ED49D8-B5C4-4BB9-B314-C5A5450AB1F4
// Assembly location: C:\Users\Serenity\Desktop\XCPpackage.dll

using JasonNS;
using JasonNS.Types;
using System.Collections.Generic;

namespace XCPpackage
{
    public static class CreditDue
    {
        public static Credit Jasonmbrown = CodeCredits.JasonNS;
        public static Credit Jester = new Credit()
        {
            Name = nameof(Jester),
            ShortDescription = "Wrote the original c++ Halo Reach Splitter/Extractor."
        };
        public static List<Credit> God2IsoDLLCredits = new List<Credit>()
    {
      CreditDue.Jasonmbrown,
      CreditDue.Jester,
      CodeCredits.Dwack
    };
    }
}
