using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;

namespace Windows.Core.DxExtensions
{
    public static class TreeListExtensions
    {
        /// <summary>
        /// Shows popup menu on tree on right mouse click
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="popupMenu"></param>
        /// <param name="e"></param>
        /// <param name="mousePosition"></param>
        public static void ShowPopupMenu(this TreeList tree, PopupMenu popupMenu, MouseEventArgs e, Point mousePosition)
        {
            if (e.Button == MouseButtons.Right &&
                tree.State == TreeListState.Regular)
            {
                var pt = tree.PointToClient(mousePosition);
                var info = tree.CalcHitInfo(pt);

                if (info.HitInfoType == HitInfoType.Cell ||
                    info.HitInfoType == HitInfoType.SelectImage)
                {
                    popupMenu.ShowPopup(mousePosition);
                }
            }
        }

        /// <summary>
        /// Clears the sorting and initialize the sort order corresponding to the sequence of the passed columns.
        /// This extension method was added because DevExpress don't support definition of the priority of sorted columns at design time.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="columns">the columns which should be sorted for</param>
        public static void InitializeSortOrder(this TreeList tree, params TreeListColumn[] columns)
        {
            var sortIndex = 0;
            tree.ClearSorting();
            tree.BeginSort();
            foreach (var column in columns)
                column.SortIndex = sortIndex++;
            tree.EndSort();
        }

        /// <summary>
        /// Select node on mouse over
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="e"></param>
        public static void SelectOnMouseOver(this TreeList tree, MouseEventArgs e)
        {
            if (tree != null)
            {
                TreeListHitInfo info = tree.CalcHitInfo(new Point(e.X, e.Y));
                var node = info.HitInfoType == HitInfoType.Cell ? info.Node : null;
                if (node != null) node.Selected = true;
            }
        }
    }
}