using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace Windows.Core.Export
{
    public class PrintExporter : DxExporterBase
    {
        protected override void SetCommandVisibility(PrintingSystem ps)
        {
            ps.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None);
            ps.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None);
        }

        protected override bool Export(CompositeLink link, string path, ExportOptions options)
        {
            link.ShowPreview();
            return true;
        }
    }
}