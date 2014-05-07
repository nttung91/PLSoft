using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;

namespace Windows.Core.Export
{
    public class PdfExporter : DxExporterBase
    {
        protected override bool Export(CompositeLink link, string path, ExportOptions options)
        {
            link.ExportToPdf(path, new PdfExportOptions());
            return true;
        }
    }
}