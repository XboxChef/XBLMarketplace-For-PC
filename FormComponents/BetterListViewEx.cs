using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;

namespace XBLMarketplace_For_PC.FormComponents
{
    public class BetterListViewEx : BetterListView
    {
        //public new List<BetterListViewExColumnHeader> Columns = new List<BetterListViewExColumnHeader>();

        protected override void OnDrawItem(BetterListViewDrawItemEventArgs eventArgs)
        {
            base.OnDrawItem(eventArgs);
            if (View != BetterListViewView.Details)
            {
                return;
            }
            Graphics graphics = eventArgs.Graphics;
            foreach (BetterListViewSubItem current in eventArgs.Item.SubItems)
            {
                if (current.Index >= base.Columns.Count)
                {
                    break;
                }
                Rectangle boundsInner = eventArgs.ItemBounds.SubItemBounds[current.Index].BoundsInner;
                if ((boundsInner.Width > 0) && (boundsInner.Height > 0))
                {
                    BetterListViewExColumnHeader blvExColumnHeader = (BetterListViewExColumnHeader) Columns[current.Index];
                    switch (blvExColumnHeader?.ColumnType)
                    {
                        
                        case BetterListViewExColumnType.PercentDone:
                            if ((boundsInner.Width > 4) && (boundsInner.Height > 4) && current.Value is short)
                            {
                                int num3 = Math.Min(16, boundsInner.Height);
                                Rectangle rectangle = new Rectangle(boundsInner.Left, boundsInner.Top + ((boundsInner.Height - num3) >> 1), boundsInner.Width - 2, num3);
                                Theme.DrawProgress(graphics, rectangle, (short)current.Value, Font);
                            }
                            break;
                    }
                }
            }
        }
    }
}
