using System.Collections.Generic;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;

namespace Windows.Core.Export
{
    public class ExportOptions
    {
        // Default margins with Top-Bottom ~= 1.91cm, Left-Right ~= 1.78cm; 
        private readonly Margins _defaultMargins = new Margins(70, 70, 75, 75);
        private Margins _margins;

        public bool CustomExcelExport { get; set; }
        public bool Landscape { get; set; }
        public PaperKind PaperKind { get; set; }
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
        public string Title { get; set; }
        public bool ShowGridLines { get; set; }

        public Margins Margins
        {
            get { return _margins ?? _defaultMargins; }
            set { _margins = value; }
        }

        public TextExportMode TextExportMode { get; set; }
        public bool ShowDateAndUsername { get; set; }
        public int AutoFitToPagesWidth { get; set; }
        public bool BestFitColumnWidth { get; set; }

        public ExportOptions()
        {
            CustomExcelExport = true;
            AutoFitToPagesWidth = 0;
            BestFitColumnWidth = true;
        }
    }
}