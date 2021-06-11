using System.ComponentModel;
using System.Linq;
using System.Net;
using ComponentOwl.BetterListView;
using JasonNS.Components;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main
    {
        private ThreadedBindingList<DownloadInstance> _downloads;

        private void download_init()
        {
            _downloads = new ThreadedBindingList<DownloadInstance>();
            downloadmanager_blv.DataSource = _downloads;
            foreach (BetterListViewColumnHeader header in downloadmanager_blv.Columns)
            {
                header.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void download_Contentdl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (ConverterOptions.autostart)
            {
                var firstOrDefault = _downloads.FirstOrDefault(d => d.DLStatus == DownloadStatus.Waiting);
                if (firstOrDefault != null) firstOrDefault.StartDownload();
            }
            DownloadInstance dli = (DownloadInstance)e.UserState;
            dli.ProgressChanged -= download_Contentdl_ProgressChanged;
            dli.DownloadFileCompleted -= download_Contentdl_DownloadFileCompleted;
            dli.CancelDownload();
            _xcpList.Add(dli.GetXcpInstance);
            dli.Dispose();
        }

        private void download_Contentdl_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadInstance dli = (DownloadInstance)e.UserState;
            _downloads.ResetItem(_downloads.IndexOf(dli));
        }
    }
}