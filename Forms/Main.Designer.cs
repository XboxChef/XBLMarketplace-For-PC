using XBLMarketplace_For_PC.FormComponents;

namespace XBLMarketplace_For_PC.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.WebWorker = new System.ComponentModel.BackgroundWorker();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.Marketplace_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslNoChange1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DownloadSpeed_tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.region_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.reg_select = new System.Windows.Forms.ComboBox();
            this.urlChecking_ProgressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.marketcontent_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.page_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.next_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.page_num = new System.Windows.Forms.NumericUpDown();
            this.go_btn = new System.Windows.Forms.Button();
            this.prev_btn = new System.Windows.Forms.Button();
            this.category_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.cat_select = new System.Windows.Forms.ComboBox();
            this.entrypp_label = new System.Windows.Forms.Label();
            this.entrys_num = new System.Windows.Forms.NumericUpDown();
            this.contentview = new XBLMarketplace_For_PC.FormComponents.BetterListViewEx();
            this.Title_BLV_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.CanDownload_BLV_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.Developer_BLV_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.contentdescription_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.gametitle_text = new System.Windows.Forms.TextBox();
            this.developer_text = new System.Windows.Forms.TextBox();
            this.publisher_text = new System.Windows.Forms.TextBox();
            this.release_text = new System.Windows.Forms.TextBox();
            this.genre_text = new System.Windows.Forms.TextBox();
            this.gametitle_label = new System.Windows.Forms.Label();
            this.developer_label = new System.Windows.Forms.Label();
            this.publisher_label = new System.Windows.Forms.Label();
            this.releasedate_label = new System.Windows.Forms.Label();
            this.genre_label = new System.Windows.Forms.Label();
            this.extrainfo_Label = new System.Windows.Forms.Label();
            this.extrainfo_btn = new System.Windows.Forms.Button();
            this.download_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.directdownload_btn = new System.Windows.Forms.Button();
            this.generateurl_btn = new System.Windows.Forms.Button();
            this.fchecklist_btn = new System.Windows.Forms.Button();
            this.description_textbox = new System.Windows.Forms.RichTextBox();
            this.display_pic = new System.Windows.Forms.PictureBox();
            this.Downloads_tabPage = new System.Windows.Forms.TabPage();
            this.Downloads_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.downloadmanager_controls_gb = new System.Windows.Forms.GroupBox();
            this.downloadmanager_controls_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.downloadmanager_controls_Remove_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downloadmanager_blv = new XBLMarketplace_For_PC.FormComponents.BetterListViewEx();
            this.Name_blv_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.Progress_blv_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.Speed_blv_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.TotalDownloaded_blv_ch = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.converter_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.xcptogod_gb = new System.Windows.Forms.GroupBox();
            this.xcptogod_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.xcptogod_cancel_btn = new System.Windows.Forms.Button();
            this.xcptogod_blvex = new XBLMarketplace_For_PC.FormComponents.BetterListViewEx();
            this.xcptogod_blvex_ch_Title = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.xcptogod_blvex_ch_Status = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.xcptogod_blvex_ch_Progress = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.xcptogod_Add_btn = new System.Windows.Forms.Button();
            this.xcptogod_Remove_btn = new System.Windows.Forms.Button();
            this.xcptogod_Unpack_btn = new System.Windows.Forms.Button();
            this.xcptogod_UnpackAll_btn = new System.Windows.Forms.Button();
            this.xcptogod_RemoveFinished_btn = new System.Windows.Forms.Button();
            this.godtoiso_gb = new System.Windows.Forms.GroupBox();
            this.godtoiso_tlp = new System.Windows.Forms.TableLayoutPanel();
            this.godtoiso_cancel_btn = new System.Windows.Forms.Button();
            this.godtoiso_blvex = new XBLMarketplace_For_PC.FormComponents.BetterListViewEx();
            this.godtoiso_blvex_ch_Title = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.godtoiso_blvex_ch_Status = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.godtoiso_blvex_ch_Progress = new XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader();
            this.godtoiso_Add_btn = new System.Windows.Forms.Button();
            this.godtoiso_Remove_btn = new System.Windows.Forms.Button();
            this.godtoiso_CreateIso_btn = new System.Windows.Forms.Button();
            this.godtoiso_RemoveFinished_btn = new System.Windows.Forms.Button();
            this.godtoiso_ConvertAll_btn = new System.Windows.Forms.Button();
            this.InfoAndSettings_tabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.extrainfo_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.filler_label6 = new System.Windows.Forms.Label();
            this.filler_label5 = new System.Windows.Forms.Label();
            this.filler_label3 = new System.Windows.Forms.Label();
            this.filler_label4 = new System.Windows.Forms.Label();
            this.filler_label2 = new System.Windows.Forms.Label();
            this.cat_label = new System.Windows.Forms.Label();
            this.filler_label1 = new System.Windows.Forms.Label();
            this.cat_sync_label = new System.Windows.Forms.Label();
            this.numofitems_label = new System.Windows.Forms.Label();
            this.numitems_sync_label = new System.Windows.Forms.Label();
            this.updateddate_label = new System.Windows.Forms.Label();
            this.updated_sync_label = new System.Windows.Forms.Label();
            this.settings_group = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.filler_label_af = new System.Windows.Forms.Label();
            this.querylanguage_sel = new System.Windows.Forms.ComboBox();
            this.filler_label_ae = new System.Windows.Forms.Label();
            this.filler_label_ad = new System.Windows.Forms.Label();
            this.filler_label_ac = new System.Windows.Forms.Label();
            this.filler_label_ab = new System.Windows.Forms.Label();
            this.filler_label_aa = new System.Windows.Forms.Label();
            this.filler_label_f = new System.Windows.Forms.Label();
            this.filler_label_e = new System.Windows.Forms.Label();
            this.filler_label_c = new System.Windows.Forms.Label();
            this.filler_label_d = new System.Windows.Forms.Label();
            this.filler_label_b = new System.Windows.Forms.Label();
            this.filler_label_a = new System.Windows.Forms.Label();
            this.setting_label_Query_Language = new System.Windows.Forms.Label();
            this.setting_label_useragent = new System.Windows.Forms.Label();
            this.setting_label_batchdelay = new System.Windows.Forms.Label();
            this.setting_label_decompressTo = new System.Windows.Forms.Label();
            this.setting_label_downloadTo = new System.Windows.Forms.Label();
            this.setting_label_IsoTo = new System.Windows.Forms.Label();
            this.useragent_sel = new System.Windows.Forms.ComboBox();
            this.batchdelay_updown = new System.Windows.Forms.NumericUpDown();
            this.batchdelay_label2 = new System.Windows.Forms.Label();
            this.decompress_path_tb = new System.Windows.Forms.TextBox();
            this.decompress_path_browse_btn = new System.Windows.Forms.Button();
            this.download_path_tb = new System.Windows.Forms.TextBox();
            this.iso_path_tb = new System.Windows.Forms.TextBox();
            this.download_path_browse_btn = new System.Windows.Forms.Button();
            this.iso_path_browse_btn = new System.Windows.Forms.Button();
            this.credits_changelog_gbox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.displayVersionLabelnomodify = new System.Windows.Forms.Label();
            this.versionval_label = new System.Windows.Forms.Label();
            this.About_btn = new System.Windows.Forms.Button();
            this.tabcontrol.SuspendLayout();
            this.Marketplace_tabPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.region_group.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.marketcontent_group.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.page_group.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.page_num)).BeginInit();
            this.category_group.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entrys_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentview)).BeginInit();
            this.contentdescription_group.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.download_group.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_pic)).BeginInit();
            this.Downloads_tabPage.SuspendLayout();
            this.Downloads_tlp.SuspendLayout();
            this.downloadmanager_controls_gb.SuspendLayout();
            this.downloadmanager_controls_tlp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.downloadmanager_blv)).BeginInit();
            this.converter_tabPage.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.xcptogod_gb.SuspendLayout();
            this.xcptogod_tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xcptogod_blvex)).BeginInit();
            this.godtoiso_gb.SuspendLayout();
            this.godtoiso_tlp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.godtoiso_blvex)).BeginInit();
            this.InfoAndSettings_tabPage.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.extrainfo_group.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.settings_group.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchdelay_updown)).BeginInit();
            this.credits_changelog_gbox.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebWorker
            // 
            this.WebWorker.WorkerReportsProgress = true;
            this.WebWorker.WorkerSupportsCancellation = true;
            // 
            // tabcontrol
            // 
            this.tabcontrol.Controls.Add(this.Marketplace_tabPage);
            this.tabcontrol.Controls.Add(this.Downloads_tabPage);
            this.tabcontrol.Controls.Add(this.converter_tabPage);
            this.tabcontrol.Controls.Add(this.InfoAndSettings_tabPage);
            this.tabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabcontrol.Location = new System.Drawing.Point(0, 0);
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(946, 536);
            this.tabcontrol.TabIndex = 0;
            // 
            // Marketplace_tabPage
            // 
            this.Marketplace_tabPage.Controls.Add(this.tableLayoutPanel2);
            this.Marketplace_tabPage.Location = new System.Drawing.Point(4, 22);
            this.Marketplace_tabPage.Name = "Marketplace_tabPage";
            this.Marketplace_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Marketplace_tabPage.Size = new System.Drawing.Size(938, 510);
            this.Marketplace_tabPage.TabIndex = 0;
            this.Marketplace_tabPage.Text = "Marketplace";
            this.Marketplace_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.region_group, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(932, 504);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslNoChange1,
            this.DownloadSpeed_tssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(932, 20);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslNoChange1
            // 
            this.tsslNoChange1.Name = "tsslNoChange1";
            this.tsslNoChange1.Size = new System.Drawing.Size(99, 15);
            this.tsslNoChange1.Text = "Download Speed:";
            // 
            // DownloadSpeed_tssl
            // 
            this.DownloadSpeed_tssl.Name = "DownloadSpeed_tssl";
            this.DownloadSpeed_tssl.Size = new System.Drawing.Size(115, 15);
            this.DownloadSpeed_tssl.Text = "DownloadSpeed_tssl";
            // 
            // region_group
            // 
            this.region_group.Controls.Add(this.tableLayoutPanel3);
            this.region_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.region_group.Location = new System.Drawing.Point(3, 435);
            this.region_group.Name = "region_group";
            this.region_group.Size = new System.Drawing.Size(926, 46);
            this.region_group.TabIndex = 0;
            this.region_group.TabStop = false;
            this.region_group.Text = "Region";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.reg_select, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.urlChecking_ProgressBar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(920, 27);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // reg_select
            // 
            this.reg_select.Dock = System.Windows.Forms.DockStyle.Left;
            this.reg_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reg_select.FormattingEnabled = true;
            this.reg_select.Location = new System.Drawing.Point(3, 3);
            this.reg_select.Name = "reg_select";
            this.reg_select.Size = new System.Drawing.Size(108, 21);
            this.reg_select.TabIndex = 1;
            // 
            // urlChecking_ProgressBar
            // 
            this.urlChecking_ProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlChecking_ProgressBar.Location = new System.Drawing.Point(117, 3);
            this.urlChecking_ProgressBar.Name = "urlChecking_ProgressBar";
            this.urlChecking_ProgressBar.Size = new System.Drawing.Size(800, 21);
            this.urlChecking_ProgressBar.Step = 1;
            this.urlChecking_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.urlChecking_ProgressBar.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 438F));
            this.tableLayoutPanel1.Controls.Add(this.marketcontent_group, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.contentdescription_group, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(926, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // marketcontent_group
            // 
            this.marketcontent_group.Controls.Add(this.tableLayoutPanel4);
            this.marketcontent_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketcontent_group.Location = new System.Drawing.Point(3, 3);
            this.marketcontent_group.Name = "marketcontent_group";
            this.marketcontent_group.Size = new System.Drawing.Size(482, 420);
            this.marketcontent_group.TabIndex = 0;
            this.marketcontent_group.TabStop = false;
            this.marketcontent_group.Text = "Marketplace Content";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.page_group, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.category_group, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.contentview, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(476, 401);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // page_group
            // 
            this.page_group.Controls.Add(this.tableLayoutPanel6);
            this.page_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.page_group.Location = new System.Drawing.Point(3, 322);
            this.page_group.Name = "page_group";
            this.page_group.Size = new System.Drawing.Size(470, 76);
            this.page_group.TabIndex = 2;
            this.page_group.TabStop = false;
            this.page_group.Text = "Page";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.next_btn, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.prev_btn, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(464, 57);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(281, 3);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(75, 23);
            this.next_btn.TabIndex = 1;
            this.next_btn.Text = "Next --->";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.marketplace_next_btn_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.page_num, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.go_btn, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(189, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(86, 55);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // page_num
            // 
            this.page_num.Location = new System.Drawing.Point(3, 3);
            this.page_num.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.page_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.page_num.Name = "page_num";
            this.page_num.Size = new System.Drawing.Size(80, 20);
            this.page_num.TabIndex = 2;
            this.page_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.page_num.ValueChanged += new System.EventHandler(this.setting_marketplace_page_num_ValueChanged);
            // 
            // go_btn
            // 
            this.go_btn.Location = new System.Drawing.Point(3, 29);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(80, 23);
            this.go_btn.TabIndex = 3;
            this.go_btn.Text = "Go";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.marketplace_go_btn_Click);
            // 
            // prev_btn
            // 
            this.prev_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prev_btn.Location = new System.Drawing.Point(108, 3);
            this.prev_btn.Name = "prev_btn";
            this.prev_btn.Size = new System.Drawing.Size(75, 23);
            this.prev_btn.TabIndex = 0;
            this.prev_btn.Text = "<--- Previous";
            this.prev_btn.UseVisualStyleBackColor = true;
            this.prev_btn.Click += new System.EventHandler(this.marketplace_prev_btn_Click);
            // 
            // category_group
            // 
            this.category_group.Controls.Add(this.tableLayoutPanel10);
            this.category_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.category_group.Location = new System.Drawing.Point(3, 3);
            this.category_group.Name = "category_group";
            this.category_group.Size = new System.Drawing.Size(470, 47);
            this.category_group.TabIndex = 0;
            this.category_group.TabStop = false;
            this.category_group.Text = "Category";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.81572F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.18428F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 295F));
            this.tableLayoutPanel10.Controls.Add(this.cat_select, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.entrypp_label, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.entrys_num, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(464, 28);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // cat_select
            // 
            this.cat_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cat_select.FormattingEnabled = true;
            this.cat_select.Location = new System.Drawing.Point(3, 3);
            this.cat_select.MaxDropDownItems = 99;
            this.cat_select.Name = "cat_select";
            this.cat_select.Size = new System.Drawing.Size(115, 21);
            this.cat_select.TabIndex = 0;
            // 
            // entrypp_label
            // 
            this.entrypp_label.AutoSize = true;
            this.entrypp_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entrypp_label.Location = new System.Drawing.Point(124, 0);
            this.entrypp_label.Name = "entrypp_label";
            this.entrypp_label.Size = new System.Drawing.Size(41, 28);
            this.entrypp_label.TabIndex = 2;
            this.entrypp_label.Text = "Entry Per Page:";
            this.entrypp_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // entrys_num
            // 
            this.entrys_num.Location = new System.Drawing.Point(171, 3);
            this.entrys_num.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.entrys_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.entrys_num.Name = "entrys_num";
            this.entrys_num.Size = new System.Drawing.Size(114, 20);
            this.entrys_num.TabIndex = 3;
            this.entrys_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.entrys_num.ValueChanged += new System.EventHandler(this.setting_marketplace_entrys_num_ValueChanged);
            // 
            // contentview
            // 
            this.contentview.AllowAutoScroll = false;
            this.contentview.AllowAutoToolTips = false;
            this.contentview.AutoSizeItemsInDetailsView = true;
            this.contentview.Columns.Add(this.Title_BLV_ch);
            this.contentview.Columns.Add(this.CanDownload_BLV_ch);
            this.contentview.Columns.Add(this.Developer_BLV_ch);
            this.contentview.DataBindPosition = false;
            this.contentview.DisplayMember = "Title";
            this.contentview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentview.HotTracking = ComponentOwl.BetterListView.BetterListViewHotTracking.None;
            this.contentview.Location = new System.Drawing.Point(3, 56);
            this.contentview.MultiSelect = false;
            this.contentview.Name = "contentview";
            this.contentview.Size = new System.Drawing.Size(470, 260);
            this.contentview.SubItemFocusBehavior = ComponentOwl.BetterListView.BetterListViewSubItemFocusBehavior.None;
            this.contentview.TabIndex = 3;
            this.contentview.SelectedItemsChanged += new ComponentOwl.BetterListView.BetterListViewSelectedItemsChangedEventHandler(this.marketplace_contentView_SelectedItemsChanged);
            // 
            // Title_BLV_ch
            // 
            this.Title_BLV_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.Title_BLV_ch.DisplayMember = "Title";
            this.Title_BLV_ch.Name = "Title_BLV_ch";
            this.Title_BLV_ch.Text = "Title";
            // 
            // CanDownload_BLV_ch
            // 
            this.CanDownload_BLV_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.CanDownload_BLV_ch.DisplayMember = "CanDownload";
            this.CanDownload_BLV_ch.Name = "CanDownload_BLV_ch";
            this.CanDownload_BLV_ch.Text = "Can Download";
            // 
            // Developer_BLV_ch
            // 
            this.Developer_BLV_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.Developer_BLV_ch.DisplayMember = "Developer";
            this.Developer_BLV_ch.Name = "Developer_BLV_ch";
            this.Developer_BLV_ch.Text = "Developer";
            // 
            // contentdescription_group
            // 
            this.contentdescription_group.AutoSize = true;
            this.contentdescription_group.Controls.Add(this.tableLayoutPanel5);
            this.contentdescription_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentdescription_group.Location = new System.Drawing.Point(491, 3);
            this.contentdescription_group.Name = "contentdescription_group";
            this.contentdescription_group.Size = new System.Drawing.Size(432, 420);
            this.contentdescription_group.TabIndex = 1;
            this.contentdescription_group.TabStop = false;
            this.contentdescription_group.Text = "Content Description";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.download_group, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.description_textbox, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.display_pic, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(426, 401);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.83673F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.16327F));
            this.tableLayoutPanel8.Controls.Add(this.gametitle_text, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.developer_text, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.publisher_text, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.release_text, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.genre_text, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.gametitle_label, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.developer_label, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.publisher_label, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.releasedate_label, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.genre_label, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.extrainfo_Label, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.extrainfo_btn, 1, 5);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 6;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66623F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66887F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(420, 116);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // gametitle_text
            // 
            this.gametitle_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.gametitle_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gametitle_text.Location = new System.Drawing.Point(136, 3);
            this.gametitle_text.Name = "gametitle_text";
            this.gametitle_text.ReadOnly = true;
            this.gametitle_text.Size = new System.Drawing.Size(281, 20);
            this.gametitle_text.TabIndex = 0;
            this.gametitle_text.Text = "Undefined";
            // 
            // developer_text
            // 
            this.developer_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.developer_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.developer_text.Location = new System.Drawing.Point(136, 22);
            this.developer_text.Name = "developer_text";
            this.developer_text.ReadOnly = true;
            this.developer_text.Size = new System.Drawing.Size(281, 20);
            this.developer_text.TabIndex = 1;
            this.developer_text.Text = "Undefined";
            // 
            // publisher_text
            // 
            this.publisher_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.publisher_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisher_text.Location = new System.Drawing.Point(136, 41);
            this.publisher_text.Name = "publisher_text";
            this.publisher_text.ReadOnly = true;
            this.publisher_text.Size = new System.Drawing.Size(281, 20);
            this.publisher_text.TabIndex = 2;
            this.publisher_text.Text = "Undefined";
            // 
            // release_text
            // 
            this.release_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.release_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.release_text.Location = new System.Drawing.Point(136, 60);
            this.release_text.Name = "release_text";
            this.release_text.ReadOnly = true;
            this.release_text.Size = new System.Drawing.Size(281, 20);
            this.release_text.TabIndex = 3;
            this.release_text.Text = "Undefined";
            // 
            // genre_text
            // 
            this.genre_text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.genre_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genre_text.Location = new System.Drawing.Point(136, 79);
            this.genre_text.Name = "genre_text";
            this.genre_text.ReadOnly = true;
            this.genre_text.Size = new System.Drawing.Size(281, 20);
            this.genre_text.TabIndex = 4;
            this.genre_text.Text = "Undefined";
            // 
            // gametitle_label
            // 
            this.gametitle_label.AutoSize = true;
            this.gametitle_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gametitle_label.Location = new System.Drawing.Point(3, 0);
            this.gametitle_label.Name = "gametitle_label";
            this.gametitle_label.Size = new System.Drawing.Size(127, 19);
            this.gametitle_label.TabIndex = 5;
            this.gametitle_label.Text = "Game Title :";
            this.gametitle_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // developer_label
            // 
            this.developer_label.AutoSize = true;
            this.developer_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.developer_label.Location = new System.Drawing.Point(3, 19);
            this.developer_label.Name = "developer_label";
            this.developer_label.Size = new System.Drawing.Size(127, 19);
            this.developer_label.TabIndex = 6;
            this.developer_label.Text = "Developer :";
            this.developer_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // publisher_label
            // 
            this.publisher_label.AutoSize = true;
            this.publisher_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.publisher_label.Location = new System.Drawing.Point(3, 38);
            this.publisher_label.Name = "publisher_label";
            this.publisher_label.Size = new System.Drawing.Size(127, 19);
            this.publisher_label.TabIndex = 7;
            this.publisher_label.Text = "Publisher :";
            this.publisher_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // releasedate_label
            // 
            this.releasedate_label.AutoSize = true;
            this.releasedate_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.releasedate_label.Location = new System.Drawing.Point(3, 57);
            this.releasedate_label.Name = "releasedate_label";
            this.releasedate_label.Size = new System.Drawing.Size(127, 19);
            this.releasedate_label.TabIndex = 8;
            this.releasedate_label.Text = "Release Date :";
            this.releasedate_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // genre_label
            // 
            this.genre_label.AutoSize = true;
            this.genre_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genre_label.Location = new System.Drawing.Point(3, 76);
            this.genre_label.Name = "genre_label";
            this.genre_label.Size = new System.Drawing.Size(127, 19);
            this.genre_label.TabIndex = 9;
            this.genre_label.Text = "Title Offers:";
            this.genre_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // extrainfo_Label
            // 
            this.extrainfo_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extrainfo_Label.Location = new System.Drawing.Point(3, 95);
            this.extrainfo_Label.Name = "extrainfo_Label";
            this.extrainfo_Label.Size = new System.Drawing.Size(127, 21);
            this.extrainfo_Label.TabIndex = 10;
            this.extrainfo_Label.Text = "Extra Information: ";
            this.extrainfo_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // extrainfo_btn
            // 
            this.extrainfo_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extrainfo_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.extrainfo_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.extrainfo_btn.Location = new System.Drawing.Point(136, 98);
            this.extrainfo_btn.Name = "extrainfo_btn";
            this.extrainfo_btn.Size = new System.Drawing.Size(281, 15);
            this.extrainfo_btn.TabIndex = 11;
            this.extrainfo_btn.Text = "Show Extra Information";
            this.extrainfo_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.extrainfo_btn.UseVisualStyleBackColor = true;
            this.extrainfo_btn.Click += new System.EventHandler(this.marketplace_extrainfo_btn_Click);
            // 
            // download_group
            // 
            this.download_group.AutoSize = true;
            this.download_group.Controls.Add(this.tableLayoutPanel9);
            this.download_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.download_group.Location = new System.Drawing.Point(3, 350);
            this.download_group.Name = "download_group";
            this.download_group.Size = new System.Drawing.Size(420, 48);
            this.download_group.TabIndex = 2;
            this.download_group.TabStop = false;
            this.download_group.Text = "Download Content";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 3;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel9.Controls.Add(this.directdownload_btn, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.generateurl_btn, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.fchecklist_btn, 2, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(414, 29);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // directdownload_btn
            // 
            this.directdownload_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directdownload_btn.Location = new System.Drawing.Point(35, 3);
            this.directdownload_btn.Name = "directdownload_btn";
            this.directdownload_btn.Size = new System.Drawing.Size(110, 23);
            this.directdownload_btn.TabIndex = 0;
            this.directdownload_btn.Text = "Direct Download";
            this.directdownload_btn.UseVisualStyleBackColor = true;
            this.directdownload_btn.Click += new System.EventHandler(this.marketplace_directdownload_btn_Click);
            // 
            // generateurl_btn
            // 
            this.generateurl_btn.Location = new System.Drawing.Point(151, 3);
            this.generateurl_btn.Name = "generateurl_btn";
            this.generateurl_btn.Size = new System.Drawing.Size(110, 23);
            this.generateurl_btn.TabIndex = 1;
            this.generateurl_btn.Text = "Generate URL";
            this.generateurl_btn.UseVisualStyleBackColor = true;
            this.generateurl_btn.Click += new System.EventHandler(this.marketplace_generateurl_btn_Click);
            // 
            // fchecklist_btn
            // 
            this.fchecklist_btn.AutoSize = true;
            this.fchecklist_btn.Location = new System.Drawing.Point(267, 3);
            this.fchecklist_btn.Name = "fchecklist_btn";
            this.fchecklist_btn.Size = new System.Drawing.Size(110, 23);
            this.fchecklist_btn.TabIndex = 2;
            this.fchecklist_btn.Text = "Re-Check List";
            this.fchecklist_btn.UseVisualStyleBackColor = true;
            this.fchecklist_btn.Click += new System.EventHandler(this.marketplace_forceCheckList_btn_Click);
            // 
            // description_textbox
            // 
            this.description_textbox.DetectUrls = false;
            this.description_textbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.description_textbox.HideSelection = false;
            this.description_textbox.Location = new System.Drawing.Point(3, 226);
            this.description_textbox.Name = "description_textbox";
            this.description_textbox.ReadOnly = true;
            this.description_textbox.Size = new System.Drawing.Size(420, 118);
            this.description_textbox.TabIndex = 3;
            this.description_textbox.Text = "";
            // 
            // display_pic
            // 
            this.display_pic.BackColor = System.Drawing.Color.Transparent;
            this.display_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.display_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.display_pic.ErrorImage = null;
            this.display_pic.InitialImage = null;
            this.display_pic.Location = new System.Drawing.Point(3, 3);
            this.display_pic.Name = "display_pic";
            this.display_pic.Size = new System.Drawing.Size(420, 95);
            this.display_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.display_pic.TabIndex = 0;
            this.display_pic.TabStop = false;
            // 
            // Downloads_tabPage
            // 
            this.Downloads_tabPage.Controls.Add(this.Downloads_tlp);
            this.Downloads_tabPage.Location = new System.Drawing.Point(4, 22);
            this.Downloads_tabPage.Name = "Downloads_tabPage";
            this.Downloads_tabPage.Size = new System.Drawing.Size(938, 510);
            this.Downloads_tabPage.TabIndex = 2;
            this.Downloads_tabPage.Text = "Downloads";
            this.Downloads_tabPage.UseVisualStyleBackColor = true;
            // 
            // Downloads_tlp
            // 
            this.Downloads_tlp.ColumnCount = 3;
            this.Downloads_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Downloads_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Downloads_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Downloads_tlp.Controls.Add(this.downloadmanager_controls_gb, 2, 0);
            this.Downloads_tlp.Controls.Add(this.groupBox1, 0, 0);
            this.Downloads_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Downloads_tlp.Location = new System.Drawing.Point(0, 0);
            this.Downloads_tlp.Name = "Downloads_tlp";
            this.Downloads_tlp.RowCount = 1;
            this.Downloads_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Downloads_tlp.Size = new System.Drawing.Size(938, 510);
            this.Downloads_tlp.TabIndex = 1;
            // 
            // downloadmanager_controls_gb
            // 
            this.downloadmanager_controls_gb.AutoSize = true;
            this.downloadmanager_controls_gb.Controls.Add(this.downloadmanager_controls_tlp);
            this.downloadmanager_controls_gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadmanager_controls_gb.Location = new System.Drawing.Point(839, 3);
            this.downloadmanager_controls_gb.Name = "downloadmanager_controls_gb";
            this.downloadmanager_controls_gb.Size = new System.Drawing.Size(96, 504);
            this.downloadmanager_controls_gb.TabIndex = 1;
            this.downloadmanager_controls_gb.TabStop = false;
            this.downloadmanager_controls_gb.Text = "Controls";
            // 
            // downloadmanager_controls_tlp
            // 
            this.downloadmanager_controls_tlp.AutoSize = true;
            this.downloadmanager_controls_tlp.ColumnCount = 1;
            this.downloadmanager_controls_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.downloadmanager_controls_tlp.Controls.Add(this.downloadmanager_controls_Remove_btn, 0, 0);
            this.downloadmanager_controls_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadmanager_controls_tlp.Location = new System.Drawing.Point(3, 16);
            this.downloadmanager_controls_tlp.Name = "downloadmanager_controls_tlp";
            this.downloadmanager_controls_tlp.RowCount = 2;
            this.downloadmanager_controls_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.downloadmanager_controls_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.downloadmanager_controls_tlp.Size = new System.Drawing.Size(90, 485);
            this.downloadmanager_controls_tlp.TabIndex = 0;
            // 
            // downloadmanager_controls_Remove_btn
            // 
            this.downloadmanager_controls_Remove_btn.AutoSize = true;
            this.downloadmanager_controls_Remove_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadmanager_controls_Remove_btn.Location = new System.Drawing.Point(3, 3);
            this.downloadmanager_controls_Remove_btn.Name = "downloadmanager_controls_Remove_btn";
            this.downloadmanager_controls_Remove_btn.Size = new System.Drawing.Size(84, 20);
            this.downloadmanager_controls_Remove_btn.TabIndex = 0;
            this.downloadmanager_controls_Remove_btn.Text = "Clear Finished";
            this.downloadmanager_controls_Remove_btn.UseVisualStyleBackColor = true;
            this.downloadmanager_controls_Remove_btn.Click += new System.EventHandler(this.downloadmanager_controls_Remove_btn_Click);
            // 
            // groupBox1
            // 
            this.Downloads_tlp.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.downloadmanager_blv);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 504);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download Manager";
            // 
            // downloadmanager_blv
            // 
            this.downloadmanager_blv.Columns.Add(this.Name_blv_ch);
            this.downloadmanager_blv.Columns.Add(this.Progress_blv_ch);
            this.downloadmanager_blv.Columns.Add(this.Speed_blv_ch);
            this.downloadmanager_blv.Columns.Add(this.TotalDownloaded_blv_ch);
            this.downloadmanager_blv.DataBindPosition = false;
            this.downloadmanager_blv.DisplayMember = "DisplayName";
            this.downloadmanager_blv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadmanager_blv.Location = new System.Drawing.Point(3, 16);
            this.downloadmanager_blv.MultiSelect = false;
            this.downloadmanager_blv.Name = "downloadmanager_blv";
            this.downloadmanager_blv.Size = new System.Drawing.Size(824, 485);
            this.downloadmanager_blv.SortOnCollectionChange = false;
            this.downloadmanager_blv.TabIndex = 0;
            // 
            // Name_blv_ch
            // 
            this.Name_blv_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.Name_blv_ch.DisplayMember = "DisplayName";
            this.Name_blv_ch.Name = "Name_blv_ch";
            this.Name_blv_ch.Text = "Title";
            this.Name_blv_ch.Width = 188;
            // 
            // Progress_blv_ch
            // 
            this.Progress_blv_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.PercentDone;
            this.Progress_blv_ch.DisplayMember = "ProgressString";
            this.Progress_blv_ch.MinimumWidth = 120;
            this.Progress_blv_ch.Name = "Progress_blv_ch";
            this.Progress_blv_ch.Text = "Progress";
            this.Progress_blv_ch.ValueMember = "PackageProgress";
            this.Progress_blv_ch.Width = 120;
            // 
            // Speed_blv_ch
            // 
            this.Speed_blv_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.Speed_blv_ch.DisplayMember = "SpeedString";
            this.Speed_blv_ch.MinimumWidth = 100;
            this.Speed_blv_ch.Name = "Speed_blv_ch";
            this.Speed_blv_ch.Text = "Speed";
            this.Speed_blv_ch.Width = 100;
            // 
            // TotalDownloaded_blv_ch
            // 
            this.TotalDownloaded_blv_ch.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.TotalDownloaded_blv_ch.DisplayMember = "TotalDownloaded";
            this.TotalDownloaded_blv_ch.MinimumWidth = 145;
            this.TotalDownloaded_blv_ch.Name = "TotalDownloaded_blv_ch";
            this.TotalDownloaded_blv_ch.Text = "Total Downloaded";
            this.TotalDownloaded_blv_ch.Width = 145;
            // 
            // converter_tabPage
            // 
            this.converter_tabPage.Controls.Add(this.tableLayoutPanel17);
            this.converter_tabPage.Location = new System.Drawing.Point(4, 22);
            this.converter_tabPage.Name = "converter_tabPage";
            this.converter_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.converter_tabPage.Size = new System.Drawing.Size(938, 510);
            this.converter_tabPage.TabIndex = 3;
            this.converter_tabPage.Text = "Converter";
            this.converter_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.xcptogod_gb, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.godtoiso_gb, 0, 1);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(932, 504);
            this.tableLayoutPanel17.TabIndex = 0;
            // 
            // xcptogod_gb
            // 
            this.xcptogod_gb.Controls.Add(this.xcptogod_tlp);
            this.xcptogod_gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_gb.Location = new System.Drawing.Point(3, 3);
            this.xcptogod_gb.Name = "xcptogod_gb";
            this.xcptogod_gb.Size = new System.Drawing.Size(926, 245);
            this.xcptogod_gb.TabIndex = 0;
            this.xcptogod_gb.TabStop = false;
            this.xcptogod_gb.Text = "Xbox Compressed Package -> Decompress to Game On Demand";
            // 
            // xcptogod_tlp
            // 
            this.xcptogod_tlp.ColumnCount = 2;
            this.xcptogod_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xcptogod_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.xcptogod_tlp.Controls.Add(this.xcptogod_cancel_btn, 1, 8);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_blvex, 0, 0);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_Add_btn, 1, 1);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_Remove_btn, 1, 2);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_Unpack_btn, 1, 3);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_UnpackAll_btn, 1, 7);
            this.xcptogod_tlp.Controls.Add(this.xcptogod_RemoveFinished_btn, 1, 5);
            this.xcptogod_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_tlp.Location = new System.Drawing.Point(3, 16);
            this.xcptogod_tlp.Name = "xcptogod_tlp";
            this.xcptogod_tlp.RowCount = 9;
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.xcptogod_tlp.Size = new System.Drawing.Size(920, 226);
            this.xcptogod_tlp.TabIndex = 0;
            // 
            // xcptogod_cancel_btn
            // 
            this.xcptogod_cancel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_cancel_btn.Enabled = false;
            this.xcptogod_cancel_btn.Location = new System.Drawing.Point(820, 203);
            this.xcptogod_cancel_btn.Name = "xcptogod_cancel_btn";
            this.xcptogod_cancel_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_cancel_btn.TabIndex = 1;
            this.xcptogod_cancel_btn.Text = "Cancel";
            this.xcptogod_cancel_btn.UseVisualStyleBackColor = true;
            this.xcptogod_cancel_btn.Click += new System.EventHandler(this.xcptogod_cancel_btn_Click);
            // 
            // xcptogod_blvex
            // 
            this.xcptogod_blvex.Columns.Add(this.xcptogod_blvex_ch_Title);
            this.xcptogod_blvex.Columns.Add(this.xcptogod_blvex_ch_Status);
            this.xcptogod_blvex.Columns.Add(this.xcptogod_blvex_ch_Progress);
            this.xcptogod_blvex.DataBindPosition = false;
            this.xcptogod_blvex.DisplayMember = "DisplayName";
            this.xcptogod_blvex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_blvex.Location = new System.Drawing.Point(3, 3);
            this.xcptogod_blvex.MultiSelect = false;
            this.xcptogod_blvex.Name = "xcptogod_blvex";
            this.xcptogod_tlp.SetRowSpan(this.xcptogod_blvex, 9);
            this.xcptogod_blvex.Size = new System.Drawing.Size(811, 220);
            this.xcptogod_blvex.TabIndex = 2;
            // 
            // xcptogod_blvex_ch_Title
            // 
            this.xcptogod_blvex_ch_Title.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.xcptogod_blvex_ch_Title.DisplayMember = "DisplayName";
            this.xcptogod_blvex_ch_Title.MinimumWidth = 75;
            this.xcptogod_blvex_ch_Title.Name = "xcptogod_blvex_ch_Title";
            this.xcptogod_blvex_ch_Title.Text = "Title";
            this.xcptogod_blvex_ch_Title.Width = 300;
            // 
            // xcptogod_blvex_ch_Status
            // 
            this.xcptogod_blvex_ch_Status.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.xcptogod_blvex_ch_Status.DisplayMember = "StatusString";
            this.xcptogod_blvex_ch_Status.MinimumWidth = 75;
            this.xcptogod_blvex_ch_Status.Name = "xcptogod_blvex_ch_Status";
            this.xcptogod_blvex_ch_Status.Text = "Status";
            this.xcptogod_blvex_ch_Status.ValueMember = "Status";
            this.xcptogod_blvex_ch_Status.Width = 150;
            // 
            // xcptogod_blvex_ch_Progress
            // 
            this.xcptogod_blvex_ch_Progress.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.PercentDone;
            this.xcptogod_blvex_ch_Progress.DisplayMember = "PackageProgress";
            this.xcptogod_blvex_ch_Progress.MinimumWidth = 75;
            this.xcptogod_blvex_ch_Progress.Name = "xcptogod_blvex_ch_Progress";
            this.xcptogod_blvex_ch_Progress.Text = "Progress";
            this.xcptogod_blvex_ch_Progress.ValueMember = "PackageProgress";
            // 
            // xcptogod_Add_btn
            // 
            this.xcptogod_Add_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_Add_btn.Location = new System.Drawing.Point(820, 21);
            this.xcptogod_Add_btn.Name = "xcptogod_Add_btn";
            this.xcptogod_Add_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_Add_btn.TabIndex = 3;
            this.xcptogod_Add_btn.Text = "Add (*.xcp)";
            this.xcptogod_Add_btn.UseVisualStyleBackColor = true;
            this.xcptogod_Add_btn.Click += new System.EventHandler(this.xcptogod_Add_btn_Click);
            // 
            // xcptogod_Remove_btn
            // 
            this.xcptogod_Remove_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_Remove_btn.Enabled = false;
            this.xcptogod_Remove_btn.Location = new System.Drawing.Point(820, 47);
            this.xcptogod_Remove_btn.Name = "xcptogod_Remove_btn";
            this.xcptogod_Remove_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_Remove_btn.TabIndex = 4;
            this.xcptogod_Remove_btn.Text = "Remove";
            this.xcptogod_Remove_btn.UseVisualStyleBackColor = true;
            this.xcptogod_Remove_btn.Click += new System.EventHandler(this.xcptogod_Remove_btn_Click);
            // 
            // xcptogod_Unpack_btn
            // 
            this.xcptogod_Unpack_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_Unpack_btn.Location = new System.Drawing.Point(820, 73);
            this.xcptogod_Unpack_btn.Name = "xcptogod_Unpack_btn";
            this.xcptogod_Unpack_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_Unpack_btn.TabIndex = 5;
            this.xcptogod_Unpack_btn.Text = "Unpack";
            this.xcptogod_Unpack_btn.UseVisualStyleBackColor = true;
            this.xcptogod_Unpack_btn.Click += new System.EventHandler(this.xcptogod_Unpack_btn_Click);
            // 
            // xcptogod_UnpackAll_btn
            // 
            this.xcptogod_UnpackAll_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_UnpackAll_btn.Enabled = false;
            this.xcptogod_UnpackAll_btn.Location = new System.Drawing.Point(820, 177);
            this.xcptogod_UnpackAll_btn.Name = "xcptogod_UnpackAll_btn";
            this.xcptogod_UnpackAll_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_UnpackAll_btn.TabIndex = 6;
            this.xcptogod_UnpackAll_btn.Text = "Unpack All";
            this.xcptogod_UnpackAll_btn.UseVisualStyleBackColor = true;
            this.xcptogod_UnpackAll_btn.Click += new System.EventHandler(this.xcptogod_UnpackAll_btn_Click);
            // 
            // xcptogod_RemoveFinished_btn
            // 
            this.xcptogod_RemoveFinished_btn.AutoSize = true;
            this.xcptogod_RemoveFinished_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xcptogod_RemoveFinished_btn.Location = new System.Drawing.Point(820, 125);
            this.xcptogod_RemoveFinished_btn.Name = "xcptogod_RemoveFinished_btn";
            this.xcptogod_RemoveFinished_btn.Size = new System.Drawing.Size(97, 20);
            this.xcptogod_RemoveFinished_btn.TabIndex = 7;
            this.xcptogod_RemoveFinished_btn.Text = "Remove Finished";
            this.xcptogod_RemoveFinished_btn.UseVisualStyleBackColor = true;
            this.xcptogod_RemoveFinished_btn.Click += new System.EventHandler(this.xcptogod_RemoveFinished_btn_Click);
            // 
            // godtoiso_gb
            // 
            this.godtoiso_gb.Controls.Add(this.godtoiso_tlp);
            this.godtoiso_gb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_gb.Location = new System.Drawing.Point(3, 254);
            this.godtoiso_gb.Name = "godtoiso_gb";
            this.godtoiso_gb.Size = new System.Drawing.Size(926, 247);
            this.godtoiso_gb.TabIndex = 1;
            this.godtoiso_gb.TabStop = false;
            this.godtoiso_gb.Text = "Game On Demand -> Iso";
            // 
            // godtoiso_tlp
            // 
            this.godtoiso_tlp.ColumnCount = 2;
            this.godtoiso_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.godtoiso_tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.godtoiso_tlp.Controls.Add(this.godtoiso_cancel_btn, 1, 8);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_blvex, 0, 0);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_Add_btn, 1, 1);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_Remove_btn, 1, 2);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_CreateIso_btn, 1, 3);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_RemoveFinished_btn, 1, 5);
            this.godtoiso_tlp.Controls.Add(this.godtoiso_ConvertAll_btn, 1, 7);
            this.godtoiso_tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_tlp.Location = new System.Drawing.Point(3, 16);
            this.godtoiso_tlp.Name = "godtoiso_tlp";
            this.godtoiso_tlp.RowCount = 9;
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.godtoiso_tlp.Size = new System.Drawing.Size(920, 228);
            this.godtoiso_tlp.TabIndex = 0;
            // 
            // godtoiso_cancel_btn
            // 
            this.godtoiso_cancel_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_cancel_btn.Enabled = false;
            this.godtoiso_cancel_btn.Location = new System.Drawing.Point(820, 205);
            this.godtoiso_cancel_btn.Name = "godtoiso_cancel_btn";
            this.godtoiso_cancel_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_cancel_btn.TabIndex = 0;
            this.godtoiso_cancel_btn.Text = "Cancel";
            this.godtoiso_cancel_btn.UseVisualStyleBackColor = true;
            this.godtoiso_cancel_btn.Click += new System.EventHandler(this.godtoiso_Cancel_btn_Click);
            // 
            // godtoiso_blvex
            // 
            this.godtoiso_blvex.Columns.Add(this.godtoiso_blvex_ch_Title);
            this.godtoiso_blvex.Columns.Add(this.godtoiso_blvex_ch_Status);
            this.godtoiso_blvex.Columns.Add(this.godtoiso_blvex_ch_Progress);
            this.godtoiso_blvex.DisplayMember = "DisplayName";
            this.godtoiso_blvex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_blvex.Location = new System.Drawing.Point(3, 3);
            this.godtoiso_blvex.Name = "godtoiso_blvex";
            this.godtoiso_tlp.SetRowSpan(this.godtoiso_blvex, 9);
            this.godtoiso_blvex.Size = new System.Drawing.Size(811, 222);
            this.godtoiso_blvex.TabIndex = 2;
            // 
            // godtoiso_blvex_ch_Title
            // 
            this.godtoiso_blvex_ch_Title.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.godtoiso_blvex_ch_Title.DisplayMember = "DisplayName";
            this.godtoiso_blvex_ch_Title.MinimumWidth = 75;
            this.godtoiso_blvex_ch_Title.Name = "godtoiso_blvex_ch_Title";
            this.godtoiso_blvex_ch_Title.Text = "Title";
            this.godtoiso_blvex_ch_Title.Width = 300;
            // 
            // godtoiso_blvex_ch_Status
            // 
            this.godtoiso_blvex_ch_Status.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.Default;
            this.godtoiso_blvex_ch_Status.DisplayMember = "StatusString";
            this.godtoiso_blvex_ch_Status.MinimumWidth = 75;
            this.godtoiso_blvex_ch_Status.Name = "godtoiso_blvex_ch_Status";
            this.godtoiso_blvex_ch_Status.Text = "Status";
            this.godtoiso_blvex_ch_Status.ValueMember = "Status";
            this.godtoiso_blvex_ch_Status.Width = 150;
            // 
            // godtoiso_blvex_ch_Progress
            // 
            this.godtoiso_blvex_ch_Progress.ColumnType = XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnType.PercentDone;
            this.godtoiso_blvex_ch_Progress.DisplayMember = "PackageProgress";
            this.godtoiso_blvex_ch_Progress.MinimumWidth = 75;
            this.godtoiso_blvex_ch_Progress.Name = "godtoiso_blvex_ch_Progress";
            this.godtoiso_blvex_ch_Progress.Text = "Progress";
            this.godtoiso_blvex_ch_Progress.ValueMember = "PackageProgress";
            // 
            // godtoiso_Add_btn
            // 
            this.godtoiso_Add_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_Add_btn.Location = new System.Drawing.Point(820, 23);
            this.godtoiso_Add_btn.Name = "godtoiso_Add_btn";
            this.godtoiso_Add_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_Add_btn.TabIndex = 3;
            this.godtoiso_Add_btn.Text = "Add GOD";
            this.godtoiso_Add_btn.UseVisualStyleBackColor = true;
            this.godtoiso_Add_btn.Click += new System.EventHandler(this.godtoiso_Add_btn_Click);
            // 
            // godtoiso_Remove_btn
            // 
            this.godtoiso_Remove_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_Remove_btn.Enabled = false;
            this.godtoiso_Remove_btn.Location = new System.Drawing.Point(820, 49);
            this.godtoiso_Remove_btn.Name = "godtoiso_Remove_btn";
            this.godtoiso_Remove_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_Remove_btn.TabIndex = 4;
            this.godtoiso_Remove_btn.Text = "Remove";
            this.godtoiso_Remove_btn.UseVisualStyleBackColor = true;
            this.godtoiso_Remove_btn.Click += new System.EventHandler(this.godtoiso_Remove_btn_Click);
            // 
            // godtoiso_CreateIso_btn
            // 
            this.godtoiso_CreateIso_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_CreateIso_btn.Location = new System.Drawing.Point(820, 75);
            this.godtoiso_CreateIso_btn.Name = "godtoiso_CreateIso_btn";
            this.godtoiso_CreateIso_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_CreateIso_btn.TabIndex = 5;
            this.godtoiso_CreateIso_btn.Text = "Convert to Iso";
            this.godtoiso_CreateIso_btn.UseVisualStyleBackColor = true;
            this.godtoiso_CreateIso_btn.Click += new System.EventHandler(this.godtoiso_CreateIso_btn_Click);
            // 
            // godtoiso_RemoveFinished_btn
            // 
            this.godtoiso_RemoveFinished_btn.AutoSize = true;
            this.godtoiso_RemoveFinished_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_RemoveFinished_btn.Location = new System.Drawing.Point(820, 127);
            this.godtoiso_RemoveFinished_btn.Name = "godtoiso_RemoveFinished_btn";
            this.godtoiso_RemoveFinished_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_RemoveFinished_btn.TabIndex = 6;
            this.godtoiso_RemoveFinished_btn.Text = "Remove Finished";
            this.godtoiso_RemoveFinished_btn.UseVisualStyleBackColor = true;
            this.godtoiso_RemoveFinished_btn.Click += new System.EventHandler(this.godtoiso_RemoveFinished_btn_Click);
            // 
            // godtoiso_ConvertAll_btn
            // 
            this.godtoiso_ConvertAll_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.godtoiso_ConvertAll_btn.Enabled = false;
            this.godtoiso_ConvertAll_btn.Location = new System.Drawing.Point(820, 179);
            this.godtoiso_ConvertAll_btn.Name = "godtoiso_ConvertAll_btn";
            this.godtoiso_ConvertAll_btn.Size = new System.Drawing.Size(97, 20);
            this.godtoiso_ConvertAll_btn.TabIndex = 7;
            this.godtoiso_ConvertAll_btn.Text = "Convert All";
            this.godtoiso_ConvertAll_btn.UseVisualStyleBackColor = true;
            this.godtoiso_ConvertAll_btn.Click += new System.EventHandler(this.godtoiso_ConvertAll_btn_Click);
            // 
            // InfoAndSettings_tabPage
            // 
            this.InfoAndSettings_tabPage.Controls.Add(this.tableLayoutPanel12);
            this.InfoAndSettings_tabPage.Location = new System.Drawing.Point(4, 22);
            this.InfoAndSettings_tabPage.Name = "InfoAndSettings_tabPage";
            this.InfoAndSettings_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InfoAndSettings_tabPage.Size = new System.Drawing.Size(938, 510);
            this.InfoAndSettings_tabPage.TabIndex = 1;
            this.InfoAndSettings_tabPage.Text = "Info&Settings";
            this.InfoAndSettings_tabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Controls.Add(this.extrainfo_group, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.settings_group, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.credits_changelog_gbox, 0, 1);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.87674F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.12326F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(932, 504);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // extrainfo_group
            // 
            this.extrainfo_group.AutoSize = true;
            this.extrainfo_group.Controls.Add(this.tableLayoutPanel11);
            this.extrainfo_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extrainfo_group.Location = new System.Drawing.Point(3, 3);
            this.extrainfo_group.Name = "extrainfo_group";
            this.extrainfo_group.Size = new System.Drawing.Size(170, 265);
            this.extrainfo_group.TabIndex = 1;
            this.extrainfo_group.TabStop = false;
            this.extrainfo_group.Text = "Extra Info";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.filler_label6, 0, 5);
            this.tableLayoutPanel11.Controls.Add(this.filler_label5, 0, 5);
            this.tableLayoutPanel11.Controls.Add(this.filler_label3, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.filler_label4, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.filler_label2, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.cat_label, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.filler_label1, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.cat_sync_label, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.numofitems_label, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.numitems_sync_label, 1, 2);
            this.tableLayoutPanel11.Controls.Add(this.updateddate_label, 0, 4);
            this.tableLayoutPanel11.Controls.Add(this.updated_sync_label, 1, 4);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 7;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(164, 246);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // filler_label6
            // 
            this.filler_label6.AutoSize = true;
            this.filler_label6.Location = new System.Drawing.Point(3, 65);
            this.filler_label6.Name = "filler_label6";
            this.filler_label6.Size = new System.Drawing.Size(0, 13);
            this.filler_label6.TabIndex = 11;
            // 
            // filler_label5
            // 
            this.filler_label5.AutoSize = true;
            this.filler_label5.Location = new System.Drawing.Point(96, 65);
            this.filler_label5.Name = "filler_label5";
            this.filler_label5.Size = new System.Drawing.Size(0, 13);
            this.filler_label5.TabIndex = 10;
            // 
            // filler_label3
            // 
            this.filler_label3.AutoSize = true;
            this.filler_label3.Location = new System.Drawing.Point(96, 39);
            this.filler_label3.Name = "filler_label3";
            this.filler_label3.Size = new System.Drawing.Size(0, 13);
            this.filler_label3.TabIndex = 7;
            // 
            // filler_label4
            // 
            this.filler_label4.AutoSize = true;
            this.filler_label4.Location = new System.Drawing.Point(3, 39);
            this.filler_label4.Name = "filler_label4";
            this.filler_label4.Size = new System.Drawing.Size(0, 13);
            this.filler_label4.TabIndex = 6;
            // 
            // filler_label2
            // 
            this.filler_label2.AutoSize = true;
            this.filler_label2.Location = new System.Drawing.Point(3, 13);
            this.filler_label2.Name = "filler_label2";
            this.filler_label2.Size = new System.Drawing.Size(0, 13);
            this.filler_label2.TabIndex = 3;
            // 
            // cat_label
            // 
            this.cat_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cat_label.AutoSize = true;
            this.cat_label.Location = new System.Drawing.Point(38, 0);
            this.cat_label.Name = "cat_label";
            this.cat_label.Size = new System.Drawing.Size(52, 13);
            this.cat_label.TabIndex = 0;
            this.cat_label.Text = "Category:";
            // 
            // filler_label1
            // 
            this.filler_label1.AutoSize = true;
            this.filler_label1.Location = new System.Drawing.Point(96, 13);
            this.filler_label1.Name = "filler_label1";
            this.filler_label1.Size = new System.Drawing.Size(0, 13);
            this.filler_label1.TabIndex = 1;
            // 
            // cat_sync_label
            // 
            this.cat_sync_label.AutoSize = true;
            this.cat_sync_label.Location = new System.Drawing.Point(96, 0);
            this.cat_sync_label.Name = "cat_sync_label";
            this.cat_sync_label.Size = new System.Drawing.Size(63, 13);
            this.cat_sync_label.TabIndex = 2;
            this.cat_sync_label.Text = "Placeholder";
            // 
            // numofitems_label
            // 
            this.numofitems_label.AutoSize = true;
            this.numofitems_label.Location = new System.Drawing.Point(3, 26);
            this.numofitems_label.Name = "numofitems_label";
            this.numofitems_label.Size = new System.Drawing.Size(87, 13);
            this.numofitems_label.TabIndex = 4;
            this.numofitems_label.Text = "Number of Items:";
            // 
            // numitems_sync_label
            // 
            this.numitems_sync_label.AutoSize = true;
            this.numitems_sync_label.Location = new System.Drawing.Point(96, 26);
            this.numitems_sync_label.Name = "numitems_sync_label";
            this.numitems_sync_label.Size = new System.Drawing.Size(63, 13);
            this.numitems_sync_label.TabIndex = 5;
            this.numitems_sync_label.Text = "Placeholder";
            // 
            // updateddate_label
            // 
            this.updateddate_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateddate_label.AutoSize = true;
            this.updateddate_label.Location = new System.Drawing.Point(39, 52);
            this.updateddate_label.Name = "updateddate_label";
            this.updateddate_label.Size = new System.Drawing.Size(51, 13);
            this.updateddate_label.TabIndex = 8;
            this.updateddate_label.Text = "Updated:";
            // 
            // updated_sync_label
            // 
            this.updated_sync_label.AutoSize = true;
            this.updated_sync_label.Location = new System.Drawing.Point(96, 52);
            this.updated_sync_label.Name = "updated_sync_label";
            this.updated_sync_label.Size = new System.Drawing.Size(65, 13);
            this.updated_sync_label.TabIndex = 9;
            this.updated_sync_label.Text = "PlaceHolder";
            // 
            // settings_group
            // 
            this.settings_group.AutoSize = true;
            this.settings_group.Controls.Add(this.tableLayoutPanel14);
            this.settings_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settings_group.Location = new System.Drawing.Point(179, 3);
            this.settings_group.Name = "settings_group";
            this.settings_group.Size = new System.Drawing.Size(750, 265);
            this.settings_group.TabIndex = 2;
            this.settings_group.TabStop = false;
            this.settings_group.Text = "Settings";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.86559F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.13441F));
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(744, 246);
            this.tableLayoutPanel14.TabIndex = 4;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.AutoSize = true;
            this.tableLayoutPanel13.ColumnCount = 7;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel13.Controls.Add(this.filler_label_af, 1, 11);
            this.tableLayoutPanel13.Controls.Add(this.querylanguage_sel, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_ae, 0, 11);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_ad, 1, 9);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_ac, 0, 9);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_ab, 1, 7);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_aa, 0, 7);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_f, 1, 5);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_e, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_c, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_d, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_b, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.filler_label_a, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_Query_Language, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_useragent, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_batchdelay, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_decompressTo, 0, 6);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_downloadTo, 0, 8);
            this.tableLayoutPanel13.Controls.Add(this.setting_label_IsoTo, 0, 10);
            this.tableLayoutPanel13.Controls.Add(this.useragent_sel, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.batchdelay_updown, 1, 4);
            this.tableLayoutPanel13.Controls.Add(this.batchdelay_label2, 2, 4);
            this.tableLayoutPanel13.Controls.Add(this.decompress_path_tb, 1, 6);
            this.tableLayoutPanel13.Controls.Add(this.decompress_path_browse_btn, 4, 6);
            this.tableLayoutPanel13.Controls.Add(this.download_path_tb, 1, 8);
            this.tableLayoutPanel13.Controls.Add(this.iso_path_tb, 1, 10);
            this.tableLayoutPanel13.Controls.Add(this.download_path_browse_btn, 4, 8);
            this.tableLayoutPanel13.Controls.Add(this.iso_path_browse_btn, 4, 10);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 13;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(364, 240);
            this.tableLayoutPanel13.TabIndex = 1;
            // 
            // filler_label_af
            // 
            this.filler_label_af.AutoSize = true;
            this.filler_label_af.Location = new System.Drawing.Point(103, 221);
            this.filler_label_af.Name = "filler_label_af";
            this.filler_label_af.Size = new System.Drawing.Size(0, 13);
            this.filler_label_af.TabIndex = 25;
            // 
            // querylanguage_sel
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.querylanguage_sel, 2);
            this.querylanguage_sel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.querylanguage_sel.FormattingEnabled = true;
            this.querylanguage_sel.Location = new System.Drawing.Point(103, 3);
            this.querylanguage_sel.Name = "querylanguage_sel";
            this.querylanguage_sel.Size = new System.Drawing.Size(155, 21);
            this.querylanguage_sel.Sorted = true;
            this.querylanguage_sel.TabIndex = 2;
            // 
            // filler_label_ae
            // 
            this.filler_label_ae.AutoSize = true;
            this.filler_label_ae.Location = new System.Drawing.Point(3, 221);
            this.filler_label_ae.Name = "filler_label_ae";
            this.filler_label_ae.Size = new System.Drawing.Size(0, 13);
            this.filler_label_ae.TabIndex = 24;
            // 
            // filler_label_ad
            // 
            this.filler_label_ad.AutoSize = true;
            this.filler_label_ad.Location = new System.Drawing.Point(103, 182);
            this.filler_label_ad.Name = "filler_label_ad";
            this.filler_label_ad.Size = new System.Drawing.Size(0, 13);
            this.filler_label_ad.TabIndex = 23;
            // 
            // filler_label_ac
            // 
            this.filler_label_ac.AutoSize = true;
            this.filler_label_ac.Location = new System.Drawing.Point(3, 182);
            this.filler_label_ac.Name = "filler_label_ac";
            this.filler_label_ac.Size = new System.Drawing.Size(0, 13);
            this.filler_label_ac.TabIndex = 22;
            // 
            // filler_label_ab
            // 
            this.filler_label_ab.AutoSize = true;
            this.filler_label_ab.Location = new System.Drawing.Point(103, 143);
            this.filler_label_ab.Name = "filler_label_ab";
            this.filler_label_ab.Size = new System.Drawing.Size(0, 13);
            this.filler_label_ab.TabIndex = 21;
            // 
            // filler_label_aa
            // 
            this.filler_label_aa.AutoSize = true;
            this.filler_label_aa.Location = new System.Drawing.Point(3, 143);
            this.filler_label_aa.Name = "filler_label_aa";
            this.filler_label_aa.Size = new System.Drawing.Size(0, 13);
            this.filler_label_aa.TabIndex = 20;
            // 
            // filler_label_f
            // 
            this.filler_label_f.AutoSize = true;
            this.filler_label_f.Location = new System.Drawing.Point(103, 104);
            this.filler_label_f.Name = "filler_label_f";
            this.filler_label_f.Size = new System.Drawing.Size(0, 13);
            this.filler_label_f.TabIndex = 19;
            // 
            // filler_label_e
            // 
            this.filler_label_e.AutoSize = true;
            this.filler_label_e.Location = new System.Drawing.Point(3, 104);
            this.filler_label_e.Name = "filler_label_e";
            this.filler_label_e.Size = new System.Drawing.Size(0, 13);
            this.filler_label_e.TabIndex = 18;
            // 
            // filler_label_c
            // 
            this.filler_label_c.AutoSize = true;
            this.filler_label_c.Location = new System.Drawing.Point(3, 65);
            this.filler_label_c.Name = "filler_label_c";
            this.filler_label_c.Size = new System.Drawing.Size(0, 13);
            this.filler_label_c.TabIndex = 9;
            // 
            // filler_label_d
            // 
            this.filler_label_d.AutoSize = true;
            this.filler_label_d.Location = new System.Drawing.Point(103, 65);
            this.filler_label_d.Name = "filler_label_d";
            this.filler_label_d.Size = new System.Drawing.Size(0, 13);
            this.filler_label_d.TabIndex = 8;
            // 
            // filler_label_b
            // 
            this.filler_label_b.AutoSize = true;
            this.filler_label_b.Location = new System.Drawing.Point(103, 26);
            this.filler_label_b.Name = "filler_label_b";
            this.filler_label_b.Size = new System.Drawing.Size(0, 13);
            this.filler_label_b.TabIndex = 5;
            // 
            // filler_label_a
            // 
            this.filler_label_a.AutoSize = true;
            this.filler_label_a.Location = new System.Drawing.Point(3, 26);
            this.filler_label_a.Name = "filler_label_a";
            this.filler_label_a.Size = new System.Drawing.Size(0, 13);
            this.filler_label_a.TabIndex = 4;
            // 
            // setting_label_Query_Language
            // 
            this.setting_label_Query_Language.AutoSize = true;
            this.setting_label_Query_Language.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_Query_Language.Location = new System.Drawing.Point(3, 0);
            this.setting_label_Query_Language.Name = "setting_label_Query_Language";
            this.setting_label_Query_Language.Size = new System.Drawing.Size(94, 26);
            this.setting_label_Query_Language.TabIndex = 0;
            this.setting_label_Query_Language.Text = "Query Language:";
            this.setting_label_Query_Language.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setting_label_useragent
            // 
            this.setting_label_useragent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_useragent.Location = new System.Drawing.Point(3, 39);
            this.setting_label_useragent.Name = "setting_label_useragent";
            this.setting_label_useragent.Size = new System.Drawing.Size(94, 26);
            this.setting_label_useragent.TabIndex = 6;
            this.setting_label_useragent.Text = "User Agent: (Not Implemented)";
            this.setting_label_useragent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setting_label_batchdelay
            // 
            this.setting_label_batchdelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_batchdelay.Location = new System.Drawing.Point(3, 78);
            this.setting_label_batchdelay.Name = "setting_label_batchdelay";
            this.setting_label_batchdelay.Size = new System.Drawing.Size(94, 26);
            this.setting_label_batchdelay.TabIndex = 10;
            this.setting_label_batchdelay.Text = "Batch Delay (0 Disable\'s Batch):";
            this.setting_label_batchdelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setting_label_decompressTo
            // 
            this.setting_label_decompressTo.AutoSize = true;
            this.setting_label_decompressTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_decompressTo.Location = new System.Drawing.Point(3, 117);
            this.setting_label_decompressTo.Name = "setting_label_decompressTo";
            this.setting_label_decompressTo.Size = new System.Drawing.Size(94, 26);
            this.setting_label_decompressTo.TabIndex = 12;
            this.setting_label_decompressTo.Text = "Decompress Path:";
            this.setting_label_decompressTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setting_label_downloadTo
            // 
            this.setting_label_downloadTo.AutoSize = true;
            this.setting_label_downloadTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_downloadTo.Location = new System.Drawing.Point(3, 156);
            this.setting_label_downloadTo.Name = "setting_label_downloadTo";
            this.setting_label_downloadTo.Size = new System.Drawing.Size(94, 26);
            this.setting_label_downloadTo.TabIndex = 14;
            this.setting_label_downloadTo.Text = "Download Path:";
            this.setting_label_downloadTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // setting_label_IsoTo
            // 
            this.setting_label_IsoTo.AutoSize = true;
            this.setting_label_IsoTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setting_label_IsoTo.Location = new System.Drawing.Point(3, 195);
            this.setting_label_IsoTo.Name = "setting_label_IsoTo";
            this.setting_label_IsoTo.Size = new System.Drawing.Size(94, 26);
            this.setting_label_IsoTo.TabIndex = 16;
            this.setting_label_IsoTo.Text = "Iso Path:";
            this.setting_label_IsoTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // useragent_sel
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.useragent_sel, 2);
            this.useragent_sel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.useragent_sel.FormattingEnabled = true;
            this.useragent_sel.Location = new System.Drawing.Point(103, 42);
            this.useragent_sel.Name = "useragent_sel";
            this.useragent_sel.Size = new System.Drawing.Size(155, 21);
            this.useragent_sel.Sorted = true;
            this.useragent_sel.TabIndex = 26;
            // 
            // batchdelay_updown
            // 
            this.batchdelay_updown.AutoSize = true;
            this.batchdelay_updown.Dock = System.Windows.Forms.DockStyle.Left;
            this.batchdelay_updown.Location = new System.Drawing.Point(103, 81);
            this.batchdelay_updown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.batchdelay_updown.Name = "batchdelay_updown";
            this.batchdelay_updown.Size = new System.Drawing.Size(35, 20);
            this.batchdelay_updown.TabIndex = 27;
            this.batchdelay_updown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.batchdelay_updown.ValueChanged += new System.EventHandler(this.setting_marketplace_batchdelay_updown_ValueChanged);
            // 
            // batchdelay_label2
            // 
            this.batchdelay_label2.AutoSize = true;
            this.batchdelay_label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchdelay_label2.Location = new System.Drawing.Point(144, 78);
            this.batchdelay_label2.Name = "batchdelay_label2";
            this.batchdelay_label2.Size = new System.Drawing.Size(114, 26);
            this.batchdelay_label2.TabIndex = 28;
            this.batchdelay_label2.Text = "Seconds";
            this.batchdelay_label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // decompress_path_tb
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.decompress_path_tb, 3);
            this.decompress_path_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decompress_path_tb.Location = new System.Drawing.Point(103, 120);
            this.decompress_path_tb.Name = "decompress_path_tb";
            this.decompress_path_tb.Size = new System.Drawing.Size(190, 20);
            this.decompress_path_tb.TabIndex = 29;
            this.decompress_path_tb.Validating += new System.ComponentModel.CancelEventHandler(this.decompress_path_tb_Validating);
            this.decompress_path_tb.Validated += new System.EventHandler(this.decompress_path_tb_Validated);
            // 
            // decompress_path_browse_btn
            // 
            this.decompress_path_browse_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.decompress_path_browse_btn.Location = new System.Drawing.Point(299, 120);
            this.decompress_path_browse_btn.Name = "decompress_path_browse_btn";
            this.decompress_path_browse_btn.Size = new System.Drawing.Size(63, 20);
            this.decompress_path_browse_btn.TabIndex = 30;
            this.decompress_path_browse_btn.Text = "Browse";
            this.decompress_path_browse_btn.UseVisualStyleBackColor = true;
            this.decompress_path_browse_btn.Click += new System.EventHandler(this.decompress_path_browse_btn_Click);
            // 
            // download_path_tb
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.download_path_tb, 3);
            this.download_path_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.download_path_tb.Location = new System.Drawing.Point(103, 159);
            this.download_path_tb.Name = "download_path_tb";
            this.download_path_tb.Size = new System.Drawing.Size(190, 20);
            this.download_path_tb.TabIndex = 31;
            this.download_path_tb.Validating += new System.ComponentModel.CancelEventHandler(this.download_path_tb_Validating);
            this.download_path_tb.Validated += new System.EventHandler(this.download_path_tb_Validated);
            // 
            // iso_path_tb
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.iso_path_tb, 3);
            this.iso_path_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iso_path_tb.Location = new System.Drawing.Point(103, 198);
            this.iso_path_tb.Name = "iso_path_tb";
            this.iso_path_tb.Size = new System.Drawing.Size(190, 20);
            this.iso_path_tb.TabIndex = 32;
            this.iso_path_tb.Validating += new System.ComponentModel.CancelEventHandler(this.iso_path_tb_Validating);
            this.iso_path_tb.Validated += new System.EventHandler(this.iso_path_tb_Validated);
            // 
            // download_path_browse_btn
            // 
            this.download_path_browse_btn.AutoSize = true;
            this.download_path_browse_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.download_path_browse_btn.Location = new System.Drawing.Point(299, 159);
            this.download_path_browse_btn.Name = "download_path_browse_btn";
            this.download_path_browse_btn.Size = new System.Drawing.Size(63, 20);
            this.download_path_browse_btn.TabIndex = 33;
            this.download_path_browse_btn.Text = "Browse";
            this.download_path_browse_btn.UseVisualStyleBackColor = true;
            this.download_path_browse_btn.Click += new System.EventHandler(this.download_path_browse_btn_Click);
            // 
            // iso_path_browse_btn
            // 
            this.iso_path_browse_btn.AutoSize = true;
            this.iso_path_browse_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iso_path_browse_btn.Location = new System.Drawing.Point(299, 198);
            this.iso_path_browse_btn.Name = "iso_path_browse_btn";
            this.iso_path_browse_btn.Size = new System.Drawing.Size(63, 20);
            this.iso_path_browse_btn.TabIndex = 34;
            this.iso_path_browse_btn.Text = "Browse";
            this.iso_path_browse_btn.UseVisualStyleBackColor = true;
            this.iso_path_browse_btn.Click += new System.EventHandler(this.iso_path_browse_btn_Click);
            // 
            // credits_changelog_gbox
            // 
            this.tableLayoutPanel12.SetColumnSpan(this.credits_changelog_gbox, 2);
            this.credits_changelog_gbox.Controls.Add(this.tableLayoutPanel15);
            this.credits_changelog_gbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.credits_changelog_gbox.Location = new System.Drawing.Point(3, 274);
            this.credits_changelog_gbox.Name = "credits_changelog_gbox";
            this.credits_changelog_gbox.Size = new System.Drawing.Size(926, 227);
            this.credits_changelog_gbox.TabIndex = 4;
            this.credits_changelog_gbox.TabStop = false;
            this.credits_changelog_gbox.Text = "Changelog";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 5;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.Controls.Add(this.richTextBox1, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.displayVersionLabelnomodify, 3, 1);
            this.tableLayoutPanel15.Controls.Add(this.versionval_label, 4, 1);
            this.tableLayoutPanel15.Controls.Add(this.About_btn, 1, 1);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 2;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(920, 208);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel15.SetColumnSpan(this.richTextBox1, 4);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.ShowSelectionMargin = true;
            this.richTextBox1.Size = new System.Drawing.Size(914, 175);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // displayVersionLabelnomodify
            // 
            this.displayVersionLabelnomodify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayVersionLabelnomodify.AutoSize = true;
            this.displayVersionLabelnomodify.Location = new System.Drawing.Point(799, 181);
            this.displayVersionLabelnomodify.Name = "displayVersionLabelnomodify";
            this.displayVersionLabelnomodify.Size = new System.Drawing.Size(45, 27);
            this.displayVersionLabelnomodify.TabIndex = 1;
            this.displayVersionLabelnomodify.Text = "Version:";
            this.displayVersionLabelnomodify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // versionval_label
            // 
            this.versionval_label.AutoSize = true;
            this.versionval_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionval_label.Location = new System.Drawing.Point(850, 181);
            this.versionval_label.MinimumSize = new System.Drawing.Size(65, 20);
            this.versionval_label.Name = "versionval_label";
            this.versionval_label.Size = new System.Drawing.Size(67, 27);
            this.versionval_label.TabIndex = 2;
            this.versionval_label.Text = "versionvalue";
            this.versionval_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // About_btn
            // 
            this.About_btn.AutoSize = true;
            this.About_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.About_btn.Location = new System.Drawing.Point(3, 184);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(87, 21);
            this.About_btn.TabIndex = 3;
            this.About_btn.Text = "About&Thanks";
            this.About_btn.UseMnemonic = false;
            this.About_btn.UseVisualStyleBackColor = true;
            this.About_btn.Click += new System.EventHandler(this.About_btn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 536);
            this.Controls.Add(this.tabcontrol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Xbox Live Marketplace PC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tabcontrol.ResumeLayout(false);
            this.Marketplace_tabPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.region_group.ResumeLayout(false);
            this.region_group.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.marketcontent_group.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.page_group.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.page_num)).EndInit();
            this.category_group.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entrys_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentview)).EndInit();
            this.contentdescription_group.ResumeLayout(false);
            this.contentdescription_group.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.download_group.ResumeLayout(false);
            this.download_group.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.display_pic)).EndInit();
            this.Downloads_tabPage.ResumeLayout(false);
            this.Downloads_tlp.ResumeLayout(false);
            this.Downloads_tlp.PerformLayout();
            this.downloadmanager_controls_gb.ResumeLayout(false);
            this.downloadmanager_controls_gb.PerformLayout();
            this.downloadmanager_controls_tlp.ResumeLayout(false);
            this.downloadmanager_controls_tlp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.downloadmanager_blv)).EndInit();
            this.converter_tabPage.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.xcptogod_gb.ResumeLayout(false);
            this.xcptogod_tlp.ResumeLayout(false);
            this.xcptogod_tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xcptogod_blvex)).EndInit();
            this.godtoiso_gb.ResumeLayout(false);
            this.godtoiso_tlp.ResumeLayout(false);
            this.godtoiso_tlp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.godtoiso_blvex)).EndInit();
            this.InfoAndSettings_tabPage.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.extrainfo_group.ResumeLayout(false);
            this.extrainfo_group.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.settings_group.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.batchdelay_updown)).EndInit();
            this.credits_changelog_gbox.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker WebWorker;
        private System.Windows.Forms.TabControl tabcontrol;
        private System.Windows.Forms.TabPage Marketplace_tabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox region_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox reg_select;
        private System.Windows.Forms.ProgressBar urlChecking_ProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox marketcontent_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox page_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown page_num;
        private System.Windows.Forms.Button go_btn;
        private System.Windows.Forms.Button prev_btn;
        private System.Windows.Forms.GroupBox category_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.ComboBox cat_select;
        private System.Windows.Forms.Label entrypp_label;
        private System.Windows.Forms.NumericUpDown entrys_num;
        private System.Windows.Forms.GroupBox contentdescription_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox display_pic;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox gametitle_text;
        private System.Windows.Forms.TextBox developer_text;
        private System.Windows.Forms.TextBox publisher_text;
        private System.Windows.Forms.TextBox release_text;
        private System.Windows.Forms.TextBox genre_text;
        private System.Windows.Forms.Label gametitle_label;
        private System.Windows.Forms.Label developer_label;
        private System.Windows.Forms.Label publisher_label;
        private System.Windows.Forms.Label releasedate_label;
        private System.Windows.Forms.Label genre_label;
        private System.Windows.Forms.GroupBox download_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button directdownload_btn;
        private System.Windows.Forms.Button generateurl_btn;
        private System.Windows.Forms.Button fchecklist_btn;
        private System.Windows.Forms.RichTextBox description_textbox;
        private System.Windows.Forms.TabPage InfoAndSettings_tabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.GroupBox extrainfo_group;
        private System.Windows.Forms.GroupBox credits_changelog_gbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.Label cat_label;
        private System.Windows.Forms.Label filler_label1;
        private System.Windows.Forms.Label cat_sync_label;
        private System.Windows.Forms.Label filler_label2;
        private System.Windows.Forms.Label filler_label3;
        private System.Windows.Forms.Label filler_label4;
        private System.Windows.Forms.Label numofitems_label;
        private System.Windows.Forms.Label numitems_sync_label;
        private System.Windows.Forms.Label filler_label6;
        private System.Windows.Forms.Label filler_label5;
        private System.Windows.Forms.Label updateddate_label;
        private System.Windows.Forms.Label updated_sync_label;
        private System.Windows.Forms.GroupBox settings_group;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.Label filler_label_af;
        private System.Windows.Forms.Label filler_label_ae;
        private System.Windows.Forms.Label filler_label_ad;
        private System.Windows.Forms.Label filler_label_ac;
        private System.Windows.Forms.Label filler_label_ab;
        private System.Windows.Forms.Label filler_label_aa;
        private System.Windows.Forms.Label filler_label_f;
        private System.Windows.Forms.Label filler_label_e;
        private System.Windows.Forms.Label filler_label_c;
        private System.Windows.Forms.Label filler_label_d;
        private System.Windows.Forms.Label filler_label_b;
        private System.Windows.Forms.Label filler_label_a;
        private System.Windows.Forms.Label setting_label_Query_Language;
        private System.Windows.Forms.Label setting_label_useragent;
        private System.Windows.Forms.Label setting_label_batchdelay;
        private System.Windows.Forms.Label setting_label_decompressTo;
        private System.Windows.Forms.Label setting_label_downloadTo;
        private System.Windows.Forms.Label setting_label_IsoTo;
        private System.Windows.Forms.ComboBox querylanguage_sel;
        private System.Windows.Forms.Label extrainfo_Label;
        private System.Windows.Forms.Button extrainfo_btn;
        private System.Windows.Forms.ComboBox useragent_sel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label displayVersionLabelnomodify;
        private System.Windows.Forms.NumericUpDown batchdelay_updown;
        private System.Windows.Forms.Label batchdelay_label2;
        private System.Windows.Forms.Label versionval_label;
        private System.Windows.Forms.Button About_btn;
        private System.Windows.Forms.TabPage Downloads_tabPage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNoChange1;
        private System.Windows.Forms.ToolStripStatusLabel DownloadSpeed_tssl;
        private System.Windows.Forms.TableLayoutPanel Downloads_tlp;
        private BetterListViewEx downloadmanager_blv;
        private System.Windows.Forms.GroupBox downloadmanager_controls_gb;
        private System.Windows.Forms.GroupBox groupBox1;
        private BetterListViewExColumnHeader Name_blv_ch;
        private BetterListViewExColumnHeader Speed_blv_ch;
        private BetterListViewExColumnHeader Progress_blv_ch;
        private BetterListViewExColumnHeader Title_BLV_ch;
        private BetterListViewExColumnHeader CanDownload_BLV_ch;
        private BetterListViewExColumnHeader Developer_BLV_ch;
        private BetterListViewExColumnHeader TotalDownloaded_blv_ch;
        private System.Windows.Forms.TableLayoutPanel downloadmanager_controls_tlp;
        private System.Windows.Forms.TextBox decompress_path_tb;
        private System.Windows.Forms.Button decompress_path_browse_btn;
        private System.Windows.Forms.TextBox download_path_tb;
        private System.Windows.Forms.TextBox iso_path_tb;
        private System.Windows.Forms.Button download_path_browse_btn;
        private System.Windows.Forms.Button iso_path_browse_btn;
        private System.Windows.Forms.TabPage converter_tabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.GroupBox xcptogod_gb;
        private System.Windows.Forms.TableLayoutPanel xcptogod_tlp;
        private System.Windows.Forms.GroupBox godtoiso_gb;
        private System.Windows.Forms.TableLayoutPanel godtoiso_tlp;
        private System.Windows.Forms.Button xcptogod_cancel_btn;
        private System.Windows.Forms.Button godtoiso_cancel_btn;
        private BetterListViewEx xcptogod_blvex;
        private BetterListViewEx godtoiso_blvex;
        private System.Windows.Forms.Button xcptogod_Add_btn;
        private System.Windows.Forms.Button xcptogod_Remove_btn;
        private System.Windows.Forms.Button xcptogod_Unpack_btn;
        private System.Windows.Forms.Button xcptogod_UnpackAll_btn;
        private System.Windows.Forms.Button xcptogod_RemoveFinished_btn;
        private System.Windows.Forms.Button godtoiso_Add_btn;
        private System.Windows.Forms.Button godtoiso_Remove_btn;
        private System.Windows.Forms.Button godtoiso_CreateIso_btn;
        private System.Windows.Forms.Button godtoiso_RemoveFinished_btn;
        private System.Windows.Forms.Button godtoiso_ConvertAll_btn;
        private System.Windows.Forms.Button downloadmanager_controls_Remove_btn;
        private BetterListViewExColumnHeader xcptogod_blvex_ch;
        private BetterListViewExColumnHeader god2iso_blvex_ch;
        private BetterListViewExColumnHeader xcptogod_blvex_ch_Title;
        private BetterListViewExColumnHeader xcptogod_blvex_ch_Status;
        private BetterListViewExColumnHeader xcptogod_blvex_ch_Progress;
        private BetterListViewExColumnHeader godtoiso_blvex_ch_Title;
        private BetterListViewExColumnHeader godtoiso_blvex_ch_Status;
        private BetterListViewExColumnHeader godtoiso_blvex_ch_Progress;
        private BetterListViewEx contentview;
    }
}

