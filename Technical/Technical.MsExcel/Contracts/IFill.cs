using System.Drawing;
using Techical.MsExcel.Contracts;

namespace Manor.MsExcel.Contracts
{
    public interface IFill
    {
        EFillStyle PatternType { set; }
        Color BackgroundColor { set; }
    }
}