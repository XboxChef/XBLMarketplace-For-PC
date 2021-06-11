using System;
using System.ComponentModel;
using System.Windows.Forms;
using JasonNS.GenericFunctions;
using XBLMarketplace_For_PC.Properties;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main
    {
        private void settings_init()
        {

            #region databinding
            decompress_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "DecompressPath");

            iso_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "IsoPath");
            
            download_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "DownloadPath");
            #endregion

            #region PathSettingsLoad

            if (!string.IsNullOrWhiteSpace(Settings.Default.DecompressPathString))
                BindingStrings.Instance.DecompressPath = Settings.Default.DecompressPathString;
            else BindingStrings.Instance.DecompressPath = BindingStrings.default_decompressPath;

            if (!string.IsNullOrWhiteSpace(Settings.Default.DownloadPathString))
                BindingStrings.Instance.DownloadPath = Settings.Default.DownloadPathString;
            else BindingStrings.Instance.DownloadPath = BindingStrings.default_downloadPath;

            if (!string.IsNullOrWhiteSpace(Settings.Default.IsoPathString))
                BindingStrings.Instance.IsoPath = Settings.Default.IsoPathString;
            else BindingStrings.Instance.IsoPath = BindingStrings.default_isoPath;

            #endregion

        }

        public static class ConverterOptions
        {
            public static bool cleanup = false;
            public static bool autostart = false;
            public static bool fixcbHeader = false;
        }

        #region outputPaths

        private void decompress_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.DecompressPath = PathHelper.BrowseForOutputFolder(BindingStrings.Instance.DecompressPath);
            decompress_path_tb_Validated(iso_path_tb, new EventArgs());
        }

        private void download_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.DownloadPath = PathHelper.BrowseForOutputFolder(BindingStrings.Instance.DownloadPath);
            download_path_tb_Validated(download_path_tb, new EventArgs());
        }

        private void iso_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.IsoPath = PathHelper.BrowseForOutputFolder(BindingStrings.Instance.IsoPath);
            iso_path_tb_Validated(iso_path_tb, new EventArgs());
        }

        private void decompress_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbox = (TextBox) sender;
            if (!tbox.Text.IsValidPath())
            {
                e.Cancel = true;
                tbox.Text = BindingStrings.Instance.DecompressPath;
                return;
            }

            /*if (!Directory.Exists(tbox.Text))
            {
                DirectoryInfo di = new DirectoryInfo(tbox.Text);
                if (!di.AskCreateFolder())
                {
                    tbox.Text = BindingStrings.Instance.DecompressPath;
                }
            }*/
        }

        private void download_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbox = (TextBox) sender;
            if (!tbox.Text.IsValidPath())
            {
                e.Cancel = true;
                tbox.Text = BindingStrings.Instance.DownloadPath;
                return;
            }

            /*if (!Directory.Exists(tbox.Text))
            {
                DirectoryInfo di = new DirectoryInfo(tbox.Text);
                if (!di.AskCreateFolder())
                {
                    tbox.Text = BindingStrings.Instance.DownloadPath;
                }
            }*/
        }

        private void iso_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbox = (TextBox) sender;
            if (!tbox.Text.IsValidPath())
            {
                e.Cancel = true;
                tbox.Text = BindingStrings.Instance.IsoPath;
                return;
            }

            /*if (!Directory.Exists(tbox.Text))
            {
                DirectoryInfo di = new DirectoryInfo(tbox.Text);
                if (!di.AskCreateFolder())
                {
                    tbox.Text = BindingStrings.Instance.IsoPath;
                }
            }*/
        }

        private void decompress_path_tb_Validated(object sender, EventArgs e)
        {
            Settings.Default.DecompressPathString = BindingStrings.Instance.DecompressPath;
            Settings.Default.Save();
        }

        private void download_path_tb_Validated(object sender, EventArgs e)
        {
            Settings.Default.DownloadPathString = BindingStrings.Instance.DownloadPath;
            Settings.Default.Save();
        }

        private void iso_path_tb_Validated(object sender, EventArgs e)
        {
            Settings.Default.IsoPathString = BindingStrings.Instance.IsoPath;
            Settings.Default.Save();
        }

        #endregion
    }
}