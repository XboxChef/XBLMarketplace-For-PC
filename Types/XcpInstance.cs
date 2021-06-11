using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using God2Iso;
using God2Iso.Types;
using JasonNS.EventArguments;
using JasonNS.Exceptions;
using JasonNS.Types;
using XCPpackage;

namespace XBLMarketplace_For_PC.Types
{
    public class XcpInstance : PackageBase, IDisposable
    {
        private bool _cleanup;

        private bool _fullextract;
        private List<FileInfo> _godfilelist;

        private GameOnDemand _godinstance;
        private XcpUnpack _unpackerInstance; //Todo:Confirm this object properly manages memory internally (within XcpPackage.sln)

        public XcpInstance(string xcpPath, string outputFolder, bool start, bool cleanup, PackageBase pb) : base(pb)
        {
            if (string.IsNullOrWhiteSpace(Title) || (pb == null))
            {
                Title = Path.GetFileNameWithoutExtension(xcpPath);

                Status = PackageStatus.Waiting;
            }
            InFile = xcpPath;
            OutFolder = outputFolder + @"\" + Path.GetFileNameWithoutExtension(InFile);
            OutFile = null;
            _cleanup = cleanup;
            _unpackerInstance = new XcpUnpack(InFile);

            _unpackerInstance.UnpackAndSplitProgressChanged += XcpInstance_UnpackAndSplitProgressChanged;

            _unpackerInstance.UnpackProgressChanged += XcpInstance_UnpackProgressChanged;
            
            _unpackerInstance.SplitProgressChanged += XcpInstance_SplitProgressChanged;

            if (string.Compare(Path.GetExtension(InFile), ".xcp", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (start)
                {
                    FullExtract();
                }
            }
            else if (string.Compare(Path.GetExtension(InFile), ".xup", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (start)
                {
                    Split();
                }
            }
            else
            {
                Error = new InvalidFileFormatException("File extension not Handled (Please Use *.xcp or *.xup)");
            }
        }

        public XcpInstance(string xcpPath, PackageBase pb, string outputFolder = null) : this(xcpPath, outputFolder, false, pb)
        {
            
        }

        public XcpInstance(string xcpPath, string outputFolder, bool start, PackageBase pb) : this(xcpPath, outputFolder, start, false,pb)
        {
        }

        public string DefaultOutputFolder => _unpackerInstance.DefaultPathOut;

        public GameOnDemand GodInstance
        {
            get
            {
                if (_godfilelist == null) return null;
                if (_godinstance != null) return _godinstance;
                return _godinstance = new GameOnDemand(new Pirs(_godfilelist[0]), _godfilelist.Skip(1), this);
            }
        }

        public void Dispose()
        {
            _unpackerInstance.Dispose();
        }

        public event EventHandler<ProgressChangedEventArgs> UnpackProgressChanged
        {
            add { _unpackerInstance.UnpackProgressChanged += value; }
            remove { _unpackerInstance.UnpackProgressChanged -= value; }
        }

        public event EventHandler<ProgressChangedEventArgs> UnpackAndSplitProgressChanged
        {
            add { _unpackerInstance.UnpackAndSplitProgressChanged += value; }
            remove { _unpackerInstance.UnpackAndSplitProgressChanged -= value; }
        }

        public event EventHandler<ProgressChangedEventArgs> SplitProgressChanged
        {
            add { _unpackerInstance.SplitProgressChanged += value; }
            remove { _unpackerInstance.SplitProgressChanged -= value; }
        }

        private event EventHandler XcpSplitCompleted
        {
            add { _unpackerInstance.SplitCompleted += value; }
            remove { _unpackerInstance.SplitCompleted -= value; }
        }

        private void XcpInstance_SplitProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!_fullextract)
                PackageProgress = (short)e.Progress;
        }

        public event EventHandler UnpackCompleted
        {
            add { _unpackerInstance.UnpackCompleted += value; }
            remove { _unpackerInstance.UnpackCompleted -= value; }
        }


        private void XcpInstance_UnpackProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(!_fullextract)
            PackageProgress = (short)e.Progress;
        }

        public event EventHandler UnpackAndSplitComplete
        {
            add { _unpackerInstance.UnpackAndSplitComplete += value; }
            remove { _unpackerInstance.UnpackAndSplitComplete -= value; }
        }

        private void XcpInstance_UnpackAndSplitProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (_fullextract)
                PackageProgress = (short)e.Progress;
            
        }


        public void FullExtract()
        {
            _fullextract = true;
            Extract();
            Split();
        }

        public void Split()
        {
            Status = PackageStatus.Splitting;
            _godfilelist = _unpackerInstance.SplitXcp(_cleanup, OutFolder);
            InFile = _godfilelist[0].FullName;
            Status = PackageStatus.Waiting;
        }

        public void Extract()
        {
            Status = PackageStatus.Unpacking;
            InFile = _unpackerInstance.DecompressXcp(_cleanup, OutFolder).FullName;
            Status = PackageStatus.Waiting;
        }
    }
}