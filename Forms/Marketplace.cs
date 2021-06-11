using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using ComponentOwl.BetterListView;
using JasonNS.Components;
using JasonNS.GenericFunctions;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.Properties;
using XBLMarketplace_For_PC.Structs;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main
    {
        private ThreadedBindingList<MarketPlaceContent> _content;
        private MarketPlaceContent _prevItem;

        private void marketplace_init()
        {
            _batchhandler = new BatchUrlChecker(new ThreadedBindingList<MarketPlaceContent>(), SynchronizationContext.Current);
            _content = _batchhandler._content;
            _helper.XmlDocLoaded += marketplace_XmlDocChanged;
            _batchhandler.ProgressChangedEnd += marketplace_urlChecking_ProgressBar_Progress;

            try
            {
                entrys_num.Value = Settings.Default.entry_per_page;
                page_num.Maximum = Settings.Default.last_page_viewed;
                page_num.Value = Settings.Default.last_page_viewed;
                batchdelay_updown.Value = Settings.Default.batchdelay;

                #region CategoryInit
                cat_select.DataSource = Constants.BindingLists.Categorys;
                cat_select.DisplayMember = "name";
                cat_select.SelectedIndex = Settings.Default.mediaindex;
                _helper.MediaTypes = (MediaId)cat_select.SelectedItem;
                cat_select.SelectedIndexChanged += setting_marketplace_cat_select_SelectedIndexChanged;
                #endregion
                #region RegionInit

                reg_select.DataSource = Constants.BindingLists.Regions;
                reg_select.DisplayMember = "name";
                reg_select.SelectedIndex = Settings.Default.regionindex;
                _helper.Locales = (RegionId)reg_select.SelectedItem;
                reg_select.SelectedIndexChanged += setting_marketplace_reg_select_SelectedIndexChanged;

                #endregion
                #region QueryLanguageInit

                querylanguage_sel.DataSource = Constants.BindingLists.Languages;
                querylanguage_sel.DisplayMember = "id";
                querylanguage_sel.SelectedIndex = Settings.Default.languageindex;
                _helper.Language = (Language)querylanguage_sel.SelectedItem;
                querylanguage_sel.SelectedValueChanged += setting_marketplace_querylanguage_sel_SelectedIndexChanged;

                #endregion
                #region OtherInit
                versionval_label.Text = Constants.Debug + Constants.Iteration + '.' + Constants.Majorversion + '.' + Constants.Minorversion;
                _batchhandler.NetworkDelay = Convert.ToInt32(batchdelay_updown.Value);
                #endregion
                _helper.PageSize = entrys_num.Value.ToString();
                _helper.PageNum = page_num.Value.ToString();
                _helper.SubmitQuery();
                contentview.DataSource = _content;
                marketplace_ContentViewResize();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*Anytime value is changed for number of entries, 
        Page Maximum needs to be assessed if correct or not. 
        Other wise encounters out of range error on the Page Number,
        and Website Might not return any data.
        */

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

        private void setting_marketplace_querylanguage_sel_SelectedIndexChanged(object sender, EventArgs e)
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


        void marketplace_XmlDocChanged(object sender, EventArgs a)
        {
            contentview.SuppressSelectionChanged();
            _content.RaiseListChangedEvents = false;
            _batchhandler.Abort();
            //while (!batchhandler.WorkDone) Task.Delay(10);
            _content.Clear();
            var xdoc = _helper.XmlDoc;
            if (xdoc != null)
            {
                var entries = xdoc.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "entry");
                foreach (var entry in entries)
                {
                    MarketPlaceContent tempContent = new MarketPlaceContent(entry, (Language)querylanguage_sel.SelectedItem);
                    tempContent.Load();
                    _content.Add(tempContent);
                }
                numitems_sync_label.Text = xdoc.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "totalItems").First().Value;
                cat_sync_label.Text = _helper.MediaTypes.Name;
                int numItems;
                if (Int32.TryParse(numitems_sync_label.Text, out numItems))
                {
                    int max = (int)Math.Ceiling(numItems / entrys_num.Value);
                    if (max < page_num.Value) page_num.Value = max;
                    page_num.Maximum = max;
                    Constants.BindingLists.Categorys[Constants.BindingLists.Categorys.IndexOf((MediaId)cat_select.SelectedItem)].TotalCount = numItems;
                }
            }
            _content.RaiseListChangedEvents = true;
            _content.ResetBindings();
            _batchhandler.StartUrlCheck(false);
            contentview.ResumeSelectionChanged();

        }

        private void marketplace_urlChecking_ProgressBar_Progress(object sender, ProgressChangedEventArgs e)
        {
            urlChecking_ProgressBar.Value = e.ProgressPercentage;
        }

        private void marketplace_contentView_SelectedItemsChanged(object sender, BetterListViewSelectedItemsChangedEventArgs eventArgs)
        {
            if (InvokeRequired)
                return;
            try
            {
                _prevItem?.Tokensource?.Cancel();
            }
            catch (ObjectDisposedException odex)
            {
                 _prevItem = null;
                //We can Ignore this as we are Intentionally Disposing of the Tokensource
            }

            if (_prevItem != null && _content.Contains(_prevItem))
                display_pic.Image = null;
            if (contentview.SelectedValue != null)
            {
                MarketPlaceContent item = (MarketPlaceContent)contentview.SelectedValue;
                gametitle_text.Text = item.Title;
                developer_text.Text = item.Developer;
                publisher_text.Text = item.Publisher;
                release_text.Text = item.Releasedate.ToString(CultureInfo.CurrentCulture);
                genre_text.Text = item.OffersCount;
                description_textbox.Text = item.Description;
                if (item.Thumb == null && item.Thumburl != null)
                {
                    var result = item.InitImageAsync(item.Thumburl);
                    result.ContinueWith(task =>
                    {
                        if (item.Tokensource != null)
                        {
                            display_pic.Image = task.Result;
                            item.Tokensource = null;
                        }

                    }, item.Tokensource.Token);

                }
                else if (item.Thumb != null)
                {
                    display_pic.Image = item.Thumb;
                }
                if (display_pic.Image == null) { }//todo:Load graphic for "Banner Not Found"
                _prevItem = item;

                if (item.Capabilities == null)
                {
                    extrainfo_btn.Enabled = false;
                }
                else extrainfo_btn.Enabled = true;
            }
        }

        private void marketplace_MaxPageUpdate()
        {
            if ((MediaId)cat_select.SelectedItem != null)
            {
                int numItems = Constants.BindingLists.Categorys[Constants.BindingLists.Categorys.IndexOf((MediaId)cat_select.SelectedItem)].TotalCount;
                int max = (int)Math.Ceiling((numItems + 1) / entrys_num.Value);
                if (max < page_num.Value) page_num.Value = max;
                page_num.Maximum = max;
            }
        }

        private void marketplace_ContentViewResize()
        {
            contentview.AutoResizeColumns(BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
            //column CanDownload Header is [1] in array
            contentview.Columns.ToArray()[1].AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void marketplace_go_btn_Click(object sender, EventArgs e)
        {
            try
            {
                MediaId temp = (MediaId)cat_select.SelectedValue;
                cat_sync_label.Text = temp.Name;
                _helper.SubmitQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void marketplace_prev_btn_Click(object sender, EventArgs e)
        {
            //setting_marketplace_page_num_ValueChanged(sender, e);
            if (page_num.Value > page_num.Minimum)
            {
                page_num.Value = page_num.Value - 1;
                marketplace_go_btn_Click(sender, e);
            }
        }

        private void marketplace_next_btn_Click(object sender, EventArgs e)
        {
            if (page_num.Value < page_num.Maximum)
            {
                page_num.Value = page_num.Value + 1;
                marketplace_go_btn_Click(sender, e);
            }
        }

        private void marketplace_extrainfo_btn_Click(object sender, EventArgs e)
        {
            using (ExtraInformation ei = new ExtraInformation())
            {
                var selecteditem = (MarketPlaceContent)contentview?.SelectedValue;
                if (selecteditem == null) return;
                ei.Text = ei.Text + ": " + selecteditem.Title;

                ei.gamecapabilityview.HeaderStyle = BetterListViewHeaderStyle.None;
                ei.gamecapabilityview.DataSource = selecteditem?.Capabilities?.GameCapabilityInfo;//Bug: GameCapabilityInfo Is Sometimes null,
                //Fix: Grey Out the Button (disable) When this is true;
                foreach (BetterListViewColumnHeader columnheader in ei.gamecapabilityview.Columns)
                {
                    columnheader.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
                }
                ei.Show();
            }
        }

        private void marketplace_generateurl_btn_Click(object sender, EventArgs e)
        {
            var selecteditem = (MarketPlaceContent)contentview?.SelectedValue;
            if (selecteditem == null) return;
            selecteditem.CheckDownloadUrl(false, true);
            if (selecteditem.CanDownload.IsTrue())
            {
                using (DisplayUrlBox urlbox = new DisplayUrlBox
                {
                    gameTitle_label = { Text = selecteditem.Title },
                    urldisplay_tb = { Text = selecteditem.DownloadUrl }
                }) urlbox.Show();
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
            //Todo:Rewrite marketplace_directdownload_btn_Click to not Lock Thread
            //Will Lock thread a few moments If Dl has not been checked
            var selecteditem = (MarketPlaceContent)contentview.SelectedValue;
            if (selecteditem == null) return;
            if (!selecteditem.DownloadChecked) selecteditem.CheckDownloadUrl(false, true);
            if (selecteditem.CanDownload.IsTrue())
            {
                DownloadInstance contentdl = new DownloadInstance(selecteditem.DownloadUrl,
                    BindingStrings.Instance.DownloadPath + @"\" + selecteditem.Title.MakeFileSystemSafe() + ".xcp",
                    selecteditem);
                _downloads.Add(contentdl);
                if (_downloads.All(d => d.DLStatus != DownloadStatus.Downloading))
                {
                    contentdl.StartDownload();
                }
                contentdl.ProgressChanged += download_Contentdl_ProgressChanged;
                contentdl.DownloadFileCompleted += download_Contentdl_DownloadFileCompleted;
                downloadmanager_blv.AutoResizeColumn(0, BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }
    }
}
