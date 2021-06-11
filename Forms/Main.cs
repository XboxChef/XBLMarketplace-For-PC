// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Forms.Main
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using ComponentOwl.BetterListView;
using God2Iso;
using God2Iso.Types;
using JasonNS.Components;
using JasonNS.Forms;
using JasonNS.GenericFunctions;
using JasonNS.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main : Form
    {


        private void converter_init()
        {
            _xcpList = new ThreadedBindingList<XcpInstance>();
            _godList = new ThreadedBindingList<GameOnDemand>();
            _isoList = new ThreadedBindingList<IsoInstance>();
            xcptogod_blvex.DataSource = _xcpList;
            godtoiso_blvex.DataSource = _godList;
        }

        private void xcptogod_Add_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                CheckFileExists = true,
                DereferenceLinks = true,
                Multiselect = false,
                InitialDirectory = BindingStrings.Instance.DownloadPath,
                Filter = "Xbox Package(*.xcp;*.xup) |*.xcp;*.xup| All files(*.*) | *.*",
                Title = "Open File..."
            };
            using (OpenFileDialog openFileDialog2 = openFileDialog1)
            {
                if (openFileDialog2.ShowDialog() != DialogResult.OK)
                    return;
                _xcpList.Add(new XcpInstance(openFileDialog2.FileName, BindingStrings.Instance.DecompressPath, Main.ConverterOptions.autostart, Main.ConverterOptions.cleanup, null));
            }
        }

        private void xcptogod_Remove_btn_Click(object sender, EventArgs e) => throw new NotImplementedException();

        private void xcptogod_Unpack_btn_Click(object sender, EventArgs e)
        {
            XcpInstance xcp = (XcpInstance)xcptogod_blvex.SelectedValue;
            if (xcp == null)
            {
                int num = (int)MessageBox.Show("Please Select a Game to Unpack", "Alert");
            }
            else
                Task.Run(() =>
               {
                   if (string.Compare(Path.GetExtension(xcp.InFile), ".xcp", StringComparison.OrdinalIgnoreCase) == 0)
                   {
                       xcp.UnpackAndSplitComplete += new EventHandler(Xcp_UnpackAndSplitComplete);
                       xcp.FullExtract();
                   }
                   else
                   {
                       if (string.Compare(Path.GetExtension(xcp.InFile), ".xup", StringComparison.OrdinalIgnoreCase) != 0)
                           return;
                       xcp.UnpackCompleted += new EventHandler(Xcp_UnpackCompleted);
                       xcp.Split();
                   }
               }).ContinueWith(prevTask =>
       {
           if (prevTask.Exception != null)
               throw prevTask.Exception;
           if (xcp.GodInstance == null)
               return;
           _godList.Add(xcp.GodInstance);
           _xcpList.Remove(xcp);
       });
        }

        private void xcptogod_RemoveFinished_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (BetterListViewItem betterListViewItem in xcptogod_blvex.Items.Where<BetterListViewItem>(obj => ((XcpInstance)obj.Value).GodInstance != null).ToList<BetterListViewItem>())
                    xcptogod_blvex.Items.Remove(betterListViewItem);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void xcptogod_UnpackAll_btn_Click(object sender, EventArgs e) => throw new NotImplementedException();

        private void xcptogod_cancel_btn_Click(object sender, EventArgs e) => throw new NotImplementedException();

        private void godtoiso_Add_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                CheckFileExists = true,
                DereferenceLinks = true,
                Multiselect = false,
                InitialDirectory = BindingStrings.Instance.DecompressPath,
                Filter = "Pirs Header|",
                Title = "Open File..."
            };
            using (OpenFileDialog openFileDialog2 = openFileDialog1)
            {
                if (openFileDialog2.ShowDialog() != DialogResult.OK)
                    return;
                _godList.Add(new GameOnDemand(new Pirs(openFileDialog2.FileName)));
            }
        }

        private void godtoiso_Remove_btn_Click(object sender, EventArgs e)
        {
            GameOnDemand selectedValue = (GameOnDemand)godtoiso_blvex.SelectedValue;
            if (selectedValue != null && selectedValue.Status == PackageStatus.Canceled || selectedValue != null && selectedValue.Status == PackageStatus.Invalid || selectedValue != null && selectedValue.Status == PackageStatus.Errored)
            {
                _godList.Remove(selectedValue);
            }
            else
            {
                int num = (int)MessageBox.Show("Unable to remove. Status must be 'Waiting'.", "Alert");
            }
        }

        private void godtoiso_CreateIso_btn_Click(object sender, EventArgs e)
        {
            GameOnDemand god = (GameOnDemand)godtoiso_blvex.SelectedValue;
            if (god == null)
            {
                int num = (int)MessageBox.Show("Please Select a Game to Convert", "Alert");
            }
            else
                Task.Run(() => god.CreateIso(BindingStrings.Instance.IsoPath, Main.ConverterOptions.fixcbHeader)).ContinueWith(prevTask =>
              {
                  if (prevTask.Exception != null)
                      throw prevTask.Exception;
              });
        }

        private void godtoiso_RemoveFinished_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (BetterListViewItem betterListViewItem in godtoiso_blvex.Items.Where<BetterListViewItem>(obj =>
               {
                   GameOnDemand gameOnDemand = (GameOnDemand)obj.Value;
                   return gameOnDemand.Status == PackageStatus.Canceled || gameOnDemand.Status == PackageStatus.Finished || gameOnDemand.Status == PackageStatus.Errored;
               }).ToList<BetterListViewItem>())
                    godtoiso_blvex.Items.Remove(betterListViewItem);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void godtoiso_ConvertAll_btn_Click(object sender, EventArgs e) => throw new NotImplementedException();

        private void godtoiso_Cancel_btn_Click(object sender, EventArgs e) => throw new NotImplementedException();

        private void Xcp_UnpackAndSplitComplete(object sender, EventArgs e)
        {
            XcpInstance xcpInstance = (XcpInstance)sender;
            xcpInstance.UnpackAndSplitComplete -= new EventHandler(Xcp_UnpackAndSplitComplete);
            _xcpList.Remove(xcpInstance);
        }

        private void Xcp_UnpackCompleted(object sender, EventArgs e)
        {
            XcpInstance xcpInstance = (XcpInstance)sender;
            xcpInstance.UnpackCompleted -= new EventHandler(Xcp_UnpackCompleted);
            _xcpList.Remove(xcpInstance);
        }

        private void God_CreateIsoProgress(object sender, JasonNS.EventArguments.ProgressChangedEventArgs e) => _godList.ResetItem(_godList.IndexOf((GameOnDemand)sender));

        private void download_init()
        {
            _downloads = new ThreadedBindingList<DownloadInstance>();
            downloadmanager_blv.DataSource = _downloads;
            foreach (BetterListViewColumnHeader column in downloadmanager_blv.Columns)
                column.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void download_Contentdl_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (Main.ConverterOptions.autostart)
                _downloads.FirstOrDefault<DownloadInstance>(d => d.DLStatus == DownloadStatus.Waiting)?.StartDownload();
            DownloadInstance userState = (DownloadInstance)e.UserState;
            userState.ProgressChanged -= new DownloadProgressChangedEventHandler(download_Contentdl_ProgressChanged);
            userState.DownloadFileCompleted -= new AsyncCompletedEventHandler(download_Contentdl_DownloadFileCompleted);
            userState.CancelDownload();
            _xcpList.Add(userState.GetXcpInstance);
            userState.Dispose();
        }

        private void download_Contentdl_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            _downloads.ResetItem(_downloads.IndexOf((DownloadInstance)e.UserState));
        }

        private void marketplace_init()
        {
            _batchhandler = new BatchUrlChecker(new ThreadedBindingList<MarketPlaceContent>(), SynchronizationContext.Current);
            _content = _batchhandler._content;
            _helper.XmlDocLoaded += new EventHandler(marketplace_XmlDocChanged);
            _batchhandler.ProgressChangedEnd += new ProgressChangedEventHandler(marketplace_urlChecking_ProgressBar_Progress);

            entrys_num.Value = Settings.Default.entry_per_page;
            page_num.Maximum = Settings.Default.last_page_viewed;
            page_num.Value = Settings.Default.last_page_viewed;
            batchdelay_updown.Value = Settings.Default.batchdelay;
            cat_select.DataSource = Constants.BindingLists.Categorys;
            cat_select.DisplayMember = "name";
            cat_select.SelectedIndex = Settings.Default.mediaindex;
            _helper.MediaTypes = (MediaId)cat_select.SelectedItem;
            cat_select.SelectedIndexChanged += new EventHandler(setting_marketplace_cat_select_SelectedIndexChanged);
            reg_select.DataSource = Constants.BindingLists.Regions;
            reg_select.DisplayMember = "name";
            reg_select.SelectedIndex = Settings.Default.regionindex;
            _helper.Locales = (RegionId)reg_select.SelectedItem;
            reg_select.SelectedIndexChanged += new EventHandler(setting_marketplace_reg_select_SelectedIndexChanged);
            querylanguage_sel.DataSource = Constants.BindingLists.Languages;
            querylanguage_sel.DisplayMember = "id";
            querylanguage_sel.SelectedIndex = Settings.Default.languageindex;
            _helper.Language = (Language)querylanguage_sel.SelectedItem;
            querylanguage_sel.SelectedValueChanged += new EventHandler(setting_marketplace_querylanguage_sel_SelectedIndexChanged);
            versionval_label.Text = "Beta R2.0.0";
            _batchhandler.NetworkDelay = Convert.ToInt32(batchdelay_updown.Value);
            _helper.PageSize = entrys_num.Value.ToString();
            _helper.PageNum = page_num.Value.ToString();
            _helper.SubmitQuery();
            contentview.DataSource = _content;
            marketplace_ContentViewResize();
        }

        private void setting_marketplace_entrys_num_ValueChanged(object sender, EventArgs e)
        {
            marketplace_MaxPageUpdate();
            Settings.Default.entry_per_page = (int)entrys_num.Value;
            _helper.PageSize = entrys_num.Value.ToString();
            Settings.Default.Save();
        }

        private void setting_marketplace_page_num_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.last_page_viewed = (int)page_num.Value;
            _helper.PageNum = page_num.Value.ToString();
            Settings.Default.Save();
        }

        private void setting_marketplace_cat_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            marketplace_MaxPageUpdate();
            _helper.MediaTypes = (MediaId)cat_select.SelectedItem;
            Settings.Default.mediaindex = cat_select.SelectedIndex;
            Settings.Default.Save();
        }

        private void setting_marketplace_reg_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            _helper.Locales = (RegionId)reg_select.SelectedItem;
            Settings.Default.regionindex = reg_select.SelectedIndex;
            Settings.Default.Save();
        }

        private void setting_marketplace_querylanguage_sel_SelectedIndexChanged(
          object sender,
          EventArgs e)
        {
            _helper.Language = (Language)querylanguage_sel.SelectedItem;
            Settings.Default.languageindex = querylanguage_sel.SelectedIndex;
            Settings.Default.Save();
        }

        private void setting_marketplace_batchdelay_updown_ValueChanged(object sender, EventArgs e)
        {
            _batchhandler.NetworkDelay = Convert.ToInt32(batchdelay_updown.Value);
            Settings.Default.batchdelay = _batchhandler.NetworkDelay;
            Settings.Default.Save();
        }

        private void marketplace_XmlDocChanged(object sender, EventArgs a)
        {
            contentview.SuppressSelectionChanged();
            _content.RaiseListChangedEvents = false;
            _batchhandler.Abort();
            _content.Clear();
            XDocument xmlDoc = _helper.XmlDoc;
            if (xmlDoc != null)
            {
                foreach (XElement descendant in xmlDoc.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "entry"))
                {
                    MarketPlaceContent marketPlaceContent = new MarketPlaceContent(descendant, (Language)querylanguage_sel.SelectedItem);
                    marketPlaceContent.Load();
                    _content.Add(marketPlaceContent);
                }
                numitems_sync_label.Text = xmlDoc.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "totalItems").First<XElement>().Value;
                cat_sync_label.Text = _helper.MediaTypes.Name;
                int result;
                if (int.TryParse(numitems_sync_label.Text, out result))
                {
                    int num = (int)Math.Ceiling(result / entrys_num.Value);
                    if (num < page_num.Value)
                        page_num.Value = num;
                    page_num.Maximum = num;
                    Constants.BindingLists.Categorys[Constants.BindingLists.Categorys.IndexOf((MediaId)cat_select.SelectedItem)].TotalCount = result;
                }
            }
            _content.RaiseListChangedEvents = true;
            _content.ResetBindings();
            _batchhandler.StartUrlCheck(false);
            contentview.ResumeSelectionChanged();
        }

        private void marketplace_urlChecking_ProgressBar_Progress(
          object sender,
          System.ComponentModel.ProgressChangedEventArgs e)
        {
            urlChecking_ProgressBar.Value = e.ProgressPercentage;
        }

        private void marketplace_contentView_SelectedItemsChanged(
          object sender,
          BetterListViewSelectedItemsChangedEventArgs eventArgs)
        {
            if (InvokeRequired)
                return;
            try
            {
                _prevItem?.Tokensource?.Cancel();
            }
            catch /*(ObjectDisposedException ex)*/
            {
                _prevItem = null;
            }
            if (_prevItem != null && _content.Contains(_prevItem))
                display_pic.Image = null;
            if (contentview.SelectedValue == null)
                return;
            MarketPlaceContent item = (MarketPlaceContent)contentview.SelectedValue;
            gametitle_text.Text = item.Title;
            developer_text.Text = item.Developer;
            publisher_text.Text = item.Publisher;
            release_text.Text = item.Releasedate.ToString(CultureInfo.CurrentCulture);
            genre_text.Text = item.OffersCount;
            description_textbox.Text = item.Description;
            if (item.Thumb == null && item.Thumburl != null)
                item.InitImageAsync(item.Thumburl).ContinueWith(task =>
               {
                   if (item.Tokensource == null)
                       return;
                   display_pic.Image = task.Result;
                   item.Tokensource = null;
               }, item.Tokensource.Token);
            else if (item.Thumb != null)
                display_pic.Image = item.Thumb;
            Image image = display_pic.Image;
            _prevItem = item;
            if (item.Capabilities == null)
                extrainfo_btn.Enabled = false;
            else
                extrainfo_btn.Enabled = true;
        }

        private void marketplace_MaxPageUpdate()
        {
            if ((MediaId)cat_select.SelectedItem == null)
                return;
            int num = (int)Math.Ceiling((Constants.BindingLists.Categorys[Constants.BindingLists.Categorys.IndexOf((MediaId)cat_select.SelectedItem)].TotalCount + 1) / entrys_num.Value);
            if (num < page_num.Value)
                page_num.Value = num;
            page_num.Maximum = num;
        }

        private void marketplace_ContentViewResize()
        {
            contentview.AutoResizeColumns(BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
            contentview.Columns.ToArray<BetterListViewColumnHeader>()[1].AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void marketplace_go_btn_Click(object sender, EventArgs e)
        {
            try
            {
                cat_sync_label.Text = ((MediaId)cat_select.SelectedValue).Name;
                _helper.SubmitQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void marketplace_prev_btn_Click(object sender, EventArgs e)
        {
            if (!(page_num.Value > page_num.Minimum))
                return;
            page_num.Value -= 1M;
            marketplace_go_btn_Click(sender, e);
        }

        private void marketplace_next_btn_Click(object sender, EventArgs e)
        {
            if (!(page_num.Value < page_num.Maximum))
                return;
            page_num.Value += 1M;
            marketplace_go_btn_Click(sender, e);
        }

        private void marketplace_extrainfo_btn_Click(object sender, EventArgs e)
        {
            MarketPlaceContent selectedValue = (MarketPlaceContent)contentview?.SelectedValue;
            if (selectedValue == null)
                return;
            ExtraInformation extraInformation = new ExtraInformation();
            extraInformation.Text = extraInformation.Text + ": " + selectedValue.Title;
            extraInformation.gamecapabilityview.HeaderStyle = BetterListViewHeaderStyle.None;
            extraInformation.gamecapabilityview.DataSource = (selectedValue?.Capabilities?.GameCapabilityInfo);
            foreach (BetterListViewColumnHeader column in extraInformation.gamecapabilityview.Columns)
                column.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
            int num = (int)extraInformation.ShowDialog();
        }

        private void marketplace_generateurl_btn_Click(object sender, EventArgs e)
        {
            MarketPlaceContent selectedValue = (MarketPlaceContent)contentview?.SelectedValue;
            if (selectedValue == null)
                return;
            selectedValue.CheckDownloadUrl(false, true);
            if (selectedValue.CanDownload.IsTrue())
            {
                DisplayUrlBox displayUrlBox1 = new DisplayUrlBox();
                displayUrlBox1.gameTitle_label.Text = selectedValue.Title;
                displayUrlBox1.urldisplay_tb.Text = selectedValue.DownloadUrl;
                using (DisplayUrlBox displayUrlBox2 = displayUrlBox1)
                {
                    int num = (int)displayUrlBox2.ShowDialog();
                }
            }
            _content.ResetBindings();
        }

        private void marketplace_forceCheckList_btn_Click(object sender, EventArgs e)
        {
            _batchhandler.Abort();
            _batchhandler.StartUrlCheck(true);
        }

        private void marketplace_directdownload_btn_Click(object sender, EventArgs e)
        {
            MarketPlaceContent selectedValue = (MarketPlaceContent)contentview.SelectedValue;
            if (selectedValue == null)
                return;
            if (!selectedValue.DownloadChecked)
                selectedValue.CheckDownloadUrl(false, true);
            if (!selectedValue.CanDownload.IsTrue())
                return;
            DownloadInstance downloadInstance = new DownloadInstance(selectedValue.DownloadUrl, BindingStrings.Instance.DownloadPath + "\\" + selectedValue.Title.MakeFileSystemSafe() + ".xcp", selectedValue);
            _downloads.Add(downloadInstance);
            if (_downloads.All<DownloadInstance>(d => d.DLStatus != DownloadStatus.Downloading))
                downloadInstance.StartDownload();
            downloadInstance.ProgressChanged += new DownloadProgressChangedEventHandler(download_Contentdl_ProgressChanged);
            downloadInstance.DownloadFileCompleted += new AsyncCompletedEventHandler(download_Contentdl_DownloadFileCompleted);
        }

        private void settings_init()
        {
            decompress_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "DecompressPath");
            iso_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "IsoPath");
            download_path_tb.DataBindings.Add("Text", BindingStrings.Instance, "DownloadPath");
            BindingStrings.Instance.DecompressPath = string.IsNullOrWhiteSpace(Settings.Default.DecompressPathString) ? BindingStrings.default_decompressPath : Settings.Default.DecompressPathString;
            BindingStrings.Instance.DownloadPath = string.IsNullOrWhiteSpace(Settings.Default.DownloadPathString) ? BindingStrings.default_downloadPath : Settings.Default.DownloadPathString;
            if (!string.IsNullOrWhiteSpace(Settings.Default.IsoPathString))
                BindingStrings.Instance.IsoPath = Settings.Default.IsoPathString;
            else
                BindingStrings.Instance.IsoPath = BindingStrings.default_isoPath;
        }

        private void decompress_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.DecompressPath = JasonNS.GenericFunctions.PathHelper.BrowseForOutputFolder(BindingStrings.Instance.DecompressPath);
            decompress_path_tb_Validated(iso_path_tb, new EventArgs());
        }

        private void download_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.DownloadPath = JasonNS.GenericFunctions.PathHelper.BrowseForOutputFolder(BindingStrings.Instance.DownloadPath);
            download_path_tb_Validated(download_path_tb, new EventArgs());
        }

        private void iso_path_browse_btn_Click(object sender, EventArgs e)
        {
            BindingStrings.Instance.IsoPath = JasonNS.GenericFunctions.PathHelper.BrowseForOutputFolder(BindingStrings.Instance.IsoPath);
            iso_path_tb_Validated(iso_path_tb, new EventArgs());
        }

        private void decompress_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.IsValidPath())
                return;
            e.Cancel = true;
            textBox.Text = BindingStrings.Instance.DecompressPath;
        }

        private void download_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.IsValidPath())
                return;
            e.Cancel = true;
            textBox.Text = BindingStrings.Instance.DownloadPath;
        }

        private void iso_path_tb_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.IsValidPath())
                return;
            e.Cancel = true;
            textBox.Text = BindingStrings.Instance.IsoPath;
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

        public Main() => InitializeComponent();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Beta Version Xbox Live Marketplace PC " + Application.ProductVersion;
            marketplace_init();
            download_init();
            converter_init();
            settings_init();
        }

        private void About_btn_Click(object sender, EventArgs e)
        {
            if (ThanksBox == null || ThanksBox.IsDisposed)
            {
                ThanksBox = new AboutBox(Constants.Credits);
                ThanksBox.Show();
            }
            else
                ThanksBox.Show();
        }

        private void downloadmanager_controls_Remove_btn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (BetterListViewItem betterListViewItem in downloadmanager_blv.Items.Where<BetterListViewItem>(obj => ((DownloadInstance)obj.Value).DLStatus == DownloadStatus.Finished).ToList<BetterListViewItem>())
                    downloadmanager_blv.Items.Remove(betterListViewItem);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (contentview.Items.Count <= 0)
                return;
            contentview.SelectedValue = contentview.Items[0].Value;
        }



        public static class ConverterOptions
        {
            public static bool cleanup;
            public static bool autostart;
            public static bool fixcbHeader;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Billy wants to cancel all these games but naw not happening...");
            return;
        }
    }
}
