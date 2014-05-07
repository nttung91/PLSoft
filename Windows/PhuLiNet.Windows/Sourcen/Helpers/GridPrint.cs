using System.Drawing.Printing;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using Windows.Core.Export;
using ExportOptions = Windows.Core.Export.ExportOptions;

namespace Windows.Core.Helpers
{
    public static class GridPrint
    {
        public static void PrintGrid(GridControl gridControl)
        {
            PrintComponent(gridControl, true);
        }

        public static void PrintGrid(GridControl gridControl, bool landscape)
        {
            PrintComponent(gridControl, landscape);
        }

        public static void PrintPivotGrid(PivotGridControl pivotGrid)
        {
            PrintComponent(pivotGrid, true);
        }

        public static void PrintPivotGrid(PivotGridControl pivotGrid, bool landscape)
        {
            PrintComponent(pivotGrid, landscape);
        }

        public static void PrintComponent(IPrintable printableComponent, bool landscape)
        {
            var exporter = new PrintExporter();
            var options = new ExportOptions
            {
                Landscape = landscape,
                PaperKind = PaperKind.A4,
                Margins = new Margins(40, 40, 40, 40)
            };
            exporter.Export(printableComponent, string.Empty, options);
        }
    }
}