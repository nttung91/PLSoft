using Manor.MsExcel.Contracts;
using OfficeOpenXml.Style;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class NumberFormat : INumberFormat
    {
        private readonly ExcelNumberFormat _numberFormat;

        public NumberFormat(ExcelNumberFormat numberFormat)
        {
            _numberFormat = numberFormat;
        }

        public string Format
        {
            set { _numberFormat.Format = value; }
        }
    }
}