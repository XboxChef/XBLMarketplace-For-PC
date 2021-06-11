using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using JasonNS.Types;
using XBLMarketplace_For_PC.Forms;

namespace XBLMarketplace_For_PC.Types
{
    public class DownloadInstance : PackageBase, IDisposable
    {
        public void Dispose()
        {
            _dlHandler.Dispose();
        }

        private class Download : PackageBase, IDisposable
        {
            private readonly WebClient client = new WebClient();
            private readonly Stopwatch sw = new Stopwatch();
            internal readonly Uri Url;
            private object _owner;
            internal DownloadStatus DStatus = DownloadStatus.Waiting;


            internal string ProgressString;
            internal double SpeedDouble;
            internal string SpeedString;
            internal string TotalDownloaded;

            internal Download(string urlAddress, string outPath, object owner, PackageBase pb) : base(pb)
            {
                Url = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);
                OutFile = outPath;
                _owner = owner;
                this.ProgressChanged += _ProgressChanged;
                this.FileCompleted += _DownloadCompleted;
            }

            public void Dispose()
            {
                client.Dispose();
                ProgressChanged -= _ProgressChanged;
                FileCompleted -= _DownloadCompleted;

            }

            public event AsyncCompletedEventHandler FileCompleted
            {
                add { client.DownloadFileCompleted += value; }
                remove { client.DownloadFileCompleted -= value; }
            }

            public event DownloadProgressChangedEventHandler ProgressChanged
            {
                add { client.DownloadProgressChanged += value; }
                remove { client.DownloadProgressChanged -= value; }
            }

            internal void CancelDownload()
            {
                client.CancelAsync();
            }

            internal void DownloadFile()
            {
                sw.Start();

                try
                {
                    // Start downloading the file
                    if (!Directory.Exists(Path.GetDirectoryName(OutFile))) Directory.CreateDirectory(Path.GetDirectoryName(OutFile));
                    if (File.Exists(OutFile)) File.Delete(OutFile);
                    if (Directory.Exists(OutFile)) Directory.Delete(OutFile);
                    client.DownloadFileAsync(Url, OutFile, _owner ?? this);
                    DStatus = DownloadStatus.Downloading;
                    Status = PackageStatus.Downloading;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    throw;
                }

            }

            // The event that will fire whenever the progress of the WebClient is changed
            private void _ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                // Calculate download speed and output it to labelSpeed.
                SpeedString = string.Format("{0} kb/s", (e.BytesReceived/1024d/sw.Elapsed.TotalSeconds).ToString("0.00"));
                SpeedDouble = e.BytesReceived/sw.Elapsed.TotalSeconds;
                // Update the progressbar percentage only when the value is not the same.
                PackageProgress = (short) e.ProgressPercentage;

                // Show the percentage on our label.
                ProgressString = e.ProgressPercentage.ToString() + "%";

                // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
                TotalDownloaded = string.Format("{0} MB's / {1} MB's",
                    (e.BytesReceived/1024d/1024d).ToString("0.00"),
                    (e.TotalBytesToReceive/1024d/1024d).ToString("0.00"));
            }

            // The event that will trigger when the WebClient is completed
            private void _DownloadCompleted(object sender, AsyncCompletedEventArgs e)
            {
                // Reset the stopwatch.
                sw.Reset();

                if (e.Cancelled)
                {
                    DStatus = DownloadStatus.Canceled;
                    Status = PackageStatus.Canceled;
                }
                else
                {
                    if (e.Error != null)
                    {
                        DStatus = DownloadStatus.Waiting;
                        Status = PackageStatus.Errored;
                        Error = e.Error;
                        //throw Error;
                    }
                    DStatus = DownloadStatus.Finished;
                    Status = PackageStatus.Waiting;
                }
            }
        }

        #region Constructors

        public DownloadInstance(string url, string outpath,PackageBase pb = null) : this(url, new FileInfo(outpath),pb)
        {}

        public DownloadInstance(string url, FileInfo filePathI, PackageBase pb) : base(pb)
        {
            _dlHandler = new Download(url, filePathI.FullName,this,pb);
        }

        private readonly Download _dlHandler;

        #endregion

        #region Methods And Events

        public void StartDownload() => _dlHandler.DownloadFile();
        public void CancelDownload() => _dlHandler.CancelDownload();

        public event AsyncCompletedEventHandler DownloadFileCompleted
        {
            add { _dlHandler.FileCompleted += value; }
            remove { _dlHandler.FileCompleted -= value; }
        }

        public event DownloadProgressChangedEventHandler ProgressChanged
        {
            add { _dlHandler.ProgressChanged += value; }
            remove { _dlHandler.ProgressChanged -= value; }
        }

        #endregion

        #region Variables

        public string Url => _dlHandler.Url.ToString();

        public string SpeedString => _dlHandler.SpeedString;
        public double SpeedDouble => _dlHandler.SpeedDouble;
        public string ProgressString => _dlHandler.ProgressString;
        public new short PackageProgress => _dlHandler.PackageProgress;
        public string TotalDownloaded => _dlHandler.TotalDownloaded;
        public DownloadStatus DLStatus => _dlHandler.DStatus;

        public XcpInstance GetXcpInstance
        {
            get
            {
                if (DLStatus == DownloadStatus.Finished)
                {
                    return new XcpInstance(
                        OutFile,
                        BindingStrings.Instance.DecompressPath,
                        Main.ConverterOptions.autostart,
                        Main.ConverterOptions.cleanup, _dlHandler);
                }
                return null;
            }
        }

        //public TimeSpan EstimatedTimeLeft => _dlinstance.Left;
        //public bool Paused => _dlinstance.IsWorking();

        #endregion
    }

    public class IsoInstance
    {
        IsoInstance()
        {
            throw new NotImplementedException();
        }
    }
}