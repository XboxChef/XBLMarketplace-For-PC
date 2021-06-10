// Decompiled with JetBrains decompiler
// Type: XBLMarketplace_For_PC.FormComponents.BetterListViewExColumnHeader
// Assembly: XBLMarketplace For PC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D6E0E9F-DDF5-467E-9623-656102783353
// Assembly location: C:\Users\Serenity\Desktop\XBLMarketplace For PC.exe

using ComponentOwl.BetterListView;

namespace XBLMarketplace_For_PC.FormComponents
{
  public class BetterListViewExColumnHeader : BetterListViewColumnHeader
  {
    private BetterListViewExColumnType columnType;

    public BetterListViewExColumnHeader(
      BetterListViewExColumnType columnType,
      string text,
      int width)
      : base(text, width)
    {
      this.ColumnType = columnType;
      this.Style = BetterListViewColumnHeaderStyle.Sortable;
    }

    public BetterListViewExColumnHeader()
    {
    }

    public BetterListViewExColumnType ColumnType
    {
      get => this.columnType;
      set => this.columnType = value;
    }
  }
}
