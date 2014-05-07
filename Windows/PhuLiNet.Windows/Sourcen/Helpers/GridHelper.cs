using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Design;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Windows.Core.Helpers
{
    public static class GridHelper
    {
        //Layoutstyles für XtraGrid
        private static XAppearances _gvScheme;

        public static XAppearances GvScheme
        {
            get
            {
                return _gvScheme ??
                       (_gvScheme =
                           new XAppearances(Path.Combine(Application.StartupPath, "DevExpress.XtraGrid.Appearances.xml")));
            }
        }

        //Layoutstyles für Xtra Vertical Grid
        private static DevExpress.XtraVerticalGrid.Design.XAppearances _vgScheme;

        public static DevExpress.XtraVerticalGrid.Design.XAppearances VgScheme
        {
            get
            {
                return _vgScheme ??
                       (_vgScheme =
                           new DevExpress.XtraVerticalGrid.Design.XAppearances(Path.Combine(Application.StartupPath,
                               "DevExpress.XtraVerticalGrid.Appearances.xml")));
            }
        }

        /// <summary>
        /// Gibt true zurück wenn die view im Inserting Mode ist
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static bool IsInserting(GridView view)
        {
            return view.FocusedRowHandle == GridControl.NewItemRowHandle;
        }

        /// <summary>
        /// Focus auf erste Row setzen die dem val entspricht
        /// </summary>
        /// <param name="view"></param>
        /// <param name="column"></param>
        /// <param name="val"></param>
        public static void FocusRowByValue(GridView view, GridColumn column, object val)
        {
            int rowHandle = view.LocateByValue(0, column, val);
            if (rowHandle != GridControl.InvalidRowHandle)
                view.FocusedRowHandle = rowHandle;
        }

        /// <summary>
        /// Focus auf letzte Row setzen die dem val entspricht
        /// </summary>
        /// <param name="view"></param>
        /// <param name="column"></param>
        /// <param name="val"></param>
        public static void FocusLastRowByValue(GridView view, GridColumn column, object val)
        {
            int? setRowHandle = null;
            int rowHandle = 0;
            while ((rowHandle = view.LocateByValue(rowHandle, column, val)) != GridControl.InvalidRowHandle)
            {
                setRowHandle = rowHandle;
                rowHandle++;
            }

            if (setRowHandle.HasValue)
                view.FocusedRowHandle = setRowHandle.Value;
        }

        /// <summary>
        /// Gibt die Rowhandle an Position pos zurück die den Wert val in der Spalte colName hat
        /// </summary>
        /// <param name="view"></param>
        /// <param name="colName"></param>
        /// <param name="val"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static int LocateRowByIntValue(GridView view, string colName, object val, int pos)
        {
            int res = -1;
            var col = view.Columns[colName];
            view.GridControl.Refresh();
            int rowHandle = view.LocateByValue(pos, col, val);
            if (rowHandle != GridControl.InvalidRowHandle)
            {
                res = rowHandle;
            }
            return res;
        }

        /// <summary>
        /// Alle Rows werden auf den Inhalt von mehreren Spalten geprüft, Start bei Row 0
        /// Wird die erste Row gefunden, dann wird der Focus auf die Row gesetzt
        /// </summary>
        /// <param name="view"></param>
        /// <param name="colNames">Spalten Liste</param>
        /// <param name="vals">Inhalt der Spalte</param>
        public static void LocateRowByVal(GridView view, string[] colNames, object[] vals)
        {
            int dataRowCount = view.DataRowCount;
            bool match = false;
            int currentRowHandle = 0;
            while (!match)
            {
                int i = 0;
                match = true;
                // Prüfen aller Spalten
                foreach (string colName in colNames)
                {
                    if (!view.GetRowCellValue(currentRowHandle, view.Columns[colName]).Equals(vals[i++]))
                        match = false;
                }
                if (currentRowHandle++ == dataRowCount - 1)
                    break;
            }
            if (match) view.FocusedRowHandle = currentRowHandle;
        }

        /// <summary>
        /// Wenn der Focus auf einer Datarow oder am einfügen ist, dann true, sonst false
        /// Z.B. wenn man auf einer Grouprow oder Filterrow ist oder der Rowhandle invalid ist
        /// </summary>
        /// <param name="view">View</param>
        /// <returns></returns>
        public static bool IsDataRow(GridView view)
        {
            // Die erste Row hat die Handle 0, mit dem if nehmen wir also nur Rows welche 
            // Erfassungsdaten haben, es wird auch invalidRowHandle (-9999999) ignoriert
            return (view.FocusedRowHandle == GridControl.NewItemRowHandle ||
                    view.FocusedRowHandle >= 0);
        }

        public static bool IsDataRow(GridView view, int row)
        {
            // Die erste Row hat die Handle 0, mit dem if nehmen wir also nur Rows welche 
            // Erfassungsdaten haben, es wird auch invalidRowHandle (-9999999) ignoriert
            return (row == GridControl.NewItemRowHandle ||
                    row >= 0);
        }

        public static int GetDataRowCount(GridView view)
        {
            int drCount = 0;
            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRow(i) != null) drCount++;
            }

            return drCount;
        }

        /// <summary>
        /// Gibt eine List mit den Bound Gridcolumns eines Bandes zurück
        /// </summary>
        /// <returns></returns>
        public static List<GridColumn> GridBandColumnList(GridBand band)
        {
            var gcs = new List<GridColumn>();
            foreach (GridColumn gc in band.Columns)
                if (gc.UnboundType.Equals(UnboundColumnType.Bound))
                    gcs.Add(gc);
            return gcs;
        }

        public static void ExpandAllRows(GridView view)
        {
            view.BeginUpdate();
            try
            {
                int dataRowCount = view.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    view.SetMasterRowExpanded(rHandle, true);
            }
            finally
            {
                view.EndUpdate();
            }
        }

        public static bool EndEditGrid(GridControl grid)
        {
            if (grid == null || grid.FocusedView == null) return true;

            if (grid.FocusedView.IsEditing)
            {
                if (!grid.FocusedView.ValidateEditor()) return false;
                grid.FocusedView.CloseEditor();
            }

            return grid.FocusedView.UpdateCurrentRow();
        }

        public static void ExpandAllMasterRows(GridView gv, bool expand)
        {
            for (int rowhandle = 0; rowhandle < gv.DataRowCount; rowhandle++)
            {
                if (expand)
                {
                    gv.ExpandMasterRow(rowhandle, 0);
                }
                else
                {
                    gv.CollapseMasterRow(rowhandle);
                }
            }
        }

        public static GridColumn GetHitColumn(GridHitInfo hi, GridBand gbFixed, GridBand gbVariable, int offset)
        {
            int totalWidth = gbFixed.Width + offset;
            int colIdx = 0;

            for (int i = 0; i < gbVariable.Columns.Count; i++)
            {
                if (!gbVariable.Columns[i].Visible) continue;

                totalWidth += gbVariable.Columns[i].Width;
                if (hi.HitPoint.X < totalWidth)
                {
                    colIdx = i;
                    break;
                }
            }

            if (hi.HitPoint.X > gbFixed.Width + gbVariable.Width + offset)
            {
                colIdx = gbVariable.Columns.Count - 1;
            }

            return gbVariable.Columns[colIdx];
        }

        /// <summary>
        /// Ermittelt alle sichtbaren Datenzeilen und gibt die Grid Row Handles zurück
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static IList<int> GetVisibleRowHandles(GridView view)
        {
            var visibleDataRowHandles = new List<int>();

            for (int i = 0; i < view.RowCount; i++)
            {
                var rowHandle = view.GetVisibleRowHandle(i);
                if (view.IsDataRow(rowHandle))
                {
                    visibleDataRowHandles.Add(rowHandle);
                }
            }

            return visibleDataRowHandles;
        }

        /// <summary>
        /// Ermittelt alle sichtbaren Datenzeilen und gibt den Datasource Index zurück
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static IList<int> GetVisibleDatasourceIndexList(GridView view)
        {
            var visibleDataSourceIndexList = new List<int>();

            for (int i = 0; i < view.RowCount; i++)
            {
                var rowHandle = view.GetVisibleRowHandle(i);
                if (view.IsDataRow(rowHandle))
                {
                    var dataSourceIndex = view.GetDataSourceRowIndex(rowHandle);
                    visibleDataSourceIndexList.Add(dataSourceIndex);
                }
            }

            return visibleDataSourceIndexList;
        }
    }
}