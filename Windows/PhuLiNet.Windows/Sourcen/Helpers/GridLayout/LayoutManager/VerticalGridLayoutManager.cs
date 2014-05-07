using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraVerticalGrid;

namespace Windows.Core.Helpers.GridLayout.LayoutManager
{
    /// <summary>
    /// Layout Manager für VerticalGrids
    /// </summary>
    public class VerticalGridLayoutManager : LayoutManagerBase
    {
        private readonly VGridControlBase _verticalGrid;

        public VerticalGridLayoutManager(Form form, VGridControlBase verticalGrid)
        {
            Debug.Assert(verticalGrid != null, "verticalGrid is null");
            Debug.Assert(verticalGrid.Name != null, "verticalGrid.Name is null");
            Debug.Assert(form != null, "form is null");

            _verticalGrid = verticalGrid;
            HostForm = form;

            LayoutTypeInternal = "VerticalGrid";
            ViewNameInternal = _verticalGrid.Name;
        }

        public override void SaveLayout()
        {
            var layoutStream = new MemoryStream();
            _verticalGrid.SaveLayoutToStream(layoutStream);
            SaveLayoutToDataStore(layoutStream);
        }

        public override void RestoreLayout()
        {
            var layoutStream = RestoreLayoutFromDataStore();
            if (layoutStream != null) _verticalGrid.RestoreLayoutFromStream(layoutStream);
        }
    }
}