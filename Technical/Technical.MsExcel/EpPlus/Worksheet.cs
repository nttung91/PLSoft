using System;
using Manor.MsExcel.Contracts;
using OfficeOpenXml;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Worksheet : IWorksheet
    {
        private readonly ExcelWorksheet _worksheet;

        public Worksheet(ExcelWorksheet worksheet)
        {
            if (worksheet == null)
            {
                throw new ApplicationException("Parameter worksheet null");
            }
            _worksheet = worksheet;
        }

        public string Name
        {
            get { return _worksheet.Name; }
            set { _worksheet.Name = value; }
        }

        public int LastRow
        {
            get { return _worksheet.Dimension.End.Row; }
        }

        public int LastColumn
        {
            get { return _worksheet.Dimension.End.Column; }
        }

        public ICellRange GetCell(int row, int col)
        {
            return new CellRange(_worksheet.Cells[row, col]);
        }

        public ICellRange GetCellRange(int fromRow, int fromCol, int toRow, int toCol)
        {
            return new CellRange(_worksheet.Cells[fromRow, fromCol, toRow, toCol]);
        }

        public IDrawings Drawings
        {
            get { return new Drawings(_worksheet.Drawings); }
        }


        public IRow Row(int row)
        {
            return new Row(_worksheet.Row(row));
        }


        public IColumn Column(int column)
        {
            return new Column(_worksheet.Column(column));
        }

        public void FreezePanes(int row, int column)
        {
            _worksheet.View.FreezePanes(row + 1, column + 1);
        }

        public EPrintOrientation Orientation
        {
            set
            {
                switch (value)
                {
                    case EPrintOrientation.Portrait:
                        _worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
                        break;
                    case EPrintOrientation.Landscape:
                        _worksheet.PrinterSettings.Orientation = eOrientation.Landscape;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                switch (_worksheet.PrinterSettings.Orientation)
                {
                    case eOrientation.Portrait:
                        return EPrintOrientation.Portrait;
                    default:
                        return EPrintOrientation.Landscape;
                }
            }
        }

        public bool FitToPage
        {
            get { return _worksheet.PrinterSettings.FitToPage; }
            set { _worksheet.PrinterSettings.FitToPage = value; }
        }

        public bool FitToWidth
        {
            get { return (_worksheet.PrinterSettings.FitToWidth == 1); }
            set
            {
                if (value)
                {
                    _worksheet.PrinterSettings.FitToPage = true;
                    _worksheet.PrinterSettings.FitToWidth = 1;
                    _worksheet.PrinterSettings.FitToHeight = 0;
                }
                else
                {
                    _worksheet.PrinterSettings.FitToWidth = 0;
                }
            }
        }
    }
}