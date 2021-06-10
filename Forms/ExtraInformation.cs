// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Forms.ExtraInformation
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using ComponentOwl.BetterListView;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace XBLMarketplace_For_PC.Forms
{
  public class ExtraInformation : Form
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Button ok_btn;
    internal ComponentOwl.BetterListView.BetterListView gamecapabilityview;

    public ExtraInformation() => this.InitializeComponent();

    private void ok_btn_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(ExtraInformation));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.ok_btn = new Button();
            this.gamecapabilityview = new ComponentOwl.BetterListView.BetterListView();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)this.gamecapabilityview).BeginInit();
            base.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.Controls.Add(this.ok_btn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gamecapabilityview, 0, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(0x1dc, 0x167);
            this.tableLayoutPanel1.TabIndex = 0;
            this.ok_btn.Anchor = AnchorStyles.None;
            this.ok_btn.Location = new Point(200, 0x14d);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new Size(0x4b, 0x17);
            this.ok_btn.TabIndex = 5;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
            this.tableLayoutPanel1.SetColumnSpan(this.gamecapabilityview, 3);
            this.gamecapabilityview.DataBindColumns = true;
            this.gamecapabilityview.Dock = DockStyle.Fill;
            this.gamecapabilityview.HScrollBarDisplayMode = BetterListViewScrollBarDisplayMode.Hide;
            this.gamecapabilityview.Location = new Point(3, 3);
            this.gamecapabilityview.MultiSelect = false;
            this.gamecapabilityview.Name = "gamecapabilityview";
            this.gamecapabilityview.ReadOnly = true;
            this.gamecapabilityview.Size = new Size(470, 0x144);
            this.gamecapabilityview.TabIndex = 6;
            base.AcceptButton = this.ok_btn;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1dc, 0x167);
            base.Controls.Add(this.tableLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ExtraInformation";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "ExtraInformation";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)this.gamecapabilityview).EndInit();
            base.ResumeLayout(false);
        }
    }
}
