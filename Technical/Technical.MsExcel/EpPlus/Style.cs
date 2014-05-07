using Manor.MsExcel.Contracts;
using OfficeOpenXml.Style;
using Techical.MsExcel.Contracts;
using Border = Techical.MsExcel.EpPlus.Border;

namespace Techical.MsExcel.EpPlus
{
    internal class Style : IStyle
    {
        private readonly ExcelStyle _excelStyle;

        public Style(ExcelStyle excelStyle)
        {
            _excelStyle = excelStyle;
        }

        public IFont Font
        {
            get { return new Font(_excelStyle.Font); }
        }

        public IBorder Border
        {
            get { return new Border(_excelStyle.Border); }
        }


        public IFill Fill
        {
            get { return new Fill(_excelStyle.Fill); }
        }


        public EHorizontalAlignment HorizontalAlignment
        {
            set
            {
                switch (value)
                {
                    case EHorizontalAlignment.General:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.General;
                        break;
                    case EHorizontalAlignment.Left:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        break;
                    case EHorizontalAlignment.Center:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        break;
                    case EHorizontalAlignment.CenterContinuous:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        break;
                    case EHorizontalAlignment.Right:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                        break;
                    case EHorizontalAlignment.Fill:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Fill;
                        break;
                    case EHorizontalAlignment.Distributed:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Distributed;
                        break;
                    case EHorizontalAlignment.Justify:
                        _excelStyle.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                        break;
                    default:
                        break;
                }
            }
        }


        public INumberFormat NumberFormat
        {
            get { return new NumberFormat(_excelStyle.Numberformat); }
        }
    }
}