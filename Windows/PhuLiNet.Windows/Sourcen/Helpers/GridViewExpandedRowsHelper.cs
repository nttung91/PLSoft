using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Helpers
{
    public class GridViewExpandedRowsHelper
    {
        private readonly Dictionary<string, List<int>> _expandedRows;

        public GridViewExpandedRowsHelper()
        {
            _expandedRows = new Dictionary<string, List<int>>();
        }

        public void SaveExpandedRows(GridView gridView, int rowNumber = 0)
        {
            if (gridView == null) return;

            var rowsExpanded = new List<int>();

            // Get number of data rows in the View
            var dataRowCount = gridView.DataRowCount;

            // Traverse View's rows
            for (var rowHandle = 0; rowHandle < dataRowCount; rowHandle++)
            {
                // Get number of master-detail relationships for the current row
                var relationCount = gridView.GetRelationCount(rowHandle);

                // Iterate through master-detail relationships
                for (var relationIndex = 0; relationIndex < relationCount; relationIndex++)
                {
                    // Store expansion status of the corresponding detail View
                    var isMasterRowExpanded = gridView.GetMasterRowExpanded(rowHandle);
                    if (!isMasterRowExpanded)
                        continue;

                    rowsExpanded.Add(rowHandle);

                    // Navigate the detail View
                    var detailView = gridView.GetDetailView(rowHandle, relationIndex) as GridView;
                    if (detailView != null)
                        SaveExpandedRows(detailView, rowHandle);
                }
            }

            _expandedRows.Add(GetUniqueViewname(rowNumber, gridView), rowsExpanded);
        }

        public void RestoreExpandedRows(GridView gridView, int rowNumber = 0)
        {
            if (gridView == null) return;
            gridView.BeginUpdate();

            try
            {
                // Get number of data rows in the View
                var dataRowCount = gridView.RowCount;

                // Traverse View's rows
                for (var rowHandle = 0; rowHandle < dataRowCount; rowHandle++)
                {
                    // Get number of master-detail relationships for the current row
                    var relationCount = gridView.GetRelationCount(rowHandle);

                    // Iterate through master-detail relationships
                    for (var relationIndex = 0; relationIndex < relationCount; relationIndex++)
                    {
                        if (!_expandedRows.ContainsKey((GetUniqueViewname(rowNumber, gridView))))
                            continue;

                        if (!_expandedRows[(GetUniqueViewname(rowNumber, gridView))].Contains(rowHandle))
                            continue;

                        gridView.SetMasterRowExpandedEx(rowHandle, relationIndex, true);

                        var detailView = gridView.GetDetailView(rowHandle, relationIndex) as GridView;
                        if (detailView != null)
                            RestoreExpandedRows(detailView, rowHandle);
                    }
                }
            }
            finally
            {
                // Enable visual updates. 
                gridView.EndUpdate();
            }
        }

        private static string GetUniqueViewname(int rowNumber, GridView gridView)
        {
            return string.Concat(rowNumber, gridView.Name);
        }
    }
}