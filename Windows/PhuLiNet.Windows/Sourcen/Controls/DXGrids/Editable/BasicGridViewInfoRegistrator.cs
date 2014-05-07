using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Controls.DXGrids.Editable
{
    public class BasicGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get { return BasicGridView.BasicViewName; }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new BasicGridView(grid as GridControl);
        }
    }
}