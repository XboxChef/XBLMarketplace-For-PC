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

    public void Dispose() => this._dlHandler.Dispose();

    public DownloadInstance(string url, string outpath, PackageBase pb = null)
      : this(url, new FileInfo(outpath), pb)
    {
    }

    public DownloadInstance(string url, FileInfo filePathI, PackageBase pb)
      : base(pb)
      => this._dlHandler = new DownloadInstance.Download(url, filePathI.FullName, (object) this, pb);

    public void StartDownload() => this._dlHandler.DownloadFile();

    public void CancelDownload() => this._dlHandler.CancelDownload();

    public event AsyncCompletedEventHandler DownloadFileCompleted
    {
      add => this._dlHandler.FileCompleted += value;
      remove => this._dlHandler.FileCompleted -= value;
    }

    public event DownloadProgressChangedEventHandler ProgressChanged
    {
      add => this._dlHandler.ProgressChanged += value;
      remove => this._dlHandler.ProgressChanged -= value;
    }

    public string Url => this._dlHandler.Url.ToString();

    public string SpeedString => this._dlHandler.SpeedString;

    public double SpeedDouble => this._dlHandler.SpeedDouble;

    public string ProgressString => this._dlHandler.ProgressString;

    public new short PackageProgress => this._dlHandler.PackageProgress;

    public string TotalDownloaded => this._dlHandler.TotalDownloaded;

    public DownloadStatus DLStatus => this._dlHandler.DStatus;

    public XcpInstance GetXcpInstance => this.DLStatus == DownloadStatus.Finished ? new XcpInstance(this.OutFile, BindingStrings.Instance.DecompressPath, Main.ConverterOptions.autostart, Main.ConverterOptions.cleanup, (PackageBase) this._dlHandler) : (XcpInstance) null;

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

      internal Download(string urlAddress, string outPath, object owner, PackageBase pb)
        : base(pb)
      {
        this.Url = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);
        this.OutFile = outPath;
        this._owner = owner;
        this.ProgressChanged += new DownloadProgressChangedEventHandler(this._ProgressChanged);
        this.FileCompleted += new AsyncCompletedEventHandler(this._DownloadCompleted);
      }

      public void Dispose()
      {
        this.client.Dispose();
        this.ProgressChanged -= new DownloadProgressChangedEventHandler(this._ProgressChanged);
        this.FileCompleted -= new AsyncCompletedEventHandler(this._DownloadCompleted);
      }

      public event AsyncCompletedEventHandler FileCompleted
      {
        add => this.client.DownloadFileCompleted += value;
        remove => this.client.DownloadFileCompleted -= value;
      }

      public event DownloadProgressChangedEventHandler ProgressChanged
      {
        add => this.client.DownloadProgressChanged += value;
        remove => this.client.DownloadProgressChanged -= value;
      }

      internal void CancelDownload() => this.client.CancelAsync();

      internal void DownloadFile()
      {
        this.sw.Start();
        try
        {
          if (!Directory.Exists(Path.GetDirectoryName(this.OutFile)))
            Directory.CreateDirectory(Path.GetDirectoryName(this.OutFile));
          if (System.IO.File.Exists(this.OutFile))
            System.IO.File.Delete(this.OutFile);
          if (Directory.Exists(this.OutFile))
            Directory.Delete(this.OutFile);
          this.client.DownloadFileAsync(this.Url, this.OutFile, this._owner ?? (object) this);
          this.DStatus = DownloadStatus.Downloading;
          this.Status = PackageStatus.Downloading;
        }
        catch (Exception ex)
        {
          Console.Write(ex.Message);
          throw;
        }
      }

      private void _ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
      {
        this.SpeedDouble = (double) e.BytesReceived / this.sw.Elapsed.TotalSeconds;
        this.PackageProgress = (short) e.ProgressPercentage;
        this.ProgressString = e.ProgressPercentage.ToString() + "%";
        double num = (double) e.BytesReceived / 1024.0 / 1024.0;
        string str1 = num.ToString("0.00");
        num = (double) e.TotalBytesToReceive / 1024.0 / 1024.0;
        string str2 = num.ToString("0.00");
        this.TotalDownloaded = string.Format("{0} MB's / {1} MB's", (object) str1, (object) str2);
      }

      private void _DownloadCompleted(object sender, AsyncCompletedEventArgs e)
      {
        this.sw.Reset();
        if (e.Cancelled)
        {
          this.DStatus = DownloadStatus.Canceled;
          this.Status = PackageStatus.Canceled;
        }
        else
        {
          if (e.Error != null)
          {
            this.DStatus = DownloadStatus.Waiting;
            this.Status = PackageStatus.Errored;
            this.Error = e.Error;
          }
          this.DStatus = DownloadStatus.Finished;
          this.Status = PackageStatus.Waiting;
        }
      }
    }
  }
}
