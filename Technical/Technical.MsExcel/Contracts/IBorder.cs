using Manor.MsExcel.Contracts;

namespace Techical.MsExcel.Contracts
{
    public interface IBorder
    {
        IBorderItem Top { get; }
        IBorderItem Bottom { get; }
        IBorderItem Left { get; }
        IBorderItem Right { get; }
    }
}