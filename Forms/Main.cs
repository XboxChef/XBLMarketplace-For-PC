using System;
using System.Linq;
using System.Windows.Forms;
using God2Iso;
using JasonNS.Components;
using JasonNS.Forms;
using XBLMarketplace_For_PC.Helpers;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    public partial class Main : Form
    {
        private BatchUrlChecker _batchhandler;
        private ThreadedBindingList<GameOnDemand> _godList;
        Webhelper _helper = new Webhelper();
        private ThreadedBindingList<IsoInstance> _isoList;


        private ThreadedBindingList<XcpInstance> _xcpList;

        private AboutBox ThanksBox;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                marketplace_init();
                download_init();
                converter_init();
                settings_init();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }


        private void About_btn_Click(object sender, EventArgs e)
        {
            if (ThanksBox == null || ThanksBox.IsDisposed)
            {
                ThanksBox = new AboutBox(Constants.Credits);
                ThanksBox.Show();
            }
            else ThanksBox.Show();
        }

        private void downloadmanager_controls_Remove_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var itemToRemove = downloadmanager_blv.Items.Where(
                    obj =>
                    {
                        DownloadInstance di = (DownloadInstance) obj.Value;
                        if (di.DLStatus == DownloadStatus.Finished) return true;
                        return false;
                    }).ToList();
                foreach (var item in itemToRemove)
                {
                    downloadmanager_blv.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (contentview.Items.Count > 0) contentview.SelectedValue = contentview.Items[0].Value;
        }
    }
}