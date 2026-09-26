using System;
using System.Windows.Forms;
using XBLMarketplace_For_PC.FormComponents;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class ExtraInformation : Form
    {
        public ExtraInformation()
        {
            InitializeComponent();
            Theme.Apply(this, ok_btn);
            StartPosition = FormStartPosition.CenterParent;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
