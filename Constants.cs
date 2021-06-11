// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Constants
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.Types;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC
{
    public static class Constants
    {
        public static string Envpath = Environment.CurrentDirectory;
        public const string Debug = "R";
        public const string Iteration = "1";
        public const string Majorversion = "8";
        public const string Minorversion = "1";
        public static List<Credit> Credits = new List<Credit>()
    {
      JasonNS.CodeCredits.JasonNS,
      JasonNS.CodeCredits.Dwack,
      God2Iso.CodeCredits.God2Iso
    };

        public static class NetworkConnectivity
        {
            public const string Useragent = "Xbox Live Client/2.0.15574.0";
            public const string Host = "catalog.xboxlive.com";
            public const string Location = "/Catalog/Catalog.asmx/Query";
            public const string MethodName = "FindGames";
            public const string CataHost = "marketplace-xb.xboxlive.com";
            public const string CataLocation = "/marketplacecatalog/v1/product/";
            public const string DlHost = "download.xboxlive.com";
            public const string DlLocation = "/content";
            public const string Bodytypes = "1.3";
            private const string Detaillevel = "5";
            public const string Detailview = "detaillevel5";
            public const string Pagenum = "1";
            public const string Pagesize = "1";
            public const string Stores = "1";
            public const string Tiers = "2.3";
            public const string Offerfilter = "1";
            public const string Producttypes = "1.5.18.19.20.21.22.23.30.34.37.46.47.61";
            private const string LiveNameSpace = "http://www.live.com/marketplace";
            private const string AtomNameSpace = "http://www.w3.org/2005/Atom";
            private const string MarketNameSpace = "http://marketplace.xboxlive.com/resource/product/v1";

            public static class Namespaces
            {
                internal static readonly XNamespace Live = "http://www.live.com/marketplace";
                internal static readonly XNamespace Atom = "http://www.w3.org/2005/Atom";
                internal static readonly XNamespace Market = "http://marketplace.xboxlive.com/resource/product/v1";
            }
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct RegionIDs
        {
            internal static RegionId _northAmerica = new RegionId()
            {
                Name = "North America",
                LegalId = "en-US",
                Flag = Resources.us
            };
            internal static RegionId _germany = new RegionId()
            {
                Name = "Germany",
                LegalId = "de-DE",
                Flag = Resources.de
            };
            internal static RegionId _spain = new RegionId()
            {
                Name = "Spain",
                LegalId = "es-ES",
                Flag = Resources.es
            };
            internal static RegionId _france = new RegionId()
            {
                Name = "France",
                LegalId = "fr-FR",
                Flag = Resources.fr
            };
            internal static RegionId _greece = new RegionId()
            {
                Name = "Greece",
                LegalId = "gr-GR",
                Flag = Resources.gr
            };
            internal static RegionId _italy = new RegionId()
            {
                Name = "Italy",
                LegalId = "it-IT",
                Flag = Resources.it
            };
            internal static RegionId _japan = new RegionId()
            {
                Name = "Japan",
                LegalId = "jp-JP",
                Flag = Resources.jp
            };
            internal static RegionId _korea = new RegionId()
            {
                Name = "Korea",
                LegalId = "ko-KR",
                Flag = Resources.kr
            };
            internal static RegionId _poland = new RegionId()
            {
                Name = "Poland",
                LegalId = "pl-PL",
                Flag = Resources.pl
            };
            internal static RegionId _netherlands = new RegionId()
            {
                Name = "Netherlands",
                LegalId = "nl-NL",
                Flag = Resources.nl
            };
            internal static RegionId _portugal = new RegionId()
            {
                Name = "Portugal",
                LegalId = "pt-PT",
                Flag = Resources.pt
            };
            internal static RegionId _russia = new RegionId()
            {
                Name = "Russia",
                LegalId = "ru-RU",
                Flag = Resources.ru
            };
            internal static RegionId _sweden = new RegionId()
            {
                Name = "Sweden",
                LegalId = "sv-SE",
                Flag = Resources.se
            };
            internal static RegionId _turkey = new RegionId()
            {
                Name = "Turkey",
                LegalId = "tr-TR",
                Flag = Resources.tr
            };
            internal static RegionId _unitedArabEmirates = new RegionId()
            {
                Name = "United Arab Emirates",
                LegalId = "ar-AE",
                Flag = Resources.ae
            };
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct CategoryIDs
        {
            internal static MediaId _arcade = new MediaId("Arcade", "23");
            internal static MediaId _arcadeDemo = new MediaId("Arcade Demo's", "5");
            internal static MediaId _avatarItems = new MediaId("Avatar Items", "47");
            internal static MediaId _dlc1 = new MediaId("Downloadable Content 1", "18");
            internal static MediaId _dlc2 = new MediaId("Downloadable Content 2", "24");
            internal static MediaId _gameDemo = new MediaId("Full Game Demos", "19");
            internal static MediaId _trailer = new MediaId("Game Trailers", "34");
            internal static MediaId _indie = new MediaId("Indie Games", "37");
            internal static MediaId _theme = new MediaId("Themes", "20");
            internal static MediaId _video = new MediaId("Videos", "30");
            internal static MediaId _x360God = new MediaId("360 Games On Demand", "1");
            internal static MediaId _xgod = new MediaId("Xbox Games On Demand", "21");
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct QueryLanguage
        {
            internal static readonly Language Polish = new Language()
            {
                Id = nameof(Polish),
                Code = "pl-PL"
            };
            internal static readonly Language Portuguese = new Language()
            {
                Id = nameof(Portuguese),
                Code = "pt-PT"
            };
            internal static readonly Language Russian = new Language()
            {
                Id = nameof(Russian),
                Code = "ru-RU"
            };
            internal static readonly Language Arabic = new Language()
            {
                Id = nameof(Arabic),
                Code = "ar-SA"
            };
            internal static readonly Language Arabic_UAE = new Language()
            {
                Id = nameof(Arabic_UAE),
                Code = "ar-AE"
            };
            internal static readonly Language German_Switzerland = new Language()
            {
                Id = nameof(German_Switzerland),
                Code = "de-CH"
            };
            internal static readonly Language English_SG = new Language()
            {
                Id = nameof(English_SG),
                Code = "en-SG"
            };
            internal static readonly Language Slovak = new Language()
            {
                Id = nameof(Slovak),
                Code = "sk-SK"
            };
            internal static readonly Language English_SA = new Language()
            {
                Id = nameof(English_SA),
                Code = "en-ZA"
            };
            internal static readonly Language French_Switzerland = new Language()
            {
                Id = nameof(French_Switzerland),
                Code = "fr-CH"
            };
            internal static readonly Language Finnish = new Language()
            {
                Id = nameof(Finnish),
                Code = "fi-FI"
            };
            internal static readonly Language Swedish = new Language()
            {
                Id = nameof(Swedish),
                Code = "sv-SE"
            };
            internal static readonly Language Taiwanese = new Language()
            {
                Id = nameof(Taiwanese),
                Code = "zh-TW"
            };
            internal static readonly Language Turkish = new Language()
            {
                Id = nameof(Turkish),
                Code = "tr-TR"
            };

            internal static readonly Language English_UK = new Language()
            {
                Id = nameof(English_UK),
                Code = "en-GB"
            };
            internal static readonly Language English = new Language()
            {
                Id = nameof(English),
                Code = "en-US"
            };
            internal static readonly Language Argentina = new Language()
            {
                Id = nameof(Argentina),
                Code = "es-AR"
            };

            internal static readonly Language English_AU = new Language()
            {
                Id = nameof(English_AU),
                Code = "en-AU"
            };

            internal static readonly Language België = new Language()
            {
                Id = nameof(België),
                Code = "nl-BE"
            };

            internal static readonly Language Belgique = new Language()
            {
                Id = nameof(Belgique),
                Code = "fr-BE"
            };

            internal static readonly Language Brasilian = new Language()
            {
                Id = nameof(Brasilian),
                Code = "pt-BR"
            };

            internal static readonly Language English_CA = new Language()
            {
                Id = nameof(English_CA),
                Code = "en-CA"
            };

            internal static readonly Language French_CA = new Language()
            {
                Id = nameof(French_CA),
                Code = "fr-CA"
            };

            internal static readonly Language Czech = new Language()
            {
                Id = nameof(Czech),
                Code = "cs-CZ"
            };

            internal static readonly Language Chilean = new Language()
            {
                Id = nameof(Chilean),
                Code = "es-CL"
            };

            internal static readonly Language Chinese = new Language()
            {
                Id = nameof(Chinese),
                Code = "zh-CN"
            };

            internal static readonly Language Colombian = new Language()
            {
                Id = nameof(Colombian),
                Code = "es-CO"
            };

            internal static readonly Language Dutch = new Language()
            {
                Id = nameof(Dutch),
                Code = "da-DK"
            };

            internal static readonly Language German = new Language()
            {
                Id = nameof(German),
                Code = "de-DE"
            };

            static readonly Language Spanish_ES = new Language()
            {
                Id = nameof(Spanish_ES),//España
                Code = "es-ES"
            };

            internal static readonly Language Greek = new Language()
            {
                Id = nameof(Greek),
                Code = "el-GR"
            };

            internal static readonly Language French = new Language()
            {
                Id = nameof(French),
                Code = "fr-FR"
            };

            internal static readonly Language Chinese_HK = new Language()
            {
                Id = nameof(Chinese_HK),
                Code = "zh-HK"
            };

            internal static readonly Language English_HK = new Language()
            {
                Id = nameof(English_HK),
                Code = "en-HK"
            };

            internal static readonly Language Indian = new Language()
            {
                Id = nameof(Indian),
                Code = "en-IN"
            };
            internal static readonly Language Irish = new Language()
            {
                Id = nameof(Irish),
                Code = "en-IE"
            };

            internal static readonly Language Israeli = new Language()
            {
                Id = nameof(Israeli),
                Code = "he-IL"
            };

            internal static readonly Language Italian = new Language()
            {
                Id = nameof(Italian),
                Code = "it-IT"
            };

            internal static readonly Language Japanese = new Language()
            {
                Id = nameof(Japanese),
                Code = "ja-JP"
            };

            internal static readonly Language Korean = new Language()
            {
                Id = nameof(Korean),
                Code = "ko-KR"
            };

            internal static readonly Language Magyarország = new Language()
            {
                Id = nameof(Magyarország),
                Code = "hu-HU"
            };

            internal static readonly Language Spanish_MX = new Language()
            {
                Id = nameof(Spanish_MX),
                Code = "es-MX"
            };

            internal static readonly Language Nederland = new Language()
            {
                Id = nameof(Nederland),
                Code = "nl-NL"
            };

            internal static readonly Language New_Zealand = new Language()
            {
                Id = nameof(New_Zealand),
                Code = "en-NZ"
            };

            internal static readonly Language Norge = new Language()
            {
                Id = nameof(Norge),
                Code = "nb-NO"
            };

            internal static readonly Language Österreich = new Language()
            {
                Id = nameof(Österreich),
                Code = "de-AT"
            };

        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct BindingLists
        {
            public static List<Language> Languages = new List<Language>()
      {
QueryLanguage.Arabic,
QueryLanguage.Arabic_UAE,
QueryLanguage.Argentina,
QueryLanguage.Belgique,
QueryLanguage.België,
QueryLanguage.Brasilian,
QueryLanguage.Chilean,
QueryLanguage.Chinese,
QueryLanguage.Chinese_HK,
QueryLanguage.Colombian,
QueryLanguage.Czech,
QueryLanguage.Dutch,
QueryLanguage.English_AU,
QueryLanguage.English_CA,
QueryLanguage.English_HK,
QueryLanguage.English_SG,
QueryLanguage.English_SA,
QueryLanguage.English_UK,
QueryLanguage.English,
QueryLanguage.Finnish,
QueryLanguage.French,
QueryLanguage.French_CA,
QueryLanguage.French_Switzerland,
QueryLanguage.German,
QueryLanguage.German_Switzerland,
QueryLanguage.Greek,
QueryLanguage.Indian,
QueryLanguage.Irish,
QueryLanguage.Israeli,
QueryLanguage.Italian,
QueryLanguage.Japanese,
QueryLanguage.Korean,
QueryLanguage.Magyarország,
QueryLanguage.Nederland,
QueryLanguage.New_Zealand,
QueryLanguage.Norge,
QueryLanguage.Polish,
QueryLanguage.Portuguese,
QueryLanguage.Russian,
QueryLanguage.Slovak,
QueryLanguage.Spanish_MX,
QueryLanguage.Swedish,
QueryLanguage.Taiwanese,
QueryLanguage.Turkish,
QueryLanguage.Österreich,
      };
            public static BindingSource RegionBindingSource = new BindingSource()
      {
         Regions
      };
            public static BindingSource CategoryBindingSource = new BindingSource()
      {
         Categorys
      };
            public static BindingSource UserAgentBindingSource = new BindingSource()
      {
         UserAgents
      };

            public static List<RegionId> Regions { get; private set; } = new List<RegionId>()
      {
        Constants.RegionIDs._northAmerica,
        Constants.RegionIDs._germany,
        Constants.RegionIDs._spain,
        Constants.RegionIDs._france,
        Constants.RegionIDs._greece,
        Constants.RegionIDs._italy,
        Constants.RegionIDs._japan,
        Constants.RegionIDs._korea,
        Constants.RegionIDs._poland,
        Constants.RegionIDs._netherlands,
        Constants.RegionIDs._portugal,
        Constants.RegionIDs._russia,
        Constants.RegionIDs._sweden,
        Constants.RegionIDs._turkey,
        Constants.RegionIDs._unitedArabEmirates
      };

            public static List<MediaId> Categorys { get; private set; } = new List<MediaId>()
      {
        Constants.CategoryIDs._arcade,
        Constants.CategoryIDs._arcadeDemo,
        Constants.CategoryIDs._avatarItems,
        Constants.CategoryIDs._dlc1,
        Constants.CategoryIDs._dlc2,
        Constants.CategoryIDs._gameDemo,
        Constants.CategoryIDs._trailer,
        Constants.CategoryIDs._indie,
        Constants.CategoryIDs._theme,
        Constants.CategoryIDs._video,
        Constants.CategoryIDs._x360God,
        Constants.CategoryIDs._xgod
      };

            public static List<string> UserAgents { get; private set; } = new List<string>()
      {
        "Xbox Live Client/2.0.15574.0"
      };
        }
    }
}
