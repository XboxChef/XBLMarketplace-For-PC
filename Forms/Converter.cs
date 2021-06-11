using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using God2Iso;
using God2Iso.Types;
using JasonNS.Components;
using JasonNS.EventArguments;
using JasonNS.Types;
using XBLMarketplace_For_PC.Types;

namespace XBLMarketplace_For_PC.Forms
{
    partial class Main
    {
        private void converter_init()
        {
            _xcpList = new ThreadedBindingList<XcpInstance>();
            _godList = new ThreadedBindingList<GameOnDemand>();
            _isoList = new ThreadedBindingList<IsoInstance>();
            xcptogod_blvex.DataSource = _xcpList;
            godtoiso_blvex.DataSource = _godList;
        }

        #region Converter Buttons

        #region Xbox Compressed Package -> Game on Demand Package

        private void xcptogod_Add_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                DereferenceLinks = true,
                Multiselect = false,
                InitialDirectory = BindingStrings.Instance.DownloadPath,
                Filter= "Xbox Package(*.xcp;*.xup) |*.xcp;*.xup| All files(*.*) | *.*",
                Title = "Open File..."
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _xcpList.Add(new XcpInstance(dialog.FileName, BindingStrings.Instance.DecompressPath, ConverterOptions.autostart, ConverterOptions.cleanup,null));   
                }
            }
        }

        private void xcptogod_Remove_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void xcptogod_Unpack_btn_Click(object sender, EventArgs e)
        {
            XcpInstance xcp = (XcpInstance) xcptogod_blvex.SelectedValue;
            if (xcp == null)
            {
                MessageBox.Show("Please Select a Game to Unpack", "Alert");
                return;
            }
            Task.Run(() =>
            {
                if (String.Compare(Path.GetExtension(xcp.InFile), ".xcp", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    xcp.UnpackAndSplitComplete += Xcp_UnpackAndSplitComplete;
                    xcp.FullExtract();
                }
                else if (string.Compare(Path.GetExtension(xcp.InFile), ".xup", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    xcp.UnpackCompleted += Xcp_UnpackCompleted;
                    xcp.Split();
                }
            }).ContinueWith(prevTask =>
            {
                if (prevTask.Exception != null) throw prevTask.Exception;
                if (xcp.GodInstance != null)
                {
                    _godList.Add(xcp.GodInstance);
                    _xcpList.Remove(xcp);
                }
            });
        }

        private void xcptogod_RemoveFinished_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var itemToRemove = xcptogod_blvex.Items.Where(
                    obj =>
                    {
                        XcpInstance di = (XcpInstance)obj.Value;
                        if (di.GodInstance != null) return true;
                        return false;
                    }).ToList();
                foreach (var item in itemToRemove)
                {
                    xcptogod_blvex.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void xcptogod_UnpackAll_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void xcptogod_cancel_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Game On Demand Package -> ISO

        private void godtoiso_Add_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                DereferenceLinks = true,
                Multiselect = false,
                InitialDirectory = BindingStrings.Instance.DecompressPath,
                Filter = "Pirs Header|" + null,
                Title = "Open File..."
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _godList.Add(new GameOnDemand(new Pirs(dialog.FileName)));
                }
            }
        }

        private void godtoiso_Remove_btn_Click(object sender, EventArgs e)
        {
            GameOnDemand god = (GameOnDemand) godtoiso_blvex.SelectedValue;
            if ((god?.Status == PackageStatus.Canceled) || (god?.Status == PackageStatus.Invalid) || (god?.Status == PackageStatus.Errored))
            {
                _godList.Remove(god);
            }
            else
            {
                MessageBox.Show("Unable to remove. Status must be 'Waiting'.", "Alert");
            }
        }

        private void godtoiso_CreateIso_btn_Click(object sender, EventArgs e)
        {
            //XcpInstance xcp = (XcpInstance) xcptogod_blvex.SelectedValue
            GameOnDemand god = (GameOnDemand)godtoiso_blvex.SelectedValue;
            if (god == null)
            {
                MessageBox.Show("Please Select a Game to Convert", "Alert");
                return;
            }
            Task.Run(() =>
            {
                god.CreateIso(BindingStrings.Instance.IsoPath,ConverterOptions.fixcbHeader);
            }).ContinueWith(prevTask =>
            {
                if (prevTask.Exception != null) throw prevTask.Exception;
            });
        }

        private void godtoiso_RemoveFinished_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var itemToRemove = godtoiso_blvex.Items.Where(
                    obj =>
                    {
                        GameOnDemand di = (GameOnDemand)obj.Value;
                        if ((di.Status == PackageStatus.Canceled)||
                        (di.Status == PackageStatus.Finished)||
                        (di.Status == PackageStatus.Errored)) return true;
                        return false;
                    }).ToList();
                foreach (var item in itemToRemove)
                {
                    godtoiso_blvex.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw;
            }
        }

        private void godtoiso_ConvertAll_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void godtoiso_Cancel_btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region EventCallBacks

        private void Xcp_UnpackAndSplitComplete(object sender, EventArgs e)
        {
            XcpInstance xcp = (XcpInstance)sender;
            xcp.UnpackAndSplitComplete -= Xcp_UnpackAndSplitComplete;
            _xcpList.Remove(xcp);
        }

        private void Xcp_UnpackCompleted(object sender, EventArgs e)
        {
            XcpInstance xcp = (XcpInstance)sender;
            xcp.UnpackCompleted -= Xcp_UnpackCompleted;
            _xcpList.Remove(xcp);
        }

        private void God_CreateIsoProgress(object sender, ProgressChangedEventArgs e)
        {
            GameOnDemand god = (GameOnDemand)sender;
            _godList.ResetItem(_godList.IndexOf(god));
        }

        #endregion
    }
}
