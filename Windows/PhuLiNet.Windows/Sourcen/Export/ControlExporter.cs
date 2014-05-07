using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using Technical.Settings;
using Technical.Utilities.Helpers;
using Windows.Core.BaseForms;
using Windows.Core.Commands;
using Windows.Core.Localization;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Export
{
    public class ControlExporter
    {
        private const string ExportName = "Export";

        #region Properties

        public IList<IPrintable> ControlsToExport { get; set; }
        public ExportType ExportType { get; set; }
        public string SaveFileName { get; set; }
        public ExportOptions ExportOptions { get; set; }

        #endregion

        public ControlExporter()
        {
            SaveFileName = string.Empty;

            ExportOptions = new ExportOptions
            {
                Landscape = false,
                PaperKind = PaperKind.A4,
                Margins = new Margins(40, 40, 40, 40),
                ShowGridLines = true,
                TextExportMode = TextExportMode.Text,
                ShowDateAndUsername = false,
                Parameters = new Dictionary<string, string>()
            };
        }

        public void Export()
        {
            if (ControlsToExport == null || !ControlsToExport.Any()) return;

            var printingSystem = new PrintingSystem();

            if (ExportType == ExportType.XLSX || ExportType == ExportType.PDF)
            {
                DoExport(ControlsToExport, printingSystem);
            }
            else
            {
                for (var i = 0; i < ControlsToExport.Count; i++)
                {
                    CreateSingleDocument(printingSystem, ControlsToExport[i]);
                    SaveFileName = string.Format("{0}{1}", ExportName,
                        (i == 0) ? string.Empty : i.ToString(CultureInfo.InvariantCulture));
                    DoExport(null, printingSystem);
                }
            }
        }

        private void DoExport(IList<IPrintable> controlsToExport, PrintingSystem printingSystem)
        {
            var saveFileDialog = OpenSaveFileDialog();
            if (saveFileDialog == null) return;
            ExporterBase exporter;
            var openExportedFile = true;

            switch (ExportType)
            {
                case ExportType.XLS:
                    var optXls = new XlsExportOptions
                    {
                        ShowGridLines = ExportOptions.ShowGridLines,
                        TextExportMode = ExportOptions.TextExportMode
                    };
                    printingSystem.ExportToXls(saveFileDialog.FileName, optXls);
                    break;

                case ExportType.XLSX:
                    exporter = new DxExcelExporter();
                    openExportedFile = exporter.Export(controlsToExport, saveFileDialog.FileName, ExportOptions);
                    break;

                case ExportType.PDF:
                    exporter = new PdfExporter();
                    openExportedFile = exporter.Export(controlsToExport, saveFileDialog.FileName, ExportOptions);
                    break;

                case ExportType.TXT:
                    printingSystem.ExportToText(saveFileDialog.FileName);
                    break;

                case ExportType.RTF:
                    printingSystem.ExportToRtf(saveFileDialog.FileName);
                    break;
            }

            if (openExportedFile)
            {
                CommandExecutor.Execute(new CommandShowExternalFile(saveFileDialog.FileName));
            }
            SavePath(saveFileDialog.FileName);
        }

        private SaveFileDialog OpenSaveFileDialog()
        {
            var saveFileDialog = InitSaveDialog(ExportType, SaveFileName);

            var dialogResult = GetDialogResult(saveFileDialog);
            if (dialogResult != DialogResult.OK) return null;

            if (!FileHelper.IsAccessible(saveFileDialog.FileName))
            {
                MessageBox.ShowInfo(string.Format(HelperRes.FileAlreadyOpen, saveFileDialog.FileName),
                    HelperRes.FileExport);
                return null;
            }
            return saveFileDialog;
        }

        internal SaveFileDialog InitSaveDialog(ExportType exportType, string fileName)
        {
            var saveFileDialog = new SaveFileDialog {CheckFileExists = false};
            switch (exportType)
            {
                case ExportType.XLSX:
                    saveFileDialog.Filter = HelperRes.ExportTypeXlsx;
                    break;
                case ExportType.XLS:
                    saveFileDialog.Filter = HelperRes.ExportTypeXls;
                    break;
                case ExportType.PDF:
                    saveFileDialog.Filter = HelperRes.ExportTypePdf;
                    break;
                case ExportType.TXT:
                    saveFileDialog.Filter = HelperRes.ExportTypeTxt;
                    break;
                case ExportType.RTF:
                    saveFileDialog.Filter = HelperRes.ExportTypeRtf;
                    break;
            }

            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");
            saveFileDialog.InitialDirectory = section.GetSetting("GridExportPath", @"u:\").Value;

            saveFileDialog.FileName = string.IsNullOrEmpty(fileName) ? ExportName : fileName;

            return saveFileDialog;
        }

        internal DialogResult GetDialogResult(SaveFileDialog saveFileDialog)
        {
            var dialogResult = DialogResult.No;

            try
            {
                dialogResult = saveFileDialog.ShowDialog();
            }
            catch (InvalidOperationException)
            {
                MessageBox.ShowInfo(string.Format(HelperRes.FileNameInvalid, saveFileDialog.FileName),
                    HelperRes.FileExport);
            }
            return dialogResult;
        }

        private void SavePath(string fileName)
        {
            var path = Path.GetDirectoryName(fileName);

            var settingsProvider = Provider.Get();
            var section = settingsProvider.LoadSection("BasicWindowSettings");

            if (path == section.GetSetting("GridExportPath", @"u:\").Value)
                return;

            section.GetSetting<string>("GridExportPath").Value = path;
            settingsProvider.SaveSection(section);
        }

        private void CreateSingleDocument(PrintingSystem printingSystem, IPrintable component)
        {
            var pclA4 = new PrintableComponentLink
            {
                PaperKind = ExportOptions.PaperKind,
                PrintingSystem = printingSystem,
                Margins = ExportOptions.Margins,
                Landscape = ExportOptions.Landscape,
                Component = component
            };
            pclA4.CreateDocument();
        }
    }
}