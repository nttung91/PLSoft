using Manor.MsExcel.Contracts;
using OfficeOpenXml.Drawing;

namespace Techical.MsExcel.EpPlus
{
    internal class Drawing : IDrawing
    {
        protected ExcelDrawing _excelDrawing;

        public Drawing(ExcelDrawing excelDrawing)
        {
            _excelDrawing = excelDrawing;
        }

        public void SetPosition(int row, int rowOffsetPixels, int column, int columnOffsetPixels)
        {
            _excelDrawing.SetPosition(row, rowOffsetPixels, column, columnOffsetPixels);
        }

        public void SetSize(int percent)
        {
            _excelDrawing.SetSize(percent);
        }

        public void SetSize(int pixelWidth, int pixelHeight)
        {
            _excelDrawing.SetSize(pixelWidth, pixelHeight);
        }

        public IDrawingPosition PositionFrom
        {
            get { return new DrawingPosition(_excelDrawing.From); }
        }

        public IDrawingPosition PositionTo
        {
            get { return new DrawingPosition(_excelDrawing.To); }
        }
    }
}