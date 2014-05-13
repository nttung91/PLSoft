using System.Drawing;
using Manor.MsExcel.Contracts;
using OfficeOpenXml.Style;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class Fill : IFill
    {
        private readonly ExcelFill _fill;

        public Fill(ExcelFill fill)
        {
            _fill = fill;
        }

        public Color BackgroundColor
        {
            set { _fill.BackgroundColor.SetColor(value); }
        }

        public EFillStyle PatternType
        {
            set
            {
                switch (value)
                {
                    case EFillStyle.None:
                        _fill.PatternType = ExcelFillStyle.None;
                        break;
                    case EFillStyle.Solid:
                        _fill.PatternType = ExcelFillStyle.Solid;
                        break;
                    case EFillStyle.DarkGray:
                        _fill.PatternType = ExcelFillStyle.DarkGray;
                        break;
                    case EFillStyle.MediumGray:
                        _fill.PatternType = ExcelFillStyle.MediumGray;
                        break;
                    case EFillStyle.LightGray:
                        _fill.PatternType = ExcelFillStyle.LightGray;
                        break;
                    case EFillStyle.Gray125:
                        _fill.PatternType = ExcelFillStyle.Gray125;
                        break;
                    case EFillStyle.Gray0625:
                        _fill.PatternType = ExcelFillStyle.Gray0625;
                        break;
                    case EFillStyle.DarkVertical:
                        _fill.PatternType = ExcelFillStyle.DarkVertical;
                        break;
                    case EFillStyle.DarkHorizontal:
                        _fill.PatternType = ExcelFillStyle.DarkHorizontal;
                        break;
                    case EFillStyle.DarkDown:
                        _fill.PatternType = ExcelFillStyle.DarkDown;
                        break;
                    case EFillStyle.DarkUp:
                        _fill.PatternType = ExcelFillStyle.DarkUp;
                        break;
                    case EFillStyle.DarkGrid:
                        _fill.PatternType = ExcelFillStyle.DarkGrid;
                        break;
                    case EFillStyle.DarkTrellis:
                        _fill.PatternType = ExcelFillStyle.DarkTrellis;
                        break;
                    case EFillStyle.LightVertical:
                        _fill.PatternType = ExcelFillStyle.LightVertical;
                        break;
                    case EFillStyle.LightHorizontal:
                        _fill.PatternType = ExcelFillStyle.LightHorizontal;
                        break;
                    case EFillStyle.LightDown:
                        _fill.PatternType = ExcelFillStyle.LightDown;
                        break;
                    case EFillStyle.LightUp:
                        _fill.PatternType = ExcelFillStyle.LightUp;
                        break;
                    case EFillStyle.LightGrid:
                        _fill.PatternType = ExcelFillStyle.LightGrid;
                        break;
                    case EFillStyle.LightTrellis:
                        _fill.PatternType = ExcelFillStyle.LightTrellis;
                        break;
                    default:
                        _fill.PatternType = ExcelFillStyle.None;
                        break;
                }
            }
        }
    }
}