using DevExpress.XtraGrid.Views.BandedGrid;

namespace Windows.Core.Helpers
{
    public class GridBandHelper
    {
        public static void ResizeAllColumns(GridBand gridBand, int newWidth)
        {
            if (gridBand != null && gridBand.Visible == true && gridBand.Columns.Count > 0)
            {
                int newBandWidth = gridBand.Columns.Count*newWidth;
                gridBand.Width = newBandWidth;

                for (int i = 0; i < gridBand.Columns.Count; i++)
                {
                    gridBand.Columns[i].Width = newWidth;
                }

                gridBand.Width = newBandWidth;
            }
        }
    }
}