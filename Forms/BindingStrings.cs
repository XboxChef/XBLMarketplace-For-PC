using System.ComponentModel;

namespace XBLMarketplace_For_PC.Forms
{
    public class BindingStrings : INotifyPropertyChanged
    {
        public static BindingStrings Instance = new BindingStrings();

        public static readonly string default_downloadPath = Constants.Envpath + @"\Xbox Compressed Package";
        public static readonly string default_isoPath = Constants.Envpath + @"\Isos";
        public static readonly string default_decompressPath = Constants.Envpath + @"\Decompressed";
        private string _decompressPath = Constants.Envpath + @"\Decompressed\";

        private string _downloadPath = Constants.Envpath + @"\Xbox Compressed Package\";
        private string _isoPath = Constants.Envpath + @"\Isos";

        public string DecompressPath
        {
            get { return _decompressPath; }
            set
            {
                if (value != _decompressPath)
                {
                    _decompressPath = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("DecompressPath"));
                }
            }
        }

        public string DownloadPath
        {
            get { return _downloadPath; }
            set
            {
                if (value != _downloadPath)
                {
                    _downloadPath = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DownloadPath"));
                }
            }
        }

        public string IsoPath
        {
            get { return _isoPath; }
            set
            {
                if (value != _isoPath)
                {
                    _isoPath = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsoPath"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}