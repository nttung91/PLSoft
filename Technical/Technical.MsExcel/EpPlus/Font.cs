using Manor.MsExcel.Contracts;
using OfficeOpenXml.Style;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Font : IFont
    {
        private readonly ExcelFont _excelFont;

        public Font(ExcelFont excelFont)
        {
            _excelFont = excelFont;
        }

        public string Name
        {
            get { return _excelFont.Name; }
            set { _excelFont.Name = value; }
        }

        public bool Bold
        {
            get { return _excelFont.Bold; }
            set { _excelFont.Bold = value; }
        }

        public float Size
        {
            get { return _excelFont.Size; }
            set { _excelFont.Size = value; }
        }
    }
}