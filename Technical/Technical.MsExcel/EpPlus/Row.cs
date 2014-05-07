using OfficeOpenXml;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Row : IRow
    {
        private readonly ExcelRow _row;

        public Row(ExcelRow row)
        {
            _row = row;
        }

        public double Height
        {
            get { return _row.Height; }
            set { _row.Height = value; }
        }
    }
}