using Manor.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Border : IBorder
    {
        private readonly OfficeOpenXml.Style.Border _border;

        public Border(OfficeOpenXml.Style.Border border)
        {
            _border = border;
        }

        public IBorderItem Top
        {
            get { return new BorderItem(_border.Top); }
        }

        public IBorderItem Bottom
        {
            get { return new BorderItem(_border.Bottom); }
        }

        public IBorderItem Left
        {
            get { return new BorderItem(_border.Left); }
        }

        public IBorderItem Right
        {
            get { return new BorderItem(_border.Right); }
        }
    }
}