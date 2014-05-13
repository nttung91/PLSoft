using Manor.MsExcel.Contracts;
using OfficeOpenXml;

namespace Techical.MsExcel.EpPlus
{
    internal class Column : IColumn
    {
        private readonly ExcelColumn _column;

        public Column(ExcelColumn column)
        {
            _column = column;
        }

        public double Width
        {
            get { return _column.Width; }
            set { _column.Width = value; }
        }
    }
}