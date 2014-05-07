using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Controls.DXGrids.ReadOnly
{
    public class BasicGridViewInfoRegistratorReadOnly : GridInfoRegistrator
    {
        public override string ViewName
        {
            get { return BasicGridViewReadOnly.BasicViewName; }
        }

        public override BaseView CreateView(GridControl grid)
        {
            return new BasicGridViewReadOnly(grid as GridControl);
        }
    }
}