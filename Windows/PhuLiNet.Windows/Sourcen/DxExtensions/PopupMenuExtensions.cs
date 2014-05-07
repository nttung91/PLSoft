using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.DxExtensions
{
    public static class PopupMenuExtensions
    {
        /// <summary>
        /// Shows popup menu on gridview on right mouse click
        /// </summary>
        /// <param name="popupMenu"></param>
        /// <param name="grid"></param>
        /// <param name="gridView"></param>
        /// <param name="e"></param>
        public static void ShowPopup(this PopupMenu popupMenu, GridControl grid, GridView gridView, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var view = grid.GetViewAt(e.Location) as GridView;

                if (view != null &&
                    view == gridView &&
                    view.CalcHitInfo(e.Location).InRow)
                {
                    popupMenu.ShowPopup(grid.PointToScreen(e.Location));
                }
            }
        }
    }
}