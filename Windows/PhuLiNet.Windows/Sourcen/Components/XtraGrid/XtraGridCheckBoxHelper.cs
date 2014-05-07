using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraGrid.Columns;
using Windows.Core.Helpers;

namespace Windows.Core.Components.XtraGrid
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    public partial class XtraGridCheckBoxHelper : Component
    {
        private GridCheckboxHelper _helper;

        public XtraGridCheckBoxHelper()
        {
            InitializeComponent();
        }

        public XtraGridCheckBoxHelper(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }


        private GridColumn _gridColumn;

        public GridColumn GridColumn
        {
            get { return _gridColumn; }
            set
            {
                _gridColumn = value;
                if (_gridColumn != null)
                {
                    _helper = new GridCheckboxHelper(_gridColumn);
                }
            }
        }
    }
}