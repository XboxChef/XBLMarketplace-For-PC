namespace XBLMarketplace_For_PC.Forms
{
    partial class DisplayUrlBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayUrlBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ok_btn = new System.Windows.Forms.Button();
            this.copytoclipboard_btn = new System.Windows.Forms.Button();
            this.gameTitle_label = new System.Windows.Forms.Label();
            this.urldisplay_tb = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.ok_btn, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.copytoclipboard_btn, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.gameTitle_label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.urldisplay_tb, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(682, 93);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(488, 67);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 1;
            this.ok_btn.Text = "Close";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // copytoclipboard_btn
            // 
            this.copytoclipboard_btn.AutoSize = true;
            this.copytoclipboard_btn.Location = new System.Drawing.Point(569, 67);
            this.copytoclipboard_btn.Name = "copytoclipboard_btn";
            this.copytoclipboard_btn.Size = new System.Drawing.Size(100, 23);
            this.copytoclipboard_btn.TabIndex = 2;
            this.copytoclipboard_btn.Text = "Copy to Clipboard";
            this.copytoclipboard_btn.UseVisualStyleBackColor = true;
            this.copytoclipboard_btn.Click += new System.EventHandler(this.copytoclipboard_btn_Click);
            // 
            // gameTitle_label
            // 
            this.gameTitle_label.AutoEllipsis = true;
            this.gameTitle_label.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.gameTitle_label, 3);
            this.gameTitle_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameTitle_label.Location = new System.Drawing.Point(13, 10);
            this.gameTitle_label.Name = "gameTitle_label";
            this.gameTitle_label.Size = new System.Drawing.Size(656, 17);
            this.gameTitle_label.TabIndex = 4;
            this.gameTitle_label.Text = "GameTitle";
            this.gameTitle_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // urldisplay_tb
            // 
            this.urldisplay_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.urldisplay_tb, 3);
            this.urldisplay_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urldisplay_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.urldisplay_tb.Location = new System.Drawing.Point(13, 30);
            this.urldisplay_tb.Name = "urldisplay_tb";
            this.urldisplay_tb.ReadOnly = true;
            this.urldisplay_tb.Size = new System.Drawing.Size(656, 14);
            this.urldisplay_tb.TabIndex = 5;
            this.urldisplay_tb.Text = "http://download.xbox.com/content/564707d4/75650ac9640f5c9a28bdbfacdcd6dc1c3fe3abf" +
    "6.xcp";
            this.urldisplay_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.urldisplay_tb.WordWrap = false;
            // 
            // DisplayURLBox
            // 
            this.AcceptButton = this.ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 93);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayUrlBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XCP Url";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button copytoclipboard_btn;
        internal System.Windows.Forms.Label gameTitle_label;
        internal System.Windows.Forms.TextBox urldisplay_tb;
    }
}