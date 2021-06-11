using System;
using System.Windows.Forms;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class DisplayUrlBox : Form
    {
        public DisplayUrlBox()
        {
            InitializeComponent();
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
