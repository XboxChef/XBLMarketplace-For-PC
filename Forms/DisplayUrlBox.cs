using System;
using System.Windows.Forms;
using XBLMarketplace_For_PC.FormComponents;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class DisplayUrlBox : Form
    {
        public DisplayUrlBox()
        {
            InitializeComponent();
            Theme.Apply(this, copytoclipboard_btn);
            StartPosition = FormStartPosition.CenterParent;
        }

        private void copytoclipboard_btn_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(urldisplay_tb.Text);
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
