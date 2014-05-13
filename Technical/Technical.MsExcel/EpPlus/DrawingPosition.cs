using Manor.MsExcel.Contracts;
using OfficeOpenXml.Drawing;

namespace Techical.MsExcel.EpPlus
{
    internal class DrawingPosition : IDrawingPosition
    {
        private readonly ExcelDrawing.ExcelPosition _position;

        public DrawingPosition(ExcelDrawing.ExcelPosition position)
        {
            _position = position;
        }

        public int Column
        {
            get { return _position.Column; }
        }

        public int Row
        {
            get { return _position.Row; }
        }
    }
}