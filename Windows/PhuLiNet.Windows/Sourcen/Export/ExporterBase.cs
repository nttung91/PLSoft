using System.Collections.Generic;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.XtraTreeList;

namespace Windows.Core.Export
{
    public abstract class ExporterBase
    {
        public bool Export(IPrintable component, string path, ExportOptions options)
        {
            return Export(new List<IPrintable> {component}, path, options);
        }

        public bool Export(IList<IPrintable> components, string path, ExportOptions options)
        {
            var layouts = PrepareControl(components, options.BestFitColumnWidth);

            var ps = new PrintingSystem();

            var compLink = new CompositeLink
            {
                PrintingSystem = ps
            };

            SetCommandVisibility(ps);

            foreach (var component in components)
            {
                var link = new PrintableComponentLink
                {
                    PrintingSystem = ps,
                    Landscape = options.Landscape,
                    PaperKind = options.PaperKind,
                    Margins = options.Margins,
                    Component = component
                };
                compLink.Links.Add(link);

                BeforeCreatingPage(link, options);
            }

            CreateDocument(compLink);
            ps.Document.AutoFitToPagesWidth = options.AutoFitToPagesWidth;

            ps.PageSettings.PaperKind = options.PaperKind;
            ps.PageSettings.Landscape = options.Landscape;

            var result = Export(compLink, path, options);

            if (layouts != null)
            {
                RestoreLayout(layouts, components, options.BestFitColumnWidth);
            }
            return result;
        }

        private static IList<MemoryStream> PrepareControl(IEnumerable<IPrintable> components, bool bestFitColumnWidth)
        {
            var result = new List<MemoryStream>();
            foreach (var component in components)
            {
                var memStr = new MemoryStream();

                var gridControl = component as GridControl;
                if (gridControl != null)
                {
                    if (!PrepareGridView(bestFitColumnWidth, gridControl, memStr)) return null;
                }
                else if (bestFitColumnWidth)
                {
                    if (!PrepareTreeList(component, memStr)) return null;
                }

                result.Add(memStr);
            }

            return result;
        }

        private static bool PrepareGridView(bool bestFitColumnWidth, GridControl gridControl, MemoryStream memStr)
        {
            var view = gridControl.FocusedView;
            var gridView = view as GridView;
            if (gridView == null) return false;

            gridView.SaveLayoutToStream(memStr);

            gridView.OptionsPrint.UsePrintStyles = true;
            gridView.AppearancePrint.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Near;
            gridView.OptionsView.ColumnAutoWidth = !bestFitColumnWidth;
            gridView.OptionsPrint.AutoWidth = !bestFitColumnWidth;
            gridView.BestFitColumns();
            return true;
        }

        private static bool PrepareTreeList(IPrintable component, Stream memStr)
        {
            var treeList = component as TreeList;
            if (treeList == null) return false;

            treeList.SaveLayoutToStream(memStr);
            treeList.BestFitColumns();
            return true;
        }

        private static void RestoreLayout(IList<MemoryStream> memStrs, IList<IPrintable> components,
            bool bestFitColumnWidth)
        {
            for (var i = 0; i < components.Count; i++)
            {
                var gridControl = components[i] as GridControl;
                memStrs[i].Seek(0, SeekOrigin.Begin);
                if (gridControl != null)
                {
                    if (!RestoreGridViewLayout(memStrs, gridControl, i)) return;
                }
                else if (bestFitColumnWidth)
                {
                    if (!RestoreTreeListLayout(memStrs, components, i)) return;
                }
            }
        }

        private static bool RestoreGridViewLayout(IList<MemoryStream> memStrs, GridControl gridControl, int index)
        {
            var view = gridControl.FocusedView;
            var gridView = view as GridView;
            if (gridView == null) return false;

            var focusedRowHandle = gridView.FocusedRowHandle;
            gridView.RestoreLayoutFromStream(memStrs[index]);
            if (focusedRowHandle > 0)
            {
                gridView.FocusedRowHandle = focusedRowHandle;
            }
            return true;
        }

        private static bool RestoreTreeListLayout(IList<MemoryStream> memStrs, IList<IPrintable> components, int index)
        {
            var treeList = components[index] as TreeList;
            if (treeList == null) return false;

            var focusedNode = treeList.FocusedNode;
            treeList.RestoreLayoutFromStream(memStrs[index]);
            if (focusedNode != null)
            {
                treeList.FocusedNode = focusedNode;
            }
            return true;
        }

        protected abstract bool Export(CompositeLink link, string path, ExportOptions options);

        protected virtual void BeforeCreatingPage(PrintableComponentLink link, ExportOptions options)
        {
        }

        protected virtual void SetCommandVisibility(PrintingSystem ps)
        {
        }

        protected virtual void CreateDocument(CompositeLink link)
        {
            link.CreateDocument();
        }
    }
}