using DevExpress.XtraGrid.Views.BandedGrid;

namespace Windows.Core.Helpers
{
    public interface IFixableBandColumns
    {
        GridBand LefFixedBand { get; }
        GridBand RightFixedBand { get; }

        FixableColumnHandler FixColHandler { get; }
    }
}