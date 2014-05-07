using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using Windows.Core.Dynamic;
using Techical.Dynamic.Property;

namespace Windows.Core.Dynamic
{
    public interface IGridCreateParameters
    {
        /// <summary>
        /// Create dynamic bands/columns under this GridBand 
        /// Either ExistingBand or ExistingGridView have to be set
        /// </summary>
        GridBand ExistingBand { get; set; }

        /// <summary>
        /// Create dynamic bands/columns under this GridView
        /// Either ExistingBand or ExistingGridView have to be set
        /// </summary>
        BandedGridView ExistingGridView { get; set; }

        /// <summary>
        /// Get view from ExistingBand or ExistingGridView
        /// </summary>
        BaseView GetView();

        IDynamicPropertyList HeaderList { get; set; }
        IGridOptions Options { get; set; }
    }
}