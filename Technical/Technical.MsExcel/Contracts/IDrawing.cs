namespace Manor.MsExcel.Contracts
{
    public interface IDrawing
    {
        void SetPosition(int row, int rowOffsetPixels, int column, int columnOffsetPixels);

        void SetSize(int percent);
        void SetSize(int pixelWidth, int pixelHeight);

        IDrawingPosition PositionFrom { get; }
        IDrawingPosition PositionTo { get; }
    }
}