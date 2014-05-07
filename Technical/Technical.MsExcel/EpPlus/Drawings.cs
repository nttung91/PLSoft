using System.Drawing;
using Manor.MsExcel.Contracts;
using OfficeOpenXml.Drawing;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Drawings : IDrawings
    {
        private readonly ExcelDrawings _drawings;

        public Drawings(ExcelDrawings drawings)
        {
            _drawings = drawings;
        }

        public IPicture AddPicture(string name, Image image)
        {
            var picture = new Picture(_drawings.AddPicture(name, image));
            return picture;
        }

        public int Count
        {
            get { return _drawings.Count; }
        }


        public IDrawing GetDrawing(int index)
        {
            IDrawing drawing = null;

            if (_drawings[index] is ExcelPicture)
            {
                drawing = new Picture(_drawings[index]);
            }
            else
            {
                drawing = new Drawing(_drawings[index]);
            }

            return drawing;
        }
    }
}