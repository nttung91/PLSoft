using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Csla;
using DevExpress.Spreadsheet;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using Technical.Utilities.Extensions;
using Windows.Core.Forms;
using Windows.Core.Localization;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using Font = System.Drawing.Font;
using FontStyle = System.Drawing.FontStyle;

namespace Windows.Core.Export
{
    public class DxExcelExporter : ExporterBase
    {
        // 1 Point = 4/3 pixel
        private const double Scale = 4.0/3;
        private const int PaddingTopBottom = 0;
        // Distance 
        private const int NameToValueDistance = 70;
        private readonly Font _headerFont = new Font("Tahoma", 12f, FontStyle.Bold, GraphicsUnit.Point);
        private readonly Font _parameterFontNormal = new Font("Tahoma", 8.5f, FontStyle.Regular, GraphicsUnit.Point);
        private readonly Font _parameterFontBold = new Font("Tahoma", 8.5f, FontStyle.Bold, GraphicsUnit.Point);
        private readonly Font _dateFont = new Font("Tahoma", 8.5f, FontStyle.Regular, GraphicsUnit.Point);
        // This value is calculated base on current font is Tahoma, 8.5f. That value depend on default line spacing.
        private const int DefaultLineSpacingInPixels = 6;

        protected override bool Export(CompositeLink link, string path, ExportOptions options)
        {
            var xlsxExportOptions = new XlsxExportOptions
            {
                TextExportMode = options.TextExportMode,
                ShowGridLines = options.ShowGridLines,
                ExportMode = (link.Links.Count == 1) ? XlsxExportMode.SingleFile : XlsxExportMode.SingleFilePageByPage
            };

            link.ExportToXlsx(path, xlsxExportOptions);

            return !options.CustomExcelExport || CustomPrinting(options, path, link);
        }

        protected override void CreateDocument(CompositeLink link)
        {
            if (link.Links.Count > 1)
            {
                link.CreatePageForEachLink();
            }
            else
            {
                base.CreateDocument(link);
            }
        }

