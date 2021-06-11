namespace XBLMarketplace_For_PC.Forms
{
    partial class ExtraInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraInformation));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ok_btn = new System.Windows.Forms.Button();
            this.gamecapabilityview = new ComponentOwl.BetterListView.BetterListView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gamecapabilityview)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ok_btn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.gamecapabilityview, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ok_btn
            // 
            this.ok_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ok_btn.Location = new System.Drawing.Point(200, 333);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(75, 23);
            this.ok_btn.TabIndex = 5;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = false;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // gamecapabilityview
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gamecapabilityview, 3);
            this.gamecapabilityview.DataBindColumns = true;
            this.gamecapabilityview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gamecapabilityview.HScrollBarDisplayMode = ComponentOwl.BetterListView.BetterListViewScrollBarDisplayMode.Hide;
            this.gamecapabilityview.Location = new System.Drawing.Point(3, 3);
            this.gamecapabilityview.MultiSelect = false;
            this.gamecapabilityview.Name = "gamecapabilityview";
            this.gamecapabilityview.ReadOnly = true;
            this.gamecapabilityview.Size = new System.Drawing.Size(470, 324);
            this.gamecapabilityview.TabIndex = 6;
            // 
            // ExtraInformation
            // 
            this.AcceptButton = this.ok_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 359);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExtraInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExtraInformation";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gamecapabilityview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button ok_btn;
        internal ComponentOwl.BetterListView.BetterListView gamecapabilityview;
    }
}