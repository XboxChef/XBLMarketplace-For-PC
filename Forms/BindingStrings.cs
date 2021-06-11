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
            get => _decompressPath;
            set
            {
                if (!(value != _decompressPath))
                    return;
                _decompressPath = value;
                PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if (propertyChanged == null)
                    return;
                propertyChanged(this, new PropertyChangedEventArgs(nameof(DecompressPath)));
            }
        }

        public string DownloadPath
        {
            get => _downloadPath;
            set
            {
                if (!(value != _downloadPath))
                    return;
                _downloadPath = value;
                PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if (propertyChanged == null)
                    return;
                propertyChanged(this, new PropertyChangedEventArgs(nameof(DownloadPath)));
            }
        }

        public string IsoPath
        {
            get => _isoPath;
            set
            {
                if (!(value != _isoPath))
                    return;
                _isoPath = value;
                PropertyChangedEventHandler propertyChanged = PropertyChanged;
                if (propertyChanged == null)
                    return;
                propertyChanged(this, new PropertyChangedEventArgs(nameof(IsoPath)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
