using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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
        private UiBindingList<MarketPlaceContent> _content;
        private MarketPlaceContent _prevItem;
        private bool _firstPageShown;
        private readonly CatalogSearch _search = new CatalogSearch();
        //Bumped by every page load and search, so only the latest one fills the list
        private int _viewVersion;

        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private void marketplace_init()
        {
            _batchhandler = new BatchUrlChecker(new UiBindingList<MarketPlaceContent>());
            _content = _batchhandler._content;
            _helper.XmlDocLoaded += marketplace_XmlDocChanged;
            _batchhandler.ProgressChanged += marketplace_LinkCheck_ProgressChanged;
            _batchhandler.ItemChecked += marketplace_LinkCheck_ItemChecked;

            try
            {
                entrys_num.Value = Settings.Default.entry_per_page;
                page_num.Maximum = Settings.Default.last_page_viewed;
                page_num.Value = Settings.Default.last_page_viewed;
                //Batch Delay 0 used to switch automatic checking off, carry that over once
                if (Settings.Default.batchdelay == 0)
                {
                    Settings.Default.check_parallelism = 0;
                    Settings.Default.batchdelay = 2;
                    Settings.Default.Save();
                }
                checks_updown.Value = Math.Min(Math.Max(Settings.Default.check_parallelism, 0), (int)checks_updown.Maximum);
                cachedays_updown.Value = Settings.Default.catalog_cache_days;
                _helper.CacheMaxAge = TimeSpan.FromDays(Settings.Default.catalog_cache_days);

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
                #region UserAgentInit

                useragent_sel.DataSource = Constants.BindingLists.UserAgents;
                useragent_sel.DisplayMember = "Name";
                int savedAgent = Constants.BindingLists.UserAgents.FindIndex(u => u.Value == Settings.Default.useragent);
                useragent_sel.SelectedIndex = savedAgent >= 0 ? savedAgent : 0;
                Constants.NetworkConnectivity.Useragent = ((UserAgent)useragent_sel.SelectedItem).Value;
                useragent_sel.SelectedIndexChanged += setting_marketplace_useragent_sel_SelectedIndexChanged;

                #endregion
                #region OtherInit
                versionval_label.Text = Constants.Debug + Constants.Iteration + '.' + Constants.Majorversion + '.' + Constants.Minorversion;
                _batchhandler.Parallelism = (int)checks_updown.Value;
                #endregion
                _helper.PageSize = entrys_num.Value.ToString();
                _helper.PageNum = page_num.Value.ToString();
                contentview.DataSource = _content;
                _content.ListChanged += marketplace_Content_ListChanged;
                SendMessage(search_tb.Handle, EM_SETCUEBANNER, (IntPtr)1, "Search this category by title");
                marketplace_LoadPage();
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

        private void setting_marketplace_useragent_sel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Constants.NetworkConnectivity.Useragent = ((UserAgent)useragent_sel.SelectedItem).Value;
            Settings.Default.useragent = Constants.NetworkConnectivity.Useragent;
            Settings.Default.Save();
        }

        private void setting_marketplace_checks_updown_ValueChanged(object sender, EventArgs e)
        {
            _batchhandler.Parallelism = (int)checks_updown.Value;
            Settings.Default.check_parallelism = _batchhandler.Parallelism;
            Settings.Default.Save();
        }

        private void setting_marketplace_cachedays_updown_ValueChanged(object sender, EventArgs e)
        {
            _helper.CacheMaxAge = TimeSpan.FromDays((int)cachedays_updown.Value);
            Settings.Default.catalog_cache_days = (int)cachedays_updown.Value;
            Settings.Default.Save();
        }

        /// <summary>
        /// Loads the current page without blocking the UI, cached pages show up straight away.
        /// </summary>
        private async void marketplace_LoadPage()
        {
            //Leaving search results, a search still running must not replace the page
            _viewVersion++;
            marketplace_SetSearchMode(false);
            string page = page_num.Value.ToString(CultureInfo.CurrentCulture);
            catalogstatus_tssl.Text = "Loading page " + page + "…";
            try
            {
                CatalogueResult result = await _helper.SubmitQueryAsync();
                if (result == null) return; //A newer page request took over
                switch (result.Source)
                {
                    case CatalogueSource.Network:
                        catalogstatus_tssl.Text = "Page " + page + " loaded from Xbox Live";
                        break;
                    case CatalogueSource.Cache:
                        catalogstatus_tssl.Text = "Page " + page + " loaded from cache (saved " + marketplace_FormatAge(result.SavedUtc) + ")";
                        break;
                    case CatalogueSource.StaleCache:
                        catalogstatus_tssl.Text = "Xbox Live unreachable, showing page " + page + " cached " + marketplace_FormatAge(result.SavedUtc);
                        break;
                    default:
                        catalogstatus_tssl.Text = "Couldn't load page " + page + ": Xbox Live unreachable and no cached copy";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                catalogstatus_tssl.Text = "Couldn't load page " + page;
            }
        }

        private static string marketplace_FormatAge(DateTime savedUtc)
        {
            TimeSpan age = DateTime.UtcNow - savedUtc;
            if (age.TotalMinutes < 1) return "just now";
            if (age.TotalHours < 1) return (int)age.TotalMinutes + " min ago";
            if (age.TotalDays < 1) return (int)age.TotalHours + " h ago";
            return (int)age.TotalDays + (age.TotalDays < 2 ? " day ago" : " days ago");
        }


        void marketplace_XmlDocChanged(object sender, EventArgs a)
        {
            var xdoc = _helper.XmlDoc;
            marketplace_ShowEntries(xdoc?.Descendants(Constants.NetworkConnectivity.Namespaces.Atom + "entry") ?? Enumerable.Empty<XElement>(), false);
            if (xdoc != null)
            {
                numitems_sync_label.Text = xdoc.Descendants(Constants.NetworkConnectivity.Namespaces.Live + "totalItems").FirstOrDefault()?.Value;
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
        }

        /// <summary>
        /// Fills the list with catalogue entries, a page or search results, and starts checking their links.
        /// </summary>
        private void marketplace_ShowEntries(IEnumerable<XElement> entries, bool selectFirst)
        {
            contentview.SuppressSelectionChanged();
            _content.RaiseListChangedEvents = false;
            _batchhandler.Abort();
            _content.Clear();
            foreach (var entry in entries)
            {
                try
                {
                    MarketPlaceContent tempContent = new MarketPlaceContent(entry, (Language)querylanguage_sel.SelectedItem);
                    tempContent.Load();
                    _content.Add(tempContent);
                }
                catch (Exception ex)
                {
                    //Skip the one entry rather than lose the whole page
                    Console.WriteLine(ex.ToString());
                }
            }
            _content.RaiseListChangedEvents = true;
            _content.ResetBindings();
            _batchhandler.StartUrlCheck(false);
            contentview.ResumeSelectionChanged();

            //Pages now arrive after the form is shown, so do the initial sizing and selection here
            if (!_firstPageShown && contentview.Items.Count > 0)
            {
                _firstPageShown = true;
                marketplace_ContentViewResize();
                selectFirst = true;
            }
            if (selectFirst && contentview.Items.Count > 0 && contentview.SelectedValue == null)
                contentview.SelectedValue = contentview.Items[0].Value;
        }

        #region Archive

        private CancellationTokenSource _archiveCancel;

        private void marketplace_archive_btn_Click(object sender, EventArgs e)
        {
            //While archiving this button stops it
            if (_archiveCancel != null)
            {
                _archiveCancel.Cancel();
                archive_btn.Enabled = false;
                return;
            }
            var item = (MarketPlaceContent)contentview.SelectedValue;
            if (item == null) return;
            marketplace_Archive(new List<MarketPlaceContent> { item });
        }

        private void marketplace_archivelist_btn_Click(object sender, EventArgs e)
        {
            if (_archiveCancel != null || _content.Count == 0) return;
            if (MessageBox.Show(this,
                    "Archive all " + _content.Count + " items in the list to" + Environment.NewLine + BindingStrings.Instance.ArchivePath + "?" +
                    Environment.NewLine + Environment.NewLine +
                    "Games on Demand packages can be several GB each. Items already archived are skipped, and an interrupted run resumes where it stopped.",
                    "Archive List", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            marketplace_Archive(_content.ToList());
        }

        private void marketplace_archiveopen_btn_Click(object sender, EventArgs e)
        {
            string root = BindingStrings.Instance.ArchivePath;
            try
            {
                Directory.CreateDirectory(root);
                Process.Start("explorer.exe", "\"" + root + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Couldn't open " + root + ": " + ex.Message, "Open Archive", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Archives the items one at a time off the UI thread, see Archiver for what is kept.
        /// </summary>
        private async void marketplace_Archive(List<MarketPlaceContent> items)
        {
            string root = BindingStrings.Instance.ArchivePath;
            string category = _helper.MediaTypes.Name;
            _archiveCancel = new CancellationTokenSource();
            CancellationToken token = _archiveCancel.Token;
            archive_btn.Text = "Stop";
            archivelist_btn.Enabled = false;
            int archived = 0, already = 0, failed = 0;
            try
            {
                for (int i = 0; i < items.Count && !token.IsCancellationRequested; i++)
                {
                    MarketPlaceContent item = items[i];
                    string prefix = items.Count > 1 ? "Archiving " + (i + 1) + " of " + items.Count + ": " : "Archiving ";
                    //Reports are posted to the UI thread, ones arriving after the run ended are dropped
                    var progress = new Progress<ArchiveProgress>(p => { if (_archiveCancel != null) archivestatus_tssl.Text = prefix + marketplace_DescribeArchive(p); });
                    try
                    {
                        if (await Task.Run(() => Archiver.Archive(item, root, category, progress, token)))
                        {
                            archived++;
                            Archiver.Log(root, category, item, "archived");
                        }
                        else already++;
                    }
                    catch (Exception ex)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Archiver.Log(root, category, item, "stopped");
                            break;
                        }
                        Console.WriteLine(ex.ToString());
                        failed++;
                        Archiver.Log(root, category, item, "failed: " + ex.Message);
                    }
                }
            }
            finally
            {
                bool stopped = token.IsCancellationRequested;
                _archiveCancel.Dispose();
                _archiveCancel = null;
                archive_btn.Text = "Archive";
                archive_btn.Enabled = true;
                archivelist_btn.Enabled = true;
                archivestatus_tssl.Text = (stopped ? "Archiving stopped, " : "") + (archived + already) + " of " + items.Count + " archived" +
                                          (already > 0 ? " (" + already + " already were)" : "") +
                                          (failed > 0 ? ", " + failed + " failed (see archive.log)" : "");
            }
        }

        private static string marketplace_DescribeArchive(ArchiveProgress p)
        {
            string text = p.Title + ": " + p.Stage;
            if (p.Total > 0) text += " " + (p.Done * 100 / p.Total) + "% of " + marketplace_FormatSize(p.Total);
            return text;
        }

        private static string marketplace_FormatSize(long bytes)
        {
            if (bytes >= 1L << 30) return (bytes / (double)(1L << 30)).ToString("0.0") + " GB";
            if (bytes >= 1L << 20) return (bytes / (double)(1L << 20)).ToString("0.0") + " MB";
            return (bytes >> 10) + " KB";
        }

        #endregion

        #region Search

        private void marketplace_search_btn_Click(object sender, EventArgs e) => marketplace_Search();

        private void marketplace_searchclear_btn_Click(object sender, EventArgs e)
        {
            search_tb.Clear();
            marketplace_LoadPage();
        }

        private void marketplace_search_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                marketplace_Search();
            }
            else if (e.KeyCode == Keys.Escape && search_tb.TextLength > 0)
            {
                e.SuppressKeyPress = true;
                marketplace_searchclear_btn_Click(sender, e);
            }
        }

        private async void marketplace_Search()
        {
            string query = search_tb.Text.Trim();
            if (query.Length == 0)
            {
                marketplace_LoadPage();
                return;
            }
            int version = ++_viewVersion;
            //A page still loading must not replace the results
            _helper.CancelPendingQuery();
            marketplace_SetSearchMode(true);
            string category = _helper.MediaTypes.Name;
            catalogstatus_tssl.Text = "Searching " + category + "…";
            //Progress is posted to the UI thread, so a late report must not overwrite the final status
            bool finished = false;
            try
            {
                var progress = new Progress<string>(s => { if (!finished && version == _viewVersion) catalogstatus_tssl.Text = s; });
                SearchResult result = await _search.SearchAsync(_helper, query, progress);
                finished = true;
                if (version != _viewVersion) return;
                marketplace_ShowEntries(result.Entries, true);
                string status = result.TotalMatches == 0
                    ? "No matches for \"" + query + "\" in " + category
                    : result.TotalMatches + (result.TotalMatches == 1 ? " match" : " matches") + " for \"" + query + "\" in " + category;
                int expected = Math.Min(result.TotalMatches, CatalogSearch.MaxResults);
                if (result.TotalMatches > expected) status += ", showing the first " + expected;
                if (result.Entries.Count < expected) status += " (" + (expected - result.Entries.Count) + " couldn't be loaded from Xbox Live)";
                if (!result.IndexComplete) status += " (part of the category couldn't be loaded)";
                catalogstatus_tssl.Text = status;
            }
            catch (Exception ex)
            {
                finished = true;
                Console.WriteLine(ex.ToString());
                if (version == _viewVersion) catalogstatus_tssl.Text = "Search failed: " + ex.Message;
            }
        }

        //Paging doesn't apply to search results, Clear (or Esc) goes back to the pages
        private void marketplace_SetSearchMode(bool searching)
        {
            prev_btn.Enabled = !searching;
            next_btn.Enabled = !searching;
            page_num.Enabled = !searching;
            go_btn.Enabled = !searching;
        }

        #endregion

        //Refreshing a row (a link check finishing) makes the list rebuild it and drop the selection, which left
        //Direct Download and Generate URL doing nothing while the details pane still showed the item
        private void marketplace_Content_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.ItemChanged || _prevItem == null || contentview.SelectedValue != null) return;
            if (e.NewIndex < 0 || e.NewIndex >= _content.Count || !ReferenceEquals(_content[e.NewIndex], _prevItem)) return;
            contentview.SelectedValue = _prevItem;
        }

        private void marketplace_LinkCheck_ProgressChanged(object sender, CheckProgressEventArgs e)
        {
            urlChecking_ProgressBar.Value = e.Percent;
            if (e.Done < e.Total && e.AutoCheckOff)
                linkstatus_tssl.Text = (e.Total - e.Done) + " unchecked (automatic checking is off)";
            else if (e.Done < e.Total)
                linkstatus_tssl.Text = "Checking links " + e.Done + "/" + e.Total + "…";
            else if (e.Failed > 0)
                linkstatus_tssl.Text = e.Failed + " link check" + (e.Failed == 1 ? "" : "s") + " failed, use Re-Check List to retry";
            else
                linkstatus_tssl.Text = "All links checked";
        }

        private void marketplace_LinkCheck_ItemChecked(object sender, MarketPlaceContent item)
        {
            //Keep the details pane current when the selected item's check finishes
            if (ReferenceEquals(contentview.SelectedValue, item)) genre_text.Text = item.OffersCount;
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
                        if (task.IsFaulted)
                        {
                            Console.WriteLine(task.Exception?.ToString());
                            return;
                        }
                        if (item.Tokensource != null)
                        {
                            display_pic.Image = task.Result;
                            item.Tokensource = null;
                        }

                    }, item.Tokensource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

                }
                else if (item.Thumb != null)
                {
                    display_pic.Image = item.Thumb;
                }
                if (display_pic.Image == null) { }//todo:Load graphic for "Banner Not Found"
                _prevItem = item;
                if (!item.DownloadChecked) _batchhandler.Prioritize(item);

                //Some entries carry an empty capabilities element, which used to open an empty window
                extrainfo_btn.Enabled = item.Capabilities != null && item.Capabilities.GameCapabilityInfo.Count > 0;
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
                marketplace_LoadPage();
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
                //Show() returned straight away and the using block then disposed the window
                ei.ShowDialog(this);
            }
        }

        /// <summary>
        /// Checks the item's link without blocking the UI, and says why when there's nothing to download.
        /// </summary>
        private async Task<bool> marketplace_EnsureDownloadable(MarketPlaceContent item, Button button)
        {
            button.Enabled = false;
            try
            {
                if (!await _batchhandler.CheckAsync(item))
                {
                    MessageBox.Show(this, "Couldn't reach Xbox Live to check \"" + item.Title + "\". Try again in a moment.",
                        button.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            finally
            {
                button.Enabled = true;
            }
            if (item.CanDownload.IsTrue()) return true;
            MessageBox.Show(this, "Xbox Live doesn't list a downloadable package for \"" + item.Title + "\".",
                button.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private async void marketplace_generateurl_btn_Click(object sender, EventArgs e)
        {
            var selecteditem = (MarketPlaceContent)contentview?.SelectedValue;
            if (selecteditem == null) return;
            if (!await marketplace_EnsureDownloadable(selecteditem, generateurl_btn)) return;
            using (DisplayUrlBox urlbox = new DisplayUrlBox
            {
                gameTitle_label = { Text = selecteditem.Title },
                urldisplay_tb = { Text = selecteditem.DownloadUrl }
            }) urlbox.ShowDialog(this);
        }

        private void marketplace_forceCheckList_btn_Click(object sender, EventArgs e)
        {
            _batchhandler.Abort();
            _batchhandler.StartUrlCheck(true);
        }

        private async void marketplace_directdownload_btn_Click(object sender, EventArgs e)
        {
            var selecteditem = (MarketPlaceContent)contentview.SelectedValue;
            if (selecteditem == null) return;
            if (await marketplace_EnsureDownloadable(selecteditem, directdownload_btn))
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
