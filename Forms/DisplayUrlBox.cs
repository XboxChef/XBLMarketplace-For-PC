// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.Forms.DisplayUrlBox
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace XBLMarketplace_For_PC.Forms
{
  public class DisplayUrlBox : Form
  {
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel1;
    private Button ok_btn;
    private Button copytoclipboard_btn;
    internal Label gameTitle_label;
    internal TextBox urldisplay_tb;

    public DisplayUrlBox() => this.InitializeComponent();

    private void copytoclipboard_btn_Click(object sender, EventArgs e) => Clipboard.SetText(this.urldisplay_tb.Text);

    private void ok_btn_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(DisplayUrlBox));
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.ok_btn = new Button();
            this.copytoclipboard_btn = new Button();
            this.gameTitle_label = new Label();
            this.urldisplay_tb = new TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10f));
            this.tableLayoutPanel1.Controls.Add(this.ok_btn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.copytoclipboard_btn, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.gameTitle_label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.urldisplay_tb, 1, 2);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle());
            this.tableLayoutPanel1.Size = new Size(0x2aa, 0x5d);
            this.tableLayoutPanel1.TabIndex = 0;
            this.ok_btn.Location = new Point(0x1e8, 0x43);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new Size(0x4b, 0x17);
            this.ok_btn.TabIndex = 1;
            this.ok_btn.Text = "Close";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
            this.copytoclipboard_btn.AutoSize = true;
            this.copytoclipboard_btn.Location = new Point(0x239, 0x43);
            this.copytoclipboard_btn.Name = "copytoclipboard_btn";
            this.copytoclipboard_btn.Size = new Size(100, 0x17);
            this.copytoclipboard_btn.TabIndex = 2;
            this.copytoclipboard_btn.Text = "Copy to Clipboard";
            this.copytoclipboard_btn.UseVisualStyleBackColor = true;
            this.copytoclipboard_btn.Click += new EventHandler(this.copytoclipboard_btn_Click);
            this.gameTitle_label.AutoEllipsis = true;
            this.gameTitle_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.gameTitle_label, 3);
            this.gameTitle_label.Dock = DockStyle.Fill;
            this.gameTitle_label.Location = new Point(13, 10);
            this.gameTitle_label.Name = "gameTitle_label";
            this.gameTitle_label.Size = new Size(0x290, 0x11);
            this.gameTitle_label.TabIndex = 4;
            this.gameTitle_label.Text = "GameTitle";
            this.gameTitle_label.TextAlign = ContentAlignment.TopCenter;
            this.urldisplay_tb.BorderStyle = BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.urldisplay_tb, 3);
            this.urldisplay_tb.Dock = DockStyle.Fill;
            this.urldisplay_tb.Font = new Font("Microsoft Sans Serif", 9f);
            this.urldisplay_tb.Location = new Point(13, 30);
            this.urldisplay_tb.Name = "urldisplay_tb";
            this.urldisplay_tb.ReadOnly = true;
            this.urldisplay_tb.Size = new Size(0x290, 14);
            this.urldisplay_tb.TabIndex = 5;
            this.urldisplay_tb.Text = "http://download.xbox.com/content/564707d4/75650ac9640f5c9a28bdbfacdcd6dc1c3fe3abf6.xcp";
            this.urldisplay_tb.TextAlign = HorizontalAlignment.Center;
            this.urldisplay_tb.WordWrap = false;
            base.AcceptButton = this.ok_btn;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2aa, 0x5d);
            base.Controls.Add(this.tableLayoutPanel1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DisplayUrlBox";
            base.SizeGripStyle = SizeGripStyle.Show;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "XCP Url";
            base.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            base.ResumeLayout(false);
        }
    }
}
