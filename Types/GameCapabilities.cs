// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.GameCapabilities
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Structs;

namespace XBLMarketplace_For_PC.Types
{
  public class GameCapabilities : IDisposable
  {
    public BindingList<GameCapabilityEntry> GameCapabilityInfo = new BindingList<GameCapabilityEntry>();
    private bool disposedValue;

    public GameCapabilities(XElement capabilityRaw)
    {
      XElement xelement1 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopHardDriveRequired").SingleOrDefault<XElement>();
      GameCapabilityEntry gameCapabilityEntry1;
      if (xelement1 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Co-op Hard Drive Required";
        gameCapabilityEntry1.Value = xelement1.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement2 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineLeaderboards").SingleOrDefault<XElement>();
      if (xelement2 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Leaderboards";
        gameCapabilityEntry1.Value = xelement2.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement3 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineContentDownload").SingleOrDefault<XElement>();
      if (xelement3 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Content Download";
        gameCapabilityEntry1.Value = xelement3.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement4 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineDolbyDigital").SingleOrDefault<XElement>();
      if (xelement4 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Dolby Digital";
        gameCapabilityEntry1.Value = xelement4.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement5 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCustomSoundtracks").SingleOrDefault<XElement>();
      if (xelement5 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Custom Soundtracks";
        gameCapabilityEntry1.Value = xelement5.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement6 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePeripheralCamera").SingleOrDefault<XElement>();
      if (xelement6 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Peripheral Camera";
        gameCapabilityEntry1.Value = xelement6.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement7 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineVoiceCommands").SingleOrDefault<XElement>();
      if (xelement7 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Voice Commands";
        gameCapabilityEntry1.Value = xelement7.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement8 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineMaxHDTVModeId").SingleOrDefault<XElement>();
      if (xelement8 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Max HDTV Mode ID?";
        gameCapabilityEntry1.Value = xelement8.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement9 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopPlayersMin").SingleOrDefault<XElement>();
      if (xelement9 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Co-op Players Min";
        gameCapabilityEntry1.Value = xelement9.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement10 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopPlayersMax").SingleOrDefault<XElement>();
      if (xelement10 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Co-op Players Max";
        gameCapabilityEntry1.Value = xelement10.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement11 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePlayersMax").SingleOrDefault<XElement>();
      if (xelement11 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Players Max";
        gameCapabilityEntry1.Value = xelement11.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement12 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePlayersMin").SingleOrDefault<XElement>();
      if (xelement12 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Offline Players Min";
        gameCapabilityEntry1.Value = xelement12.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement13 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerMin").SingleOrDefault<XElement>();
      if (xelement13 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Multiplayer Min";
        gameCapabilityEntry1.Value = xelement13.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement14 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerMax").SingleOrDefault<XElement>();
      if (xelement14 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Multiplayer Max";
        gameCapabilityEntry1.Value = xelement14.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement15 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerHardDriveRequired").SingleOrDefault<XElement>();
      if (xelement15 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Multiplayer Hard Drive Required";
        gameCapabilityEntry1.Value = xelement15.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement16 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopPlayersMin").SingleOrDefault<XElement>();
      if (xelement16 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Co-op Players Min";
        gameCapabilityEntry1.Value = xelement16.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement17 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopPlayersMax").SingleOrDefault<XElement>();
      if (xelement17 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Co-op Players Max";
        gameCapabilityEntry1.Value = xelement17.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement18 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopHardDriveRequired").SingleOrDefault<XElement>();
      if (xelement18 != null)
      {
        BindingList<GameCapabilityEntry> gameCapabilityInfo = this.GameCapabilityInfo;
        gameCapabilityEntry1 = new GameCapabilityEntry();
        gameCapabilityEntry1.Id = "Online Co-op Hard Drive Required";
        gameCapabilityEntry1.Value = xelement18.Value;
        GameCapabilityEntry gameCapabilityEntry2 = gameCapabilityEntry1;
        gameCapabilityInfo.Add(gameCapabilityEntry2);
      }
      XElement xelement19 = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineHardDriveRequired").SingleOrDefault<XElement>();
      if (xelement19 == null)
        return;
      BindingList<GameCapabilityEntry> gameCapabilityInfo1 = this.GameCapabilityInfo;
      gameCapabilityEntry1 = new GameCapabilityEntry();
      gameCapabilityEntry1.Id = "Online Hard Drive Required";
      gameCapabilityEntry1.Value = xelement19.Value;
      GameCapabilityEntry gameCapabilityEntry3 = gameCapabilityEntry1;
      gameCapabilityInfo1.Add(gameCapabilityEntry3);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposedValue)
        return;
      int num = disposing ? 1 : 0;
      this.disposedValue = true;
    }

    public void Dispose() => this.Dispose(true);
  }
}
