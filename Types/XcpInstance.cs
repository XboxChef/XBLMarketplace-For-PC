// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Types.XcpInstance
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using God2Iso;
using God2Iso.Types;
using JasonNS.EventArguments;
using JasonNS.Exceptions;
using JasonNS.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XCPpackage;

namespace XBLMarketplace_For_PC.Types
{
  public class XcpInstance : PackageBase, IDisposable
  {
    private bool _cleanup;
    private bool _fullextract;
    private List<FileInfo> _godfilelist;
    private GameOnDemand _godinstance;
    private XcpUnpack _unpackerInstance;

    public XcpInstance(
      string xcpPath,
      string outputFolder,
      bool start,
      bool cleanup,
      PackageBase pb)
      : base(pb)
    {
      if (string.IsNullOrWhiteSpace(this.Title) || pb == null)
      {
        this.Title = Path.GetFileNameWithoutExtension(xcpPath);
        this.Status = PackageStatus.Waiting;
      }
      this.InFile = xcpPath;
      this.OutFolder = outputFolder + "\\" + Path.GetFileNameWithoutExtension(this.InFile);
      this.OutFile = (string) null;
      this._cleanup = cleanup;
      this._unpackerInstance = new XcpUnpack(this.InFile);
      this._unpackerInstance.UnpackAndSplitProgressChanged += new EventHandler<ProgressChangedEventArgs>(this.XcpInstance_UnpackAndSplitProgressChanged);
      this._unpackerInstance.UnpackProgressChanged += new EventHandler<ProgressChangedEventArgs>(this.XcpInstance_UnpackProgressChanged);
      this._unpackerInstance.SplitProgressChanged += new EventHandler<ProgressChangedEventArgs>(this.XcpInstance_SplitProgressChanged);
      if (string.Compare(Path.GetExtension(this.InFile), ".xcp", StringComparison.OrdinalIgnoreCase) == 0)
      {
        if (!start)
          return;
        this.FullExtract();
      }
      else if (string.Compare(Path.GetExtension(this.InFile), ".xup", StringComparison.OrdinalIgnoreCase) == 0)
      {
        if (!start)
          return;
        this.Split();
      }
      else
        this.Error =  new InvalidFileFormatException("File extension not Handled (Please Use *.xcp or *.xup)");
    }

    public XcpInstance(string xcpPath, PackageBase pb, string outputFolder = null)
      : this(xcpPath, outputFolder, false, pb)
    {
    }

    public XcpInstance(string xcpPath, string outputFolder, bool start, PackageBase pb)
      : this(xcpPath, outputFolder, start, false, pb)
    {
    }

    public string DefaultOutputFolder => this._unpackerInstance.DefaultPathOut;

    public GameOnDemand GodInstance
    {
      get
      {
        if (this._godfilelist == null)
          return (GameOnDemand) null;
        return this._godinstance != null ? this._godinstance : (this._godinstance = new GameOnDemand(new Pirs(this._godfilelist[0]), this._godfilelist.Skip<FileInfo>(1), (PackageBase) this));
      }
    }

    public void Dispose() => this._unpackerInstance.Dispose();

    public event EventHandler<ProgressChangedEventArgs> UnpackProgressChanged
    {
      add => this._unpackerInstance.UnpackProgressChanged += value;
      remove => this._unpackerInstance.UnpackProgressChanged -= value;
    }

    public event EventHandler<ProgressChangedEventArgs> UnpackAndSplitProgressChanged
    {
      add => this._unpackerInstance.UnpackAndSplitProgressChanged += value;
      remove => this._unpackerInstance.UnpackAndSplitProgressChanged -= value;
    }

    public event EventHandler<ProgressChangedEventArgs> SplitProgressChanged
    {
      add => this._unpackerInstance.SplitProgressChanged += value;
      remove => this._unpackerInstance.SplitProgressChanged -= value;
    }

    private event EventHandler XcpSplitCompleted
    {
      add => this._unpackerInstance.SplitCompleted += value;
      remove => this._unpackerInstance.SplitCompleted -= value;
    }

    private void XcpInstance_SplitProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (this._fullextract)
        return;
      this.PackageProgress = (short) e.Progress;
    }

    public event EventHandler UnpackCompleted
    {
      add => this._unpackerInstance.UnpackCompleted += value;
      remove => this._unpackerInstance.UnpackCompleted -= value;
    }

    private void XcpInstance_UnpackProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (this._fullextract)
        return;
      this.PackageProgress = (short) e.Progress;
    }

    public event EventHandler UnpackAndSplitComplete
    {
      add => this._unpackerInstance.UnpackAndSplitComplete += value;
      remove => this._unpackerInstance.UnpackAndSplitComplete -= value;
    }

    private void XcpInstance_UnpackAndSplitProgressChanged(
      object sender,
      ProgressChangedEventArgs e)
    {
      if (!this._fullextract)
        return;
      this.PackageProgress = (short) e.Progress;
    }

    public void FullExtract()
    {
      this._fullextract = true;
      this.Extract();
      this.Split();
    }

    public void Split()
    {
      this.Status = PackageStatus.Splitting;
      this._godfilelist = this._unpackerInstance.SplitXcp(this._cleanup, this.OutFolder);
      this.InFile = this._godfilelist[0].FullName;
      this.Status = PackageStatus.Waiting;
    }

    public void Extract()
    {
      this.Status = PackageStatus.Unpacking;
      this.InFile = this._unpackerInstance.DecompressXcp(this._cleanup, this.OutFolder).FullName;
      this.Status = PackageStatus.Waiting;
    }
  }
}
