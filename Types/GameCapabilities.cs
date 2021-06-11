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

        public GameCapabilities(XElement capabilityRaw)
        {

            var singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopHardDriveRequired").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Co-op Hard Drive Required", Value = singleOrDefault.Value });


            /*todo:Add Below GameCapabilityEntry's

            */

            /*Already Added
            offlineDolbyDigital
            onlineContentDownload
            onlineLeaderboards
            offlineCustomSoundtracks
            offlinePeripheralCamera
            offlineVoiceCommands
            offlineMaxHDTVModeId
            offlineCoopPlayersMax
            offlineCoopPlayersMin
            offlinePlayersMax
            offlinePlayersMin
            offlineCoopHardDriveRequired
            onlineMultiplayerMin
            onlineMultiplayerMax
            onlineMultiplayerHardDriveRequired
            onlineCoopPlayersMin
            onlineCoopPlayersMax
            onlineCoopHardDriveRequired
            onlineHardDriveRequired
            */

            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineLeaderboards").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Leaderboards", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineContentDownload").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Content Download", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineDolbyDigital").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Dolby Digital", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCustomSoundtracks").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Custom Soundtracks", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePeripheralCamera").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Peripheral Camera", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineVoiceCommands").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Voice Commands", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineMaxHDTVModeId").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Max HDTV Mode ID?", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopPlayersMin").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Co-op Players Min", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlineCoopPlayersMax").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Co-op Players Max", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePlayersMax").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Players Max", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "offlinePlayersMin").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Offline Players Min", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerMin").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Multiplayer Min", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerMax").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Multiplayer Max", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineMultiplayerHardDriveRequired").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Multiplayer Hard Drive Required", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopPlayersMin").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Co-op Players Min", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopPlayersMax").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Co-op Players Max", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineCoopHardDriveRequired").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Co-op Hard Drive Required", Value = singleOrDefault.Value });
            singleOrDefault = capabilityRaw.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "onlineHardDriveRequired").SingleOrDefault();
            if (singleOrDefault != null) GameCapabilityInfo.Add(new GameCapabilityEntry { Id = "Online Hard Drive Required", Value = singleOrDefault.Value });
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GameCapabilities() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}