        private bool CustomPrinting(ExportOptions options, string path, CompositeLink link)
        {
            try
            {
                ConvertOneAnchorToTwoAnchorShapesForEpplus(path);

                var existingFile = new FileInfo(path);
                using (var excel = new ExcelPackage(existingFile))
                {
                    DefinePrinterSettings(options, excel);

                    var ws = excel.Workbook.Worksheets.First();

                    AddSpaceForCustomHeader(options, ws);
                    DefineTablesForDataInAllWorksheets(excel, link);
                    var dimension = CalculateDimensionOfSheet(ws);

                    InsertDateTime(ws, options, dimension.End.Column);
                    InsertTitle(ws, options, dimension.End.Column);
                    InsertParameters(ws, dimension, options);

                    excel.Save();
                    return true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.ShowWarning(string.Format(General.ExcelExportError, exp.Message));
                return false;
            }
        }

        private int CalculateHeightOfParamterSpace(ExportOptions options, double widthOfFirstTable)
        {
            var widthOfParameterShape =
                (int)
                    GetSizeOfText(
                        options.Parameters.FirstOrDefault(x => x.Key.Length == options.Parameters.Max(m => m.Key.Length))
                            .Key,
                        _parameterFontBold).Width;

            var numberOfOverLengthParameters =
                options.Parameters.Where(
                    x => GetSizeOfText(x.Value, _parameterFontNormal).Width > widthOfFirstTable - widthOfParameterShape)
                    .Sum(
                        x =>
                            Math.Ceiling(GetSizeOfText(x.Value, _parameterFontNormal).Width/
                                         (widthOfFirstTable - widthOfParameterShape)) - 1);

            // Calculate the height for parameter shape. DefaultLineSpacing is dynamic value base on default line-spacing of application.
            var fullHeightInPixels = _parameterFontNormal.Height + DefaultLineSpacingInPixels;
            var paramsHeightInPixels = (fullHeightInPixels*
                                        (options.Parameters.Count + (int) numberOfOverLengthParameters));
            return paramsHeightInPixels;
        }

        private void AddSpaceForCustomHeader(ExportOptions options, ExcelWorksheet ws)
        {
            if (options.Parameters.Count > 0)
            {
                // Set temp value for height. It'll set later.
                InsertEmptyRowOnTop(ws, 100);
            }
            if (!string.IsNullOrEmpty(options.Title))
            {
                InsertEmptyRowOnTop(ws, _headerFont.Height + PaddingTopBottom*2);
            }
            if (options.ShowDateAndUsername)
            {
                InsertEmptyRowOnTop(ws, _dateFont.Height + PaddingTopBottom*2);
            }
        }

        private static double CalculateWidthOfSheet(ExcelWorksheet ws, ExcelAddress dimension)
        {
            double widthOfFirstTable = 0;

            for (var i = dimension.Start.Column; i <= dimension.End.Column; i++)
            {
                widthOfFirstTable += ws.Column(i).Width*7;
            }
            return widthOfFirstTable;
        }

        private static ExcelAddress CalculateDimensionOfSheet(ExcelWorksheet ws)
        {
            ExcelAddress dimension;
            if (ws.Dimension != null)
            {
                var tableRange = new ExcelAddress(ws.Dimension.Address);
                dimension = new ExcelAddress(tableRange.Start.Row, tableRange.Start.Column,
                    tableRange.End.Row, tableRange.End.Column);
            }
            else
            {
                dimension = new ExcelAddress(1, 1, 1, 1);
            }
            return dimension;
        }


        private static void DefinePrinterSettings(ExportOptions options, ExcelPackage excel)
        {
            foreach (var printerSettings in excel.Workbook.Worksheets.Select(worksheet => worksheet.PrinterSettings))
            {
                printerSettings.PaperSize = (ePaperSize) Convert.ToInt32(options.PaperKind);
                printerSettings.Orientation = (options.Landscape) ? eOrientation.Landscape : eOrientation.Portrait;
                // Fit All columns on One Page
                printerSettings.FitToPage = true;
                printerSettings.FitToWidth = 1;
                printerSettings.FitToHeight = 0;
                SetMargins(printerSettings, options);
            }
        }

        private static void SetMargins(ExcelPrinterSettings printerSettings, ExportOptions options)
        {
            printerSettings.BottomMargin = ConvertToPrintUnit(options.Margins.Bottom);
            printerSettings.TopMargin = ConvertToPrintUnit(options.Margins.Top);
            printerSettings.LeftMargin = ConvertToPrintUnit(options.Margins.Left);
            printerSettings.RightMargin = ConvertToPrintUnit(options.Margins.Right);
        }

        /// <summary>
        /// Convert to print unit in inch.
        /// </summary>
        private static decimal ConvertToPrintUnit(int value)
        {
            return new decimal(value/100.0);
        }

        private static void ConvertOneAnchorToTwoAnchorShapesForEpplus(string path)
        {
            var file = new FileInfo(path);
            if (file.Exists)
            {
                var workbook = new Workbook();
                if (!workbook.LoadDocument(file.FullName))
                {
                    return;
                }
                foreach (var shape in workbook.Worksheets.SelectMany(sheet => sheet.Shapes))
                {
                    shape.Placement = Placement.MoveAndSize;
                }
                workbook.SaveDocument(file.FullName, DocumentFormat.OpenXml);
            }
        }

        private void InsertDateTime(ExcelWorksheet ws, ExportOptions options, int col)
        {
            if (!options.ShowDateAndUsername) return;

            var row = GetPositionOfData(options, 0);
            ws.Cells[row + 1, 1].Value = string.Format("{0:G} {1}", DateTime.Now,
                ApplicationContext.User.Identity.NameWithoutDomain());
            ws.Cells[row + 1, 1].Style.Font.Size = _dateFont.Size;
            ws.Cells[row + 1, 1].Style.Font.Name = _dateFont.OriginalFontName;
            ws.Cells[row + 1, 1, row + 1, col].Merge = true;
            ws.Cells[row + 1, 1, row + 1, col].Style.Font.Bold = _dateFont.Bold;
            ws.Cells[row + 1, 1, row + 1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            ws.Cells[row + 1, 1, row + 1, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        private void InsertTitle(ExcelWorksheet ws, ExportOptions options, int col)
        {
            if (string.IsNullOrEmpty(options.Title)) return;

            var row = GetPositionOfData(options, 1);
            ws.Cells[row + 1, 1].Value = options.Title;
            ws.Cells[row + 1, 1].Style.Font.Size = _headerFont.Size;
            ws.Cells[row + 1, 1].Style.Font.Bold = _headerFont.Bold;
            ws.Cells[row + 1, 1].Style.Font.Name = _headerFont.OriginalFontName;
            ws.Cells[row + 1, 1, row + 1, col].Merge = true; //Merge columns start and end range

            ws.Cells[row + 1, 1, row + 1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells[row + 1, 1, row + 1, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
        }

        /// <summary>
        /// Get row position will base on input data. Zero-base.
        /// </summary>
        /// <param name="options">Excel Options</param>
        /// <param name="type">
        /// Type = 0: DateTime
        /// Type = 1: Title
        /// Type = 2: Parameters
        /// </param>
        private static int GetPositionOfData(ExportOptions options, int type)
        {
            switch (type)
            {
                case 0:
                    return options.ShowDateAndUsername ? 0 : -1;
                case 1:
                    return GetPositionOfData(options, 0) + (string.IsNullOrEmpty(options.Title) ? 0 : 1);
                case 2:
                    return GetPositionOfData(options, type - 1) + 1;
            }
            return -1;
        }

        private void InsertParameters(ExcelWorksheet ws, ExcelAddress dimension, ExportOptions options)
        {
            if (options.Parameters.Count == 0 || dimension == null) return;

            var widthOfFirstSheet = (int) CalculateWidthOfSheet(ws, dimension);
            var paramsHeightInPixels = CalculateHeightOfParamterSpace(options, widthOfFirstSheet);

            // Set height for parameters
            var paramHeightInPoints = paramsHeightInPixels/Scale;
            ws.Row(GetPositionOfData(options, 2) + 1).Height = paramHeightInPoints + PaddingTopBottom*2;

            // Create 2 shape, one for Parameter, one for parameter values
            var shape = ws.Drawings.AddShape("Parameters", eShapeStyle.Rect);
            var shapeValues = ws.Drawings.AddShape("ParametersValue", eShapeStyle.Rect);

            var widthOfParameterShape =
                (int) options.Parameters.Max(m => GetSizeOfText(m.Key, _parameterFontBold).Width) + NameToValueDistance;

            // Determine where to add parameter values-shape
            var column = 0;
            double sum = 0;
            var offset = 0;
            for (var i = dimension.Start.Column; i <= dimension.End.Column; i++)
            {
                var colWidth = ws.Column(i).Width*7;
                if (sum + colWidth >= widthOfParameterShape)
                {
                    offset = (int) (widthOfParameterShape - sum);
                    break;
                }
                sum += colWidth;
                column++;
            }

            var row = GetPositionOfData(options, 2);

            shape.SetPosition(row, PaddingTopBottom, 0, 0);
            shape.SetSize(widthOfParameterShape, paramsHeightInPixels);
            SetStyleForShape(_parameterFontBold, shape);

            shapeValues.SetPosition(row, PaddingTopBottom, column, offset);
            shapeValues.SetSize(widthOfFirstSheet - widthOfParameterShape, paramsHeightInPixels);
            SetStyleForShape(_parameterFontNormal, shapeValues);
            foreach (var pair in options.Parameters)
            {
                var isLastParameter = options.Parameters.ElementAt(options.Parameters.Count - 1).Key == pair.Key;
                HandleAndPrintData(shape, shapeValues, pair.Key, pair.Value, widthOfFirstSheet - widthOfParameterShape,
                    !isLastParameter);
            }
        }

        private SizeF GetSizeOfText(string text, Font font)
        {
            var g = Graphics.FromImage(new Bitmap(1, 1));
            return g.MeasureString(text, font);
        }

        private static void SetStyleForShape(Font font, ExcelShape shape)
        {
            shape.Fill.Style = eFillStyle.SolidFill;
            shape.Fill.Color = Color.White;

            shape.Border.Fill.Style = eFillStyle.NoFill;
            shape.TextAnchoring = eTextAnchoringType.Top;
            shape.TextVertical = eTextVerticalType.Horizontal;
            shape.TextAnchoringControl = false;
            shape.Font.Color = Color.Black;
            shape.Font.LatinFont = font.OriginalFontName;
            shape.Font.Bold = font.Bold;
            shape.Font.Size = font.Size;
        }

        private static void PrintData(ExcelShape shape, string data, Font font, bool isAddNewLine)
        {
            var title = shape.RichText.Add(data);
            title.LatinFont = font.OriginalFontName;
            title.Size = font.Size;
            title.Bold = font.Bold;
            if (isAddNewLine)
            {
                shape.RichText.Add(Environment.NewLine);
            }
        }

        private void HandleAndPrintData(ExcelShape shape, ExcelShape shapeValues, string key, string text, int maxLength,
            bool isAddNewLine)
        {
            var words = text.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var line = string.Empty;
            var isFirstLine = true;
            foreach (var word in words)
            {
                if (GetSizeOfText(line + word, _parameterFontNormal).Width > maxLength)
                {
                    var keyData = isFirstLine ? key : " ";
                    PrintData(shape, keyData, _parameterFontBold, true);
                    PrintData(shapeValues, line, _parameterFontNormal, true);
                    line = word + " ";
                    isFirstLine = false;
                }
                else
                {
                    line += word + " ";
                }
            }
            if (!string.IsNullOrEmpty(line))
            {
                var keyData = isFirstLine ? key : " ";
                PrintData(shape, keyData, _parameterFontBold, isAddNewLine);
                PrintData(shapeValues, line, _parameterFontNormal, isAddNewLine);
            }
        }

        private static void InsertEmptyRowOnTop(ExcelWorksheet ws, float height)
        {
            ws.InsertRow(1, 1);
            var row = ws.Row(1);
            row.CustomHeight = true;
            row.Height = height;
        }

        private static void DefineTablesForDataInAllWorksheets(ExcelPackage excel, CompositeLink link)
        {
            for (var i = 1; i <= excel.Workbook.Worksheets.Count; i++)
            {
                var ws = excel.Workbook.Worksheets[i];

                if (ws.Dimension == null || !CanDefineTable(link, i))
                {
                    continue;
                }

                var tableRange = new ExcelAddress(ws.Dimension.Address);
                tableRange = new ExcelAddress(tableRange.Start.Row, tableRange.Start.Column,
                    tableRange.End.Row, tableRange.End.Column);

                // Check if there is any row in the table. Otherwise, don't create one.
                if (tableRange.Start.Row != tableRange.End.Row)
                {
                    var table = ws.Tables.Add(tableRange, ws.Name);
                    table.ShowHeader = true;
                    table.TableStyle = TableStyles.Medium23;
                }
            }
        }

        private static bool CanDefineTable(CompositeLinkBase compositeLink, int worksheetNumber)
        {
            if (compositeLink.Links.Count < worksheetNumber)
            {
                return false;
            }

            var link = compositeLink.Links[worksheetNumber - 1] as PrintableComponentLink;
            if (link != null && link.Component is GridControl)
            {
                var gridControl = link.Component as GridControl;
                // the table definition only works for Gridviews, which are not banded.
                return gridControl.FocusedView is GridView && !(gridControl.FocusedView is BandedGridView);
            }
            return false;
        }
    }
}