using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Windows.Core.Controls.Adapters;

namespace Windows.Core.Helpers.GridLayout.LayoutManager
{
    /// <summary>
    /// Layout Manager für LayoutControl-Wrapper
    /// </summary>
    public class ListControlLayoutManager : LayoutManagerBase
    {
        private readonly ListControlAdapter _baseView;

        public ListControlLayoutManager(Form form, ListControlAdapter view)
        {
            Debug.Assert(view != null, "view is null");
            Debug.Assert(view.Name != null, "view.Name is null");
            Debug.Assert(form != null, "form is null");

            _baseView = view;
            HostForm = form;

            LayoutTypeInternal = "BaseView";
            ViewNameInternal = _baseView.Name;
        }

        public override void SaveLayout()
        {
            var layoutStream = new MemoryStream();
            _baseView.SaveLayoutToStream(layoutStream);
            SaveLayoutToDataStore(layoutStream);
        }

        public override void RestoreLayout()
        {
            var layoutStream = RestoreLayoutFromDataStore();
            if (layoutStream != null) _baseView.RestoreLayoutFromStream(layoutStream);
        }
    }
}