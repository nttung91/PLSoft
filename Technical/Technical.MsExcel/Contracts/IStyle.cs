using Manor.MsExcel.Contracts;

namespace Techical.MsExcel.Contracts
{
    public interface IStyle
    {
        IFont Font { get; }
        IBorder Border { get; }
        IFill Fill { get; }
        INumberFormat NumberFormat { get; }
        EHorizontalAlignment HorizontalAlignment { set; }
    }
}