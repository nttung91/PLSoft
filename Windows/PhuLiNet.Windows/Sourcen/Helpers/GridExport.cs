using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using Windows.Core.BaseForms;
using Windows.Core.Export;
using ExportOptions = Windows.Core.Export.ExportOptions;

namespace Windows.Core.Helpers
{
    public static class GridExport
    {
        public static void ExportGrid(BaseView gridView, ExportType exportType)
        {
            ExportGrid(new List<BaseView> {gridView}, exportType);
        }

        public static void ExportGrid(IList<BaseView> gridViews, ExportType exportType)
        {
            var controlsToExport = gridViews.Select(control => control.GridControl).Cast<IPrintable>().ToList();
            ExportComponent(controlsToExport, exportType);
        }

        public static void ExportGrid(GridControl gridControl, ExportType exportType, bool landscape)
        {
            ExportComponent(gridControl, exportType, landscape);
        }

        public static void ExportGrid(IList<GridControl> gridControls, ExportType exportType, bool landscape)
        {
            var controlsToExport = gridControls.Cast<IPrintable>().ToList();
            ExportComponent(controlsToExport, exportType, landscape);
        }

        internal static void ExportGrid(IPrintable printable, ExportType exportType)
        {
            ExportComponent(printable, exportType);
        }

        /// <summary>
        /// This method is used to export a component which is IPrintable (e.g. GridView, TreeList...)
        /// </summary>
        public static void ExportComponent(IPrintable printableControl, ExportType exportType, bool landscape = false)
        {
            ExportComponent(new List<IPrintable> {printableControl}, exportType, landscape);
        }

        public static void ExportComponent(IPrintable printableControl, ExportType exportType,
            ExportOptions exportOptions)
        {
            ExportComponent(new List<IPrintable> {printableControl}, exportType, exportOptions);
        }

        /// <summary>
        /// This method is used to export those components which are IPrintable (e.g. GridView, TreeList...)
        /// </summary>
        public static void ExportComponent(IList<IPrintable> controlsToExport, ExportType exportType,
            bool landscape = false)
        {
            new ControlExporter
            {
                ControlsToExport = controlsToExport,
                ExportType = exportType,
                ExportOptions = {Landscape = landscape}
            }.Export();
        }

        public static void ExportComponent(IList<IPrintable> controlsToExport, ExportType exportType,
            ExportOptions exportOptions)
        {
            new ControlExporter
            {
                ControlsToExport = controlsToExport,
                ExportType = exportType,
                ExportOptions = exportOptions
            }.Export();
        }
    }
}