using Windows.Core.Dynamic;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using Techical.Dynamic.Property;

namespace Windows.Core.Dynamic
{
    public class GridColumnParameters : IGridCreateParameters
    {
        /// <summary>
        /// Create dynamic bands/columns under this GridBand 
        /// </summary>
        public GridBand ExistingBand { get; set; }

        /// <summary>
        /// Create dynamic bands/columns under this GridView
        /// </summary>
        public BandedGridView ExistingGridView { get; set; }

        public BaseView GetView()
        {
            if (ExistingBand != null && ExistingBand.View != null)
            {
                return ExistingBand.View;
            }
            return ExistingGridView;
        }

        public IDynamicPropertyList HeaderList { get; set; }
        public IGridOptions Options { get; set; }

        public GridColumnParameters()
        {
        }

        public GridColumnParameters(GridBand existingBand, IDynamicPropertyList headerList)
        {
            ExistingBand = existingBand;
            HeaderList = headerList;
            Options = new GridOptions();
        }
    }
}