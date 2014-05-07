using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace Windows.Core.Helpers.GridLayout.LayoutManager
{
    /// <summary>
    /// Layout Manager für PivotGrid
    /// </summary>
    public class PivotGridLayoutManager : LayoutManagerBase
    {
        private readonly PivotGridControl _pivotGrid;

        public PivotGridLayoutManager(Form form, PivotGridControl pivotGrid)
        {
            Debug.Assert(pivotGrid != null, "pivotGrid is null");
            Debug.Assert(pivotGrid.Name != null, "pivotGrid.Name is null");
            Debug.Assert(form != null, "form is null");

            _pivotGrid = pivotGrid;
            HostForm = form;

            LayoutTypeInternal = "PivotGrid";
            ViewNameInternal = _pivotGrid.Name;
        }

        public override void SaveLayout()
        {
            var layoutStream = new MemoryStream();
            _pivotGrid.SaveLayoutToStream(layoutStream);
            SaveLayoutToDataStore(layoutStream);
        }

        public override void RestoreLayout()
        {
            var layoutStream = RestoreLayoutFromDataStore();
            if (layoutStream != null) _pivotGrid.RestoreLayoutFromStream(layoutStream);
        }
    }
}