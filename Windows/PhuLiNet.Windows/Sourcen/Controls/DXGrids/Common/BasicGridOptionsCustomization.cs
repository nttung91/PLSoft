using System.ComponentModel;
using DevExpress.Utils.Serializing;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Controls.DXGrids.Common
{
    public class BasicGridOptionsCustomization : GridOptionsCustomization
    {
        [Description("Gets or sets a value specifying whether end-users can apply column moving."), DefaultValue(false),
         XtraSerializableProperty()]
        public override bool AllowColumnMoving
        {
            get { return base.AllowColumnMoving; }
            set { base.AllowColumnMoving = value; }
        }

        [Description("Gets or sets a value specifying whether end-users can apply data filtering."), DefaultValue(false),
         XtraSerializableProperty()]
        public override bool AllowFilter
        {
            get { return base.AllowFilter; }
            set { base.AllowFilter = value; }
        }

        [Description("Gets or sets a value specifying whether end-users can apply data grouping."), DefaultValue(false),
         XtraSerializableProperty()]
        public override bool AllowGroup
        {
            get { return base.AllowGroup; }
            set { base.AllowGroup = value; }
        }
    }
}