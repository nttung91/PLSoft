using System.ComponentModel;
using DevExpress.Utils.Serializing;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Controls.DXGrids.ReadOnly
{
    public class BasicGridOptionsBehaviorReadOnly : GridOptionsBehavior
    {
        [Description("Gets or sets a value specifying whether end-users can apply column moving."), DefaultValue(false),
         XtraSerializableProperty()]
        public override bool Editable
        {
            get { return base.Editable; }
            set { base.Editable = value; }
        }
    }
}