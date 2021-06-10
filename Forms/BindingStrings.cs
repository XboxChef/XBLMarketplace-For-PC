// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Forms.BindingStrings
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System.ComponentModel;

namespace XBLMarketplace_For_PC.Forms
{
  public class BindingStrings : INotifyPropertyChanged
  {
    public static BindingStrings Instance = new BindingStrings();
    public static readonly string default_downloadPath = Constants.Envpath + "\\Xbox Compressed Package";
    public static readonly string default_isoPath = Constants.Envpath + "\\Isos";
    public static readonly string default_decompressPath = Constants.Envpath + "\\Decompressed";
    private string _decompressPath = Constants.Envpath + "\\Decompressed\\";
    private string _downloadPath = Constants.Envpath + "\\Xbox Compressed Package\\";
    private string _isoPath = Constants.Envpath + "\\Isos";

    public string DecompressPath
    {
      get => this._decompressPath;
      set
      {
        if (!(value != this._decompressPath))
          return;
        this._decompressPath = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (DecompressPath)));
      }
    }

    public string DownloadPath
    {
      get => this._downloadPath;
      set
      {
        if (!(value != this._downloadPath))
          return;
        this._downloadPath = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (DownloadPath)));
      }
    }

    public string IsoPath
    {
      get => this._isoPath;
      set
      {
        if (!(value != this._isoPath))
          return;
        this._isoPath = value;
        PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if (propertyChanged == null)
          return;
        propertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsoPath)));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
