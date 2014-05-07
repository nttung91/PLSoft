using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Controls.DXGrids.Column
{
    public class BasicGridColumnCollection : GridColumnCollection
    {
        public BasicGridColumnCollection(ColumnView view) : base(view)
        {
        }

        protected override GridColumn CreateColumn()
        {
            return new BasicGridColumn();
        }
    }
}