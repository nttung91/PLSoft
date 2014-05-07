using System;

namespace Windows.Core.Dynamic
{
    [Serializable]
    public class GridOptions : IGridOptions, ICloneable
    {
        public ColumnOptions ColumnOptions { get; set; }
        public BandOptions BandOptions { get; set; }

        public GridOptions()
        {
            BandOptions = new BandOptions();
            ColumnOptions = new ColumnOptions();
        }

        public object Clone()
        {
            return new GridOptions
            {
                ColumnOptions = (ColumnOptions) ColumnOptions.Clone(),
                BandOptions = (BandOptions) BandOptions.Clone()
            };
        }
    }
}