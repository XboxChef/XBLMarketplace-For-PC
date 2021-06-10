// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.FormComponents.BetterListViewEx
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using ComponentOwl.BetterListView;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XBLMarketplace_For_PC.FormComponents
{
  public class BetterListViewEx : ComponentOwl.BetterListView.BetterListView
  {
    protected override void OnDrawItem(BetterListViewDrawItemEventArgs eventArgs)
    {
      int num1 = 100;
      base.OnDrawItem(eventArgs);
      if (this.View != BetterListViewView.Details)
        return;
      Graphics graphics = eventArgs.Graphics;
      foreach (BetterListViewSubItem subItem in (BetterListViewElementCollection<BetterListViewSubItem>) eventArgs.Item.SubItems)
      {
        if (subItem.Index >= this.Columns.Count)
          break;
        Rectangle boundsInner = eventArgs.ItemBounds.SubItemBounds[subItem.Index].BoundsInner;
        if (boundsInner.Width > 0 && boundsInner.Height > 0)
        {
          BetterListViewExColumnType? columnType = ((BetterListViewExColumnHeader) this.Columns[subItem.Index])?.ColumnType;
          if (columnType.HasValue && columnType.GetValueOrDefault() == BetterListViewExColumnType.PercentDone && (boundsInner.Width > 4 && boundsInner.Height > 4) && subItem.Value is short)
          {
            int height = Math.Min(16, boundsInner.Height);
            Rectangle rectangle = new Rectangle(boundsInner.Left, boundsInner.Top + (boundsInner.Height - height >> 1), boundsInner.Width - 2, height);
            short num2 = (short) subItem.Value;
            if (ProgressBarRenderer.IsSupported)
            {
              Rectangle bounds = new Rectangle(rectangle.Left + 1, rectangle.Top + 1, (int) num2 * (rectangle.Width - 1) / num1, rectangle.Height - 2);
              ProgressBarRenderer.DrawHorizontalBar(graphics, rectangle);
              ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
            }
            else
            {
              Rectangle rect = new Rectangle(rectangle.Left + 1, rectangle.Top + 1, (int) num2 * (rectangle.Width - 1) / num1, rectangle.Height - 1);
              graphics.FillRectangle(SystemBrushes.Window, rectangle);
              graphics.FillRectangle(SystemBrushes.Highlight, rect);
              graphics.DrawRectangle(SystemPens.Control, rectangle);
            }
          }
        }
      }
    }
  }
}
