namespace Manor.MsExcel.Contracts
{
    public interface IFont
    {
        string Name { get; set; }
        bool Bold { get; set; }
        float Size { get; set; }
    }
}