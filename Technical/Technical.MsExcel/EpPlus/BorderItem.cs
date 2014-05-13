using Manor.MsExcel.Contracts;
using OfficeOpenXml.Style;
using Techical.MsExcel.Contracts;

namespace Techical.MsExcel.EpPlus
{
    internal class BorderItem : IBorderItem
    {
        private readonly ExcelBorderItem _borderItem;

        public BorderItem(ExcelBorderItem borderItem)
        {
            _borderItem = borderItem;
        }

        public EBorderStyle Style
        {
            set
            {
                switch (value)
                {
                    case EBorderStyle.None:
                        _borderItem.Style = ExcelBorderStyle.None;
                        break;
                    case EBorderStyle.Hair:
                        _borderItem.Style = ExcelBorderStyle.Hair;
                        break;
                    case EBorderStyle.Dotted:
                        _borderItem.Style = ExcelBorderStyle.Dotted;
                        break;
                    case EBorderStyle.DashDot:
                        _borderItem.Style = ExcelBorderStyle.DashDot;
                        break;
                    case EBorderStyle.Thin:
                        _borderItem.Style = ExcelBorderStyle.Thin;
                        break;
                    case EBorderStyle.DashDotDot:
                        _borderItem.Style = ExcelBorderStyle.DashDotDot;
                        break;
                    case EBorderStyle.Dashed:
                        _borderItem.Style = ExcelBorderStyle.Dashed;
                        break;
                    case EBorderStyle.MediumDashDotDot:
                        _borderItem.Style = ExcelBorderStyle.MediumDashDotDot;
                        break;
                    case EBorderStyle.MediumDashed:
                        _borderItem.Style = ExcelBorderStyle.MediumDashed;
                        break;
                    case EBorderStyle.MediumDashDot:
                        _borderItem.Style = ExcelBorderStyle.MediumDashDot;
                        break;
                    case EBorderStyle.Thick:
                        _borderItem.Style = ExcelBorderStyle.Thick;
                        break;
                    case EBorderStyle.Medium:
                        _borderItem.Style = ExcelBorderStyle.Medium;
                        break;
                    case EBorderStyle.Double:
                        _borderItem.Style = ExcelBorderStyle.Double;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}