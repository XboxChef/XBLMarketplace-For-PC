using ComponentOwl.BetterListView;

namespace XBLMarketplace_For_PC.FormComponents
{
    public class BetterListViewExColumnHeader : BetterListViewColumnHeader
    {
        private BetterListViewExColumnType columnType = BetterListViewExColumnType.Default;

        public BetterListViewExColumnHeader(BetterListViewExColumnType columnType, string text, int width) : base(text, width)
        {
            this.ColumnType = columnType;
            base.Style = BetterListViewColumnHeaderStyle.Sortable;
        }

        public BetterListViewExColumnHeader()
        {}

        public BetterListViewExColumnType ColumnType { get { return columnType; } set { columnType = value; }}
    }
}