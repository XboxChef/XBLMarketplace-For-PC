using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;
using JasonNS;
using JasonNS.Types;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC
{
    public static class Constants
    {
#if DEBUG
        public const string Envpath = @"c:\Debug";
        public const string Debug = "D";
#endif

#if !DEBUG
        public static string Envpath = Environment.CurrentDirectory;
        public const string Debug = "R";
#endif
        public const string Iteration = "1";
        public const string Majorversion = "8";
        public const string Minorversion = "1";

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
            public const string Detailview = "detaillevel" + Detaillevel;
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
                internal static readonly XNamespace Live = LiveNameSpace;
                internal static readonly XNamespace Atom = AtomNameSpace;
                internal static readonly XNamespace Market = MarketNameSpace;
            }
        }
        public struct RegionIDs
        {
            internal static RegionId _northAmerica = new RegionId() {Name = "North America", LegalId = "en-US", Flag = Resources.us};
            internal static RegionId _germany = new RegionId() {Name = "Germany", LegalId = "de-DE", Flag = Resources.de};
            internal static RegionId _spain = new RegionId() {Name = "Spain", LegalId = "es-ES", Flag = Resources.es};
            internal static RegionId _france = new RegionId() {Name = "France", LegalId = "fr-FR", Flag = Resources.fr};
            internal static RegionId _greece = new RegionId() {Name = "Greece", LegalId = "gr-GR", Flag = Resources.gr};
            internal static RegionId _italy = new RegionId() {Name = "Italy", LegalId = "it-IT", Flag = Resources.it};
            internal static RegionId _japan = new RegionId() {Name = "Japan", LegalId = "jp-JP", Flag = Resources.jp};
            internal static RegionId _korea = new RegionId() {Name = "Korea", LegalId = "ko-KR", Flag = Resources.kr};
            internal static RegionId _poland = new RegionId() {Name = "Poland", LegalId = "pl-PL", Flag = Resources.pl};
            internal static RegionId _netherlands = new RegionId() {Name = "Netherlands", LegalId = "nl-NL", Flag = Resources.nl};
            internal static RegionId _portugal = new RegionId() {Name = "Portugal", LegalId = "pt-PT", Flag = Resources.pt};
            internal static RegionId _russia = new RegionId() {Name = "Russia", LegalId = "ru-RU", Flag = Resources.ru};
            internal static RegionId _sweden = new RegionId() {Name = "Sweden", LegalId = "sv-SE", Flag = Resources.se};
            internal static RegionId _turkey = new RegionId() {Name = "Turkey", LegalId = "tr-TR", Flag = Resources.tr};
            internal static RegionId _unitedArabEmirates = new RegionId() {Name = "United Arab Emirates", LegalId = "ar-AE", Flag = Resources.ae};
        }


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

        public struct QueryLanguage
        {
            internal static readonly Language English = new Language() {Id = "English", Code = "en-US"};
            internal static readonly Language German = new Language() {Id = "German", Code = "de-DE"};
        }

        public struct BindingLists
        {

            public static List<Language> Languages = new List<Language>() {QueryLanguage.English, QueryLanguage.German };

            public static List<RegionId> Regions { get; private set; } = new List<RegionId>
            {
                RegionIDs._northAmerica,
                RegionIDs._germany,
                RegionIDs._spain,
                RegionIDs._france,
                RegionIDs._greece,
                RegionIDs._italy,
                RegionIDs._japan,
                RegionIDs._korea,
                RegionIDs._poland,
                RegionIDs._netherlands,
                RegionIDs._portugal,
                RegionIDs._russia,
                RegionIDs._sweden,
                RegionIDs._turkey,
                RegionIDs._unitedArabEmirates
            };

            public static BindingSource RegionBindingSource = new BindingSource() {Regions};

            public static List<MediaId> Categorys { get; private set; } = new List<MediaId>()
            {
                CategoryIDs._arcade,
                CategoryIDs._arcadeDemo,
                CategoryIDs._avatarItems,
                CategoryIDs._dlc1,
                CategoryIDs._dlc2,
                CategoryIDs._gameDemo,
                CategoryIDs._trailer,
                CategoryIDs._indie,
                CategoryIDs._theme,
                CategoryIDs._video,
                CategoryIDs._x360God,
                CategoryIDs._xgod
            };

            public static BindingSource CategoryBindingSource = new BindingSource() {Categorys};

            public static List<string> UserAgents { get; private set; } = new List<string>()
            {
                "Xbox Live Client/2.0.15574.0"
            };

            public static BindingSource UserAgentBindingSource = new BindingSource() {UserAgents};
        }

        public static List<Credit> Credits = new List<Credit>()
        { CodeCredits.JasonNS,
            CodeCredits.Dwack,
            God2Iso.CodeCredits.God2Iso,
        };

    }
}