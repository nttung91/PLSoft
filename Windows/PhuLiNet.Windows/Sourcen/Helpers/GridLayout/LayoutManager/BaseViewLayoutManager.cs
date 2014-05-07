using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;

namespace Windows.Core.Helpers.GridLayout.LayoutManager
{
    /// <summary>
    /// Layout Manager für XtraGrid BaseViews (z.B. GridView and CardView)
    /// </summary>
    public class BaseViewLayoutManager : LayoutManagerBase
    {
        private readonly BaseView _baseView;

        public BaseViewLayoutManager(Form form, BaseView view)
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