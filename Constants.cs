﻿// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Constants
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        internal static readonly XNamespace Live = (XNamespace) "http://www.live.com/marketplace";
        internal static readonly XNamespace Atom = (XNamespace) "http://www.w3.org/2005/Atom";
        internal static readonly XNamespace Market = (XNamespace) "http://marketplace.xboxlive.com/resource/product/v1";
      }
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct RegionIDs
    {
      internal static RegionId _northAmerica = new RegionId()
      {
        Name = "North America",
        LegalId = "en-US",
        Flag = (Image) Resources.us
      };
      internal static RegionId _germany = new RegionId()
      {
        Name = "Germany",
        LegalId = "de-DE",
        Flag = (Image) Resources.de
      };
      internal static RegionId _spain = new RegionId()
      {
        Name = "Spain",
        LegalId = "es-ES",
        Flag = (Image) Resources.es
      };
      internal static RegionId _france = new RegionId()
      {
        Name = "France",
        LegalId = "fr-FR",
        Flag = (Image) Resources.fr
      };
      internal static RegionId _greece = new RegionId()
      {
        Name = "Greece",
        LegalId = "gr-GR",
        Flag = (Image) Resources.gr
      };
      internal static RegionId _italy = new RegionId()
      {
        Name = "Italy",
        LegalId = "it-IT",
        Flag = (Image) Resources.it
      };
      internal static RegionId _japan = new RegionId()
      {
        Name = "Japan",
        LegalId = "jp-JP",
        Flag = (Image) Resources.jp
      };
      internal static RegionId _korea = new RegionId()
      {
        Name = "Korea",
        LegalId = "ko-KR",
        Flag = (Image) Resources.kr
      };
      internal static RegionId _poland = new RegionId()
      {
        Name = "Poland",
        LegalId = "pl-PL",
        Flag = (Image) Resources.pl
      };
      internal static RegionId _netherlands = new RegionId()
      {
        Name = "Netherlands",
        LegalId = "nl-NL",
        Flag = (Image) Resources.nl
      };
      internal static RegionId _portugal = new RegionId()
      {
        Name = "Portugal",
        LegalId = "pt-PT",
        Flag = (Image) Resources.pt
      };
      internal static RegionId _russia = new RegionId()
      {
        Name = "Russia",
        LegalId = "ru-RU",
        Flag = (Image) Resources.ru
      };
      internal static RegionId _sweden = new RegionId()
      {
        Name = "Sweden",
        LegalId = "sv-SE",
        Flag = (Image) Resources.se
      };
      internal static RegionId _turkey = new RegionId()
      {
        Name = "Turkey",
        LegalId = "tr-TR",
        Flag = (Image) Resources.tr
      };
      internal static RegionId _unitedArabEmirates = new RegionId()
      {
        Name = "United Arab Emirates",
        LegalId = "ar-AE",
        Flag = (Image) Resources.ae
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
      internal static readonly Language English = new Language()
      {
        Id = nameof (English),
        Code = "en-US"
      };
      internal static readonly Language German = new Language()
      {
        Id = nameof (German),
        Code = "de-DE"
      };
    }

    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct BindingLists
    {
      public static List<Language> Languages = new List<Language>()
      {
        Constants.QueryLanguage.English,
        Constants.QueryLanguage.German
      };
      public static BindingSource RegionBindingSource = new BindingSource()
      {
        (object) Constants.BindingLists.Regions
      };
      public static BindingSource CategoryBindingSource = new BindingSource()
      {
        (object) Constants.BindingLists.Categorys
      };
      public static BindingSource UserAgentBindingSource = new BindingSource()
      {
        (object) Constants.BindingLists.UserAgents
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