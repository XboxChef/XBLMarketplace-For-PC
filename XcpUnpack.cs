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

    public enum XcpFormat
    {
        //Back to back zlib streams around an SVOD container: Games on Demand and full game demos
        Zlib,
        //A Microsoft cabinet: add-ons such as DLC, arcade games, themes and avatar items
        Cabinet,
        //A cabinet encrypted with RC4, keyed from the license a console receives for the content
        Encrypted
    }

    /// <summary>
    /// The package isn't a Games on Demand style zlib package, so it can't be unpacked here.
    /// </summary>
    public class XcpNotSupportedException : Exception
    {
        public XcpNotSupportedException(XcpFormat format, string fileName) : base(Describe(format, fileName))
        {
            Format = format;
        }

        public XcpFormat Format { get; }

        private static string Describe(XcpFormat format, string fileName)
        {
            if (format == XcpFormat.Encrypted)
                return "\"" + fileName + "\" is encrypted. Xbox Live encrypts add-ons (DLC, arcade games, themes, avatar items) " +
                       "with a key only a console licensed for them receives, so it can't be unpacked. " +
                       "Games on Demand packages aren't encrypted and can be.";
            return "\"" + fileName + "\" is an add-on package, not a Games on Demand package, so it can't be unpacked into one.";
        }
    }

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

        /// <summary>
        /// Tells unpackable packages (a zlib header) from cabinets ("MSCF") and encrypted cabinets (neither).
        /// </summary>
        public static XcpFormat DetectFormat(FileInfo file)
        {
            byte[] head = new byte[4];
            using (FileStream stream = file.OpenRead())
            {
                if (stream.Read(head, 0, head.Length) < head.Length) return XcpFormat.Encrypted;
            }
            if (head[0] == 'M' && head[1] == 'S' && head[2] == 'C' && head[3] == 'F') return XcpFormat.Cabinet;
            //zlib: deflate method with a header checksum that divides by 31 (RFC 1950)
            if ((head[0] & 0x0F) == 8 && ((head[0] << 8) | head[1]) % 31 == 0) return XcpFormat.Zlib;
            return XcpFormat.Encrypted;
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
            XcpFormat format = DetectFormat(this._fileIn);
            if (format != XcpFormat.Zlib)
            {
                throw new XcpNotSupportedException(format, this._fileIn.Name);
            }
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
                using (FILE file = new FILE(this._fileIn.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x4000, FileOptions.None))
                {
                    if (info.Exists)
                    {
                        info.Delete();
                    }
                    info2 = this.first_pass(file, info.FullName);
                }
                //Only remove the source once it unpacked, DeleteOnClose used to delete it even when unpacking failed
                if (cleanup) this._fileIn.Delete();
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
            int read;
            while ((read = zlibStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                //Writing the whole buffer padded the output with stale bytes whenever a read came up short
                dest.Write(buffer, 0, read);
                short num2 = (short)Math.Ceiling(((double)this._lastStream + (double)zlibStream.TotalIn) / (double)this._srcsize * 100.0);
                if ((int)num1 != (int)num2)
                {
                    num1 = num2;
                    this.OnUnpackProgressChanged(new ProgressChangedEventArgs((int)num2));
                    this.OnUnpackAndSplitProgressChanged(new ProgressChangedEventArgs((int)num2 / 2));
                }
            }
            long consumed = zlibStream.TotalIn;
            zlibStream.Dispose();
            //Trailing bytes that aren't a zlib stream would otherwise loop forever
            if (consumed == 0) throw new InvalidDataException("No zlib stream at offset " + this._lastStream);
            this._lastStream += consumed;
            source.Position = this._lastStream;
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
                    for (int index = 0; index < 10404 && num1 < length; ++index)
                    {
                        int count = num1 + 16384L >= length ? (int)(length - num1) : 16384;
                        int read = unpackedXcp.Read(buffer2, 0, count);
                        if (read == 0) throw new EndOfStreamException("Unpacked package ended early at " + num1);
                        file.Write(buffer2, 0, read);
                        num1 += (long)read;
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
            DirectoryInfo info = (directoryOut != null) ? new DirectoryInfo(directoryOut) : new DirectoryInfo(this._fileIn.DirectoryName + @"\" + Path.GetFileNameWithoutExtension(this._fileIn.FullName));
            try
            {
                List<FileInfo> list;
                using (FILE file = new FILE(this._fileIn.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 0x4000, FileOptions.None))
                {
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    list = this.second_pass(file, info.FullName);
                }
                if (cleanup) this._fileIn.Delete();
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

