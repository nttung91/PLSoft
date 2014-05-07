using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Windows.Core.Controls.DXGrids.Column;
using Windows.Core.Controls.DXGrids.Common;

namespace Windows.Core.Controls.DXGrids.ReadOnly
{
    public class BasicGridViewReadOnly : GridView
    {
        public BasicGridViewReadOnly() : this(null)
        {
        }

        public BasicGridViewReadOnly(GridControl grid) : base(grid)
        {
            OptionsBehavior.Editable = false;
            OptionsCustomization.AllowColumnMoving = false;
            OptionsCustomization.AllowFilter = false;
            OptionsCustomization.AllowGroup = false;
            OptionsView.ShowGroupPanel = false;
        }

        protected override string ViewName
        {
            get { return BasicViewName; }
        }

        public static string BasicViewName
        {
            get { return "BasicGridViewReadOnly"; }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new BasicGridColumnCollection(this);
        }

        protected override GridOptionsCustomization CreateOptionsCustomization()
        {
            return new BasicGridOptionsCustomization();
        }

        protected override ColumnViewOptionsView CreateOptionsView()
        {
            return new BasicGridOptionsView();
        }

        protected override ColumnViewOptionsBehavior CreateOptionsBehavior()
        {
            return new BasicGridOptionsBehaviorReadOnly();
        }
    }
}