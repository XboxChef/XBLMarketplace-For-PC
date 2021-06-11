namespace XCPpackage
{
    using Ionic.Zlib;
    using JasonNS.EventArguments;
    using JasonNS.Types;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    public class XcpUnpack : IDisposable
    {
        private FileInfo _fileIn;
        private long _lastStream;
        private long _srcsize;

        public event EventHandler SplitCompleted;

        public event EventHandler<ProgressChangedEventArgs> SplitProgressChanged;

        public event EventHandler UnpackAndSplitComplete;

        public event EventHandler<ProgressChangedEventArgs> UnpackAndSplitProgressChanged;

        public event EventHandler UnpackCompleted;

        public event EventHandler<ProgressChangedEventArgs> UnpackProgressChanged;

        public XcpUnpack(FileInfo fileIn)
        {
            this._fileIn = fileIn;
        }

        public XcpUnpack(string fileIn) : this(new FileInfo(fileIn))
        {
        }

        public List<FileInfo> DecompressAndSplit(bool cleanup = false, string directoryOut = null)
        {
            List<FileInfo> list;
            try
            {
                this.Reinit();
                this._fileIn = this.DecompressXcp(cleanup, directoryOut);
                this.OnUnpackAndSplitComplete(new EventArgs());
                list = this.SplitXcp(cleanup, directoryOut);
            }
            catch (Exception exception1)
            {
                Console.Write(exception1.ToString());
                throw;
            }
            return list;
        }

        public FileInfo DecompressXcp(bool cleanup = false, string directoryOut = null)
        {
            FileInfo info;
            FileInfo info3;
            if (!this._fileIn.Exists)
            {
                throw new FileNotFoundException("File Not Found", this._fileIn.FullName);
            }
            FileOptions options = cleanup ? FileOptions.DeleteOnClose : FileOptions.None;
            if (directoryOut == null)
            {
                info = new FileInfo(this._fileIn.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(this._fileIn.Name) + ".xup");
            }
            else
            {
                if (!Directory.Exists(directoryOut + @"\"))
                {
                    Directory.CreateDirectory(directoryOut + @"\");
                }
                info = new FileInfo(directoryOut + @"\" + Path.GetFileNameWithoutExtension(this._fileIn.Name) + ".xup");
            }
            try
            {
                FileInfo info2;
                using (FILE file = new FILE(this._fileIn.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x4000, options))
                {
                    if (info.Exists)
                    {
                        info.Delete();
                    }
                    info2 = this.first_pass(file, info.FullName);
                }
                this.OnUnpackCompleted(new EventArgs());
                this._fileIn = info2;
                info3 = info2;
            }
            catch (Exception exception1)
            {
                info.Delete();
                Console.WriteLine(exception1.ToString());
                throw;
            }
            return info3;
        }

        public void Dispose()
        {
            this.UnpackAndSplitProgressChanged = null;
            this.UnpackProgressChanged = null;
            this.SplitProgressChanged = null;
            this.UnpackAndSplitComplete = null;
            this.UnpackCompleted = null;
            this.SplitCompleted = null;
        }

        private FileInfo first_pass(FILE inXcp, string outpath)
        {
            FileInfo fi;
            this.Reinit();
            this._srcsize = inXcp.FileSize;
            inXcp.Position = 0L;
            Console.Write("\r\nUnpacking XCP\r\n");
            using (FILE file = new FILE(outpath, FileMode.Create, FileAccess.Write, FileShare.Read, 0x4000, FileOptions.None))
            {
                fi = file.Fi;
                while ((this._srcsize - this._lastStream) > 0L)
                {
                    this.Inflate(inXcp, file);
                }
            }
            Console.Write("\r\nUnpack Sucess\r\n");
            return fi;
        }

        private void Inflate(FILE source, FILE dest)
        {
            byte[] buffer = new byte[16384];
            ZlibStream zlibStream = new ZlibStream((Stream)source, CompressionMode.Decompress, true)
            {
                BufferSize = 16384,
                FlushMode = FlushType.Full
            };
            short num1 = 0;
            while (zlibStream.Read(buffer, 0, buffer.Length) != 0)
            {
                dest.Write(buffer, 0, buffer.Length);
                short num2 = (short)Math.Ceiling(((double)this._lastStream + (double)zlibStream.TotalIn) / (double)this._srcsize * 100.0);
                if ((int)num1 != (int)num2)
                {
                    num1 = num2;
                    this.OnUnpackProgressChanged(new ProgressChangedEventArgs((int)num2));
                    this.OnUnpackAndSplitProgressChanged(new ProgressChangedEventArgs((int)num2 / 2));
                }
            }
            this._lastStream += zlibStream.TotalIn;
            source.Position = this._lastStream;
            zlibStream.Dispose();
        }

        protected virtual void OnSplitCompleted(EventArgs e)
        {
            EventHandler splitCompleted = this.SplitCompleted;
            if (splitCompleted != null)
            {
                splitCompleted(this, e);
            }
        }

        protected virtual void OnSplitProgressChanged(ProgressChangedEventArgs e)
        {
            EventHandler<ProgressChangedEventArgs> splitProgressChanged = this.SplitProgressChanged;
            if (splitProgressChanged != null)
            {
                splitProgressChanged(this, e);
            }
        }

        protected virtual void OnUnpackAndSplitComplete(EventArgs e)
        {
            EventHandler unpackAndSplitComplete = this.UnpackAndSplitComplete;
            if (unpackAndSplitComplete != null)
            {
                unpackAndSplitComplete(this, e);
            }
        }

        protected virtual void OnUnpackAndSplitProgressChanged(ProgressChangedEventArgs e)
        {
            EventHandler<ProgressChangedEventArgs> unpackAndSplitProgressChanged = this.UnpackAndSplitProgressChanged;
            if (unpackAndSplitProgressChanged != null)
            {
                unpackAndSplitProgressChanged(this, e);
            }
        }

        protected virtual void OnUnpackCompleted(EventArgs e)
        {
            EventHandler unpackCompleted = this.UnpackCompleted;
            if (unpackCompleted != null)
            {
                unpackCompleted(this, e);
            }
        }

        protected virtual void OnUnpackProgressChanged(ProgressChangedEventArgs e)
        {
            EventHandler<ProgressChangedEventArgs> unpackProgressChanged = this.UnpackProgressChanged;
            if (unpackProgressChanged != null)
            {
                unpackProgressChanged(this, e);
            }
        }

        private void Reinit()
        {
            this._lastStream = 0L;
            this._srcsize = 0L;
        }

        private List<FileInfo> second_pass(FILE unpackedXcp, string outDir)
        {
            this.Reinit();
            List<FileInfo> fileInfoList = new List<FileInfo>();
            Console.Write("\r\nSplitting extracted XCP in GOD format\r\n");
            long length = unpackedXcp.Length;
            byte[] buffer1 = new byte[45057];
            string str = new string(new char[256]);
            unpackedXcp.Read(buffer1, 0, 45056);
            string filePath = outDir + "\\" + Path.GetFileName(outDir);
            long num1;
            using (FILE file = new FILE(filePath, FileMode.Create, FileAccess.Write, FileShare.Read, 16384))
            {
                file.Write(buffer1, 0, 45056);
                num1 = 45056L;
                fileInfoList.Add(file.Fi);
            }
            int num2 = 0;
            byte[] buffer2 = new byte[16384];
            short num3 = 0;
            while (num1 < length)
            {
                if (!Directory.Exists(string.Format("{0}.data", (object)filePath)))
                    Directory.CreateDirectory(string.Format("{0}.data", (object)filePath));
                using (FILE file = new FILE(string.Format("{0}.data\\Data{1:D4}", (object)filePath, (object)num2), FileMode.Create, FileAccess.Write, FileShare.Read, 16384))
                {
                    for (int index = 0; index < 10404; ++index)
                    {
                        int count = num1 + 16384L >= length ? (int)(length - num1) : 16384;
                        unpackedXcp.Read(buffer2, 0, count);
                        file.Write(buffer2, 0, count);
                        num1 += (long)count;
                        short num4 = (short)Math.Ceiling((double)num1 / (double)length * 100.0);
                        if ((int)num4 != (int)num3)
                        {
                            num3 = num4;
                            this.OnSplitProgressChanged(new ProgressChangedEventArgs((int)num4));
                            this.OnUnpackAndSplitProgressChanged(new ProgressChangedEventArgs((int)num4 / 2 + 50));
                        }
                    }
                    fileInfoList.Add(file.Fi);
                    ++num2;
                }
            }
            Console.Write("\r\nFile splitting Ok\r\n");
            return fileInfoList;
        }
        public List<FileInfo> SplitXcp(bool cleanup = false, string directoryOut = null)
        {
            List<FileInfo> list2;
            FileOptions options = cleanup ? FileOptions.DeleteOnClose : FileOptions.None;
            DirectoryInfo info = (directoryOut != null) ? new DirectoryInfo(directoryOut) : new DirectoryInfo(this._fileIn.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(this._fileIn.FullName));
            try
            {
                List<FileInfo> list;
                using (FILE file = new FILE(this._fileIn.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x4000, options))
                {
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    list = this.second_pass(file, info.FullName);
                }
                this.OnSplitCompleted(new EventArgs());
                list2 = list;
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1.ToString());
                throw;
            }
            return list2;
        }

        public string DefaultPathOut =>
            this._fileIn.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(this._fileIn.Name) + ".xup";

        private static class UnpackConstant
        {
            internal const int Chunk = 0x4000;
            internal const int HeaderSize = 0xb000;
            internal const int OptBuffSize = 0x4000;
            internal const int DataSize = 0xa290000;
        }
    }
}

