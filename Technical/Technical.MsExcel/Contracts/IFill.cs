using System.Drawing;

namespace Manor.MsExcel.Contracts
{
    public interface IFill
    {
        EFillStyle PatternType { set; }
        Color BackgroundColor { set; }
    }
}