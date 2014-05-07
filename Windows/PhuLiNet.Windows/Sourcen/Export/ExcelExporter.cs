using System;
using System.Collections.Generic;
using System.Drawing;
using Csla;
using DevExpress.XtraGrid.Views.Grid;
using Manor.MsExcel;
using Manor.MsExcel.Contracts;
using Technical.Utilities.Helpers;
using Windows.Core.Forms;
using Windows.Core.Localization;

namespace Windows.Core.Export
{
    public class ExcelExporter
    {
        #region Fields/Constants

        private const string DefaultName = "Export";
        private readonly string _title;
        private readonly IDictionary<string, string> _parameters;
        private readonly GridView _gridView;
        private readonly string _fileName;
        private int _rowIndex;
        private int _numOfCols;

        #endregion

        #region Properties

        public bool IsExportOk { get; set; }
        public string ErrorMsg { get; set; }
        public string SheetName { get; set; }

        #endregion

        public ExcelExporter(string fileName, string title, IDictionary<string, string> parameters, GridView gridView)
        {
            _title = title;
            _parameters = parameters;
            _gridView = gridView;
            _fileName = fileName;
            SheetName = title ?? DefaultName;
        }

        public void Export()
        {
            IsExportOk = false;
            ErrorMsg = null;
            if (!FileHelper.IsAccessible(_fileName))
            {
                MessageBox.ShowInfo(string.Format(HelperRes.FileAlreadyOpen, _fileName), HelperRes.FileExport);
                return;
            }

            using (var excel = MsExcelWrapperFactory.GetDefaultInstance())
            {
                var workbook = excel.Create(_fileName, SheetName, true);
                var worksheet = workbook.Worksheets[0];

                if (_title != null)
                    AddTitle(worksheet);

                if (_parameters != null && _parameters.Count > 0)
                    AddParams(worksheet);

                if (_gridView.DataRowCount > 0)
                {
                    _numOfCols = _gridView.VisibleColumns.Count;

                    AddHeadings(worksheet);

                    for (var r = 0; r <= _gridView.RowCount; r++)
                    {
                        _rowIndex++;
                        var rowHandle = _gridView.GetVisibleRowHandle(r);
                        for (var c = 0; c < _numOfCols; c++)
                        {
                            var val = _gridView.GetRowCellValue(rowHandle, _gridView.VisibleColumns[c]);
                            if (val is DateTime)
                            {
                                worksheet.GetCell(_rowIndex, c + 1).Value = string.Format("{0:G}", val);
                            }
                            else
                            {
                                worksheet.GetCell(_rowIndex, c + 1).Value = val;
                            }
                        }
                    }
                }

                //autofit all columns
                var range = worksheet.GetCellRange(1, 1, _rowIndex, _numOfCols);
                range.AutoFitColumns();

                worksheet.Orientation = EPrintOrientation.Landscape;
                worksheet.FitToWidth = true;

                excel.Save();
                excel.Dispose();

                IsExportOk = true;
            }
        }

        private void AddTitle(IWorksheet worksheet)
        {
            _rowIndex++;
            worksheet.GetCell(_rowIndex, 1).Value = _title;
            var range = worksheet.GetCellRange(_rowIndex, 1, _rowIndex, 2);
            range.Style.Font.Bold = true;
            range.Style.Font.Size = 16;

            // datum / User
            worksheet.GetCell(_rowIndex, 4).Value = string.Format("{0:G}", DateTime.Now);
            worksheet.GetCell(_rowIndex, 5).Value = ApplicationContext.User.Identity.Name;

            // leer Zeile
            _rowIndex++;
        }

        private void AddParams(IWorksheet worksheet)
        {
            var startRow = _rowIndex + 1;
            foreach (var parameter in _parameters)
            {
                _rowIndex++;
                worksheet.GetCell(_rowIndex, 1).Value = parameter.Key;
                worksheet.GetCell(_rowIndex, 2).Value = parameter.Value;
            }
            var range = worksheet.GetCellRange(startRow, 1, _rowIndex, 1);
            range.Style.Font.Bold = true;

            // leer Zeile
            _rowIndex++;
        }

        private void AddHeadings(IWorksheet worksheet)
        {
            _rowIndex++;
            for (int c = 0; c < _numOfCols; c++)
            {
                worksheet.GetCell(_rowIndex, c + 1).Value = _gridView.VisibleColumns[c].Caption;
            }
            var range = worksheet.GetCellRange(_rowIndex, 1, _rowIndex, _numOfCols);
            range.Style.Fill.PatternType = EFillStyle.Solid;
            range.Style.Fill.BackgroundColor = Color.LightGray;
        }
    }
}