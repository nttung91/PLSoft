using System.Collections.Generic;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using Windows.Core.BaseForms;
using Windows.Core.Export;
using Windows.Core.Forms;
using Windows.Core.Localization;

namespace Windows.Core.Helpers
{
    public static class PivotGridExport
    {
        public static void ExportPivotGrid(PivotGridControl pivotGrid, ExportType exportType)
        {
            ExportPivotGrid(pivotGrid, exportType, false);
        }

        public static void ExportPivotGrid(PivotGridControl pivotGrid, ExportType exportType, bool exportModeText)
        {
            ExportPivotGrid(pivotGrid, exportType, exportModeText, string.Empty);
        }

        public static void ExportPivotGrid(PivotGridControl pivotGrid, ExportType exportType, bool exportModeText,
            string fileName)
        {
            if (exportType == ExportType.XLS)
            {
                //----------------------------------------------------------------------------------------------------------------------------//
                // DevExpress prueft offenbar nicht, ob die Anzahl Rows (<= 65536) oder ob die Anzahl Columns (<= 256) in's Excel passt.
                // Deshalb machen wir das hier selbst. 
                //Wenn Office2007 ausgerollt ist,  kann der Check wieder entfernt werden, da Excel2007 mehr Rows (und Columns?) verkraftet.
                //----------------------------------------------------------------------------------------------------------------------------//

                if (pivotGrid.Cells.ColumnCount > 256 || pivotGrid.Cells.RowCount > 65536)
                {
                    MessageBox.ShowInfo(HelperRes.ExcelExportTooManyData, HelperRes.ExcelExport);
                    return;
                }
            }
            new ControlExporter
            {
                ControlsToExport = new List<IPrintable> {pivotGrid},
                ExportType = exportType,
                SaveFileName = fileName,
                ExportOptions =
                {
                    TextExportMode = exportModeText ? TextExportMode.Text : TextExportMode.Value,
                    ShowGridLines = true
                }
            }.Export();
        }
    }
}