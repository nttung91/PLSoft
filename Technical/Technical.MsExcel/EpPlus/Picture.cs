using System.Drawing;
using OfficeOpenXml.Drawing;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Picture : Drawing, IPicture
    {
        public Picture(ExcelDrawing excelDrawing) : base(excelDrawing)
        {
        }

        public Image Image
        {
            get { return ((ExcelPicture) _excelDrawing).Image; }
        }
    }
}