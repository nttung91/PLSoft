using System.ComponentModel;
using DevExpress.Utils.Serializing;
using DevExpress.XtraGrid.Views.Grid;

namespace Windows.Core.Controls.DXGrids.Common
{
    public class BasicGridOptionsView : GridOptionsView
    {
        [Description("Gets or sets a value specifying whether end-users can apply column moving."), DefaultValue(false),
         XtraSerializableProperty()]
        public override bool ShowGroupPanel
        {
            get { return base.ShowGroupPanel; }
            set { base.ShowGroupPanel = value; }
        }
    }
}