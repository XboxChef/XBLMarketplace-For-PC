using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using ComponentOwl.BetterListView;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main
    {
        private UiBindingList<DownloadInstance> _downloads;
        private readonly Stopwatch _downloadRefresh = Stopwatch.StartNew();

        private void download_init()
        {
            _downloads = new UiBindingList<DownloadInstance>();
            downloadmanager_blv.DataSource = _downloads;
            foreach (BetterListViewColumnHeader header in downloadmanager_blv.Columns)
            {
                header.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void download_Contentdl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadInstance dli = (DownloadInstance)e.UserState;
            dli.ProgressChanged -= download_Contentdl_ProgressChanged;
            dli.DownloadFileCompleted -= download_Contentdl_DownloadFileCompleted;
            try
            {
                //Hand the finished package to the converter, failed and canceled downloads have none
                XcpInstance xcp = dli.GetXcpInstance;
                if (xcp != null) _xcpList.Add(xcp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                dli.Dispose();
                download_RefreshRow(dli);
                DownloadSpeed_tssl.Text = "—";
            }
            //Start the next queued download
            _downloads.FirstOrDefault(d => d.DLStatus == DownloadStatus.Waiting)?.StartDownload();
        }

        private void download_Contentdl_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //WebClient reports every chunk it receives, a few refreshes a second is plenty
            if (_downloadRefresh.ElapsedMilliseconds < 250) return;
            _downloadRefresh.Restart();
            DownloadInstance dli = (DownloadInstance)e.UserState;
            download_RefreshRow(dli);
            DownloadSpeed_tssl.Text = dli.SpeedString;
        }

        private void download_RefreshRow(DownloadInstance dli)
        {
            int index = _downloads.IndexOf(dli);
            if (index >= 0) _downloads.ResetItem(index);
        }
    }
}
