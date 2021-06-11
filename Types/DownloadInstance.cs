// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.DownloadInstance
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using JasonNS.Types;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using XBLMarketplace_For_PC.Forms;

namespace XBLMarketplace_For_PC.Types
{
    public class DownloadInstance : PackageBase, IDisposable
    {
        private readonly DownloadInstance.Download _dlHandler;

        public void Dispose() => _dlHandler.Dispose();

        public DownloadInstance(string url, string outpath, PackageBase pb = null)
          : this(url, new FileInfo(outpath), pb)
        {
        }

        public DownloadInstance(string url, FileInfo filePathI, PackageBase pb)
          : base(pb)
          => _dlHandler = new DownloadInstance.Download(url, filePathI.FullName, this, pb);

        public void StartDownload() => _dlHandler.DownloadFile();

        public void CancelDownload() => _dlHandler.CancelDownload();

        public event AsyncCompletedEventHandler DownloadFileCompleted
        {
            add => _dlHandler.FileCompleted += value;
            remove => _dlHandler.FileCompleted -= value;
        }

        public event DownloadProgressChangedEventHandler ProgressChanged
        {
            add => _dlHandler.ProgressChanged += value;
            remove => _dlHandler.ProgressChanged -= value;
        }

        public string Url => _dlHandler.Url.ToString();

        //public string SpeedString => _dlHandler.SpeedString;

        public double SpeedDouble => _dlHandler.SpeedDouble;

        public string ProgressString => _dlHandler.ProgressString;

        public new short PackageProgress => _dlHandler.PackageProgress;

        public string TotalDownloaded => _dlHandler.TotalDownloaded;

        public DownloadStatus DLStatus => _dlHandler.DStatus;
        public static string OutFILE = "";

        public XcpInstance GetXcpInstance => DLStatus == DownloadStatus.Finished ? new XcpInstance(OutFILE, BindingStrings.Instance.DecompressPath, Main.ConverterOptions.autostart, Main.ConverterOptions.cleanup, _dlHandler) : null;

        private class Download : PackageBase, IDisposable
        {
            private readonly WebClient client = new WebClient();
            private readonly Stopwatch sw = new Stopwatch();
            internal readonly Uri Url;
            private readonly object _owner;
            internal DownloadStatus DStatus = DownloadStatus.Waiting;
            internal string ProgressString;
            internal double SpeedDouble;
            internal string TotalDownloaded;

            internal Download(string urlAddress, string outPath, object owner, PackageBase pb)
              : base(pb)
            {
                Url = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);
                OutFile = outPath;
                OutFILE = outPath;
                _owner = owner;
                ProgressChanged += new DownloadProgressChangedEventHandler(_ProgressChanged);
                FileCompleted += new AsyncCompletedEventHandler(_DownloadCompleted);
            }

            public void Dispose()
            {
                client.Dispose();
                ProgressChanged -= new DownloadProgressChangedEventHandler(_ProgressChanged);
                FileCompleted -= new AsyncCompletedEventHandler(_DownloadCompleted);
            }

            public event AsyncCompletedEventHandler FileCompleted
            {
                add => client.DownloadFileCompleted += value;
                remove => client.DownloadFileCompleted -= value;
            }

            public event DownloadProgressChangedEventHandler ProgressChanged
            {
                add => client.DownloadProgressChanged += value;
                remove => client.DownloadProgressChanged -= value;
            }

            internal void CancelDownload() => client.CancelAsync();

            internal void DownloadFile()
            {
                sw.Start();
                try
                {
                    if (!Directory.Exists(Path.GetDirectoryName(OutFile)))
                        Directory.CreateDirectory(Path.GetDirectoryName(OutFile));
                    if (System.IO.File.Exists(OutFile))
                        System.IO.File.Delete(OutFile);
                    if (Directory.Exists(OutFile))
                        Directory.Delete(OutFile);
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

            private void _ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                try
                {
                    SpeedDouble = e.BytesReceived / sw.Elapsed.TotalSeconds;
                    PackageProgress = (short)e.ProgressPercentage;
                    ProgressString = e.ProgressPercentage.ToString() + "%";
                    double num = e.BytesReceived / 1024.0 / 1024.0;
                    string str1 = num.ToString("0.00");
                    num = e.TotalBytesToReceive / 1024.0 / 1024.0;
                    string str2 = num.ToString("0.00");
                    TotalDownloaded = string.Format("{0} MB's / {1} MB's", str1, str2);
                }
                catch
                {

                }
            }

            private void _DownloadCompleted(object sender, AsyncCompletedEventArgs e)
            {
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
                    }
                    DStatus = DownloadStatus.Finished;
                    Status = PackageStatus.Waiting;
                }
            }
        }
    }
}
