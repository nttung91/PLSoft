using DevExpress.XtraGrid.Views.BandedGrid;

namespace Windows.Core.DxExtensions
{
    public static class GridBandColumnCollectionExtension
    {
        public static void SetColumnWidth(this GridBandColumnCollection gridColumns, int columnWidth)
        {
            if (gridColumns.View == null || gridColumns.Band == null) return;


            var maxRowCount = GetMaxRowCount(gridColumns);
            if (maxRowCount == 0) return;

            var newBandWidth = gridColumns.Count/maxRowCount*columnWidth;
            gridColumns.Band.Width = newBandWidth;

            foreach (BandedGridColumn bandedGridColumn in gridColumns)
            {
                // Bei der letzten Spalte die Breite nicht setzen!
                if (bandedGridColumn == gridColumns[gridColumns.Count/maxRowCount - 1] ||
                    bandedGridColumn == gridColumns[gridColumns.Count - 1]) continue;

                bandedGridColumn.Width = columnWidth;
            }
        }

        private static int GetMaxRowCount(GridBandColumnCollection gridColumns)
        {
            var maxRowCount = 1;

            foreach (BandedGridColumn bandedGridColumn in gridColumns)
            {
                if (bandedGridColumn.RowIndex + 1 > maxRowCount)
                    maxRowCount = bandedGridColumn.RowIndex + 1;
            }

            return maxRowCount;
        }
    }
}