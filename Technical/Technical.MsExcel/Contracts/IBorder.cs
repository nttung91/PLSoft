namespace Manor.MsExcel.Contracts
{
    public interface IBorder
    {
        IBorderItem Top { get; }
        IBorderItem Bottom { get; }
        IBorderItem Left { get; }
        IBorderItem Right { get; }
    }
}