using System;
using Manor.MsExcel.Contracts;
using OfficeOpenXml;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class CellRange : ICellRange
    {
        private readonly ExcelRange _excelRange;

        public CellRange(ExcelRange excelRange)
        {
            _excelRange = excelRange;
        }

        public string Address
        {
            get { return _excelRange.Address; }
        }

        public object Value
        {
            get { return _excelRange.Value; }
            set { _excelRange.Value = value; }
        }

        public string ValueAsString
        {
            get
            {
                string value = null;

                if (_excelRange.Value != null)
                {
                    value = _excelRange.Value.ToString();
                }

                return value;
            }
        }

        public DateTime? ValueAsDate
        {
            get
            {
                if (_excelRange.Value == null)
                    return null;

                var value = _excelRange.GetValue<DateTime>();

                if (value.Equals(DateTime.MinValue))
                    return null;

                return value;
            }
        }

        public Decimal? ValueAsDecimal
        {
            get
            {
                if (_excelRange.Value == null) return null;
                if (!IsDecimal(_excelRange.Value.ToString())) return null;

                return _excelRange.GetValue<Decimal>();
                ;
            }
        }

        private bool IsDecimal(string value)
        {
            decimal output;
            return decimal.TryParse(value, out output);
        }

        public void AutoFitColumns()
        {
            _excelRange.AutoFitColumns();
        }

        public bool AutoFilter
        {
            set { _excelRange.AutoFilter = value; }
        }

        public bool Merge
        {
            set { _excelRange.Merge = value; }
        }


        public IStyle Style
        {
            get { return new Style(_excelRange.Style); }
        }


        public string Formular
        {
            set { _excelRange.Formula = value; }
        }
    }
}