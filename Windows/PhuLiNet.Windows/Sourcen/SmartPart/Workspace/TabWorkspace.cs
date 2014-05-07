using System.Windows.Forms;
using DevExpress.XtraBars;
using Windows.Core.SmartPart.Controls;
using Windows.Core.SmartPart.Manager;

namespace Windows.Core.SmartPart.Workspace
{
    public partial class TabWorkspace : UserControl, IWorkspace
    {
        private ISmartPartManager _smartPartManager;
        private ISmartPartPlaceholder _placeholder;
        private bool _initDone = false;

        public ISmartPartManager SmartPartManager
        {
            get { return _smartPartManager; }
            set { _smartPartManager = value; }
        }

        public TabWorkspace()
        {
            InitializeComponent();
            _placeholder = smartPartPlaceholder as ISmartPartPlaceholder;
        }

        private void AddBarButtonItems()
        {
            foreach (ISmartPart smartPart in _smartPartManager.GetSmartParts())
            {
                var barButton = new BarButtonItem(barManager, smartPart.DisplayName);
                barButton.ItemClick += new ItemClickEventHandler(barButton_ItemClick);
                barButton.Tag = smartPart.Key;

                barSmartParts.AddItem(barButton);
            }
        }

        private void RemoveBarButtonItems()
        {
        }

        private void barButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            _placeholder.SmartPart = _smartPartManager.GetSmartPart(e.Item.Tag.ToString());
        }

        #region IWorkspace Members

        public ISmartPart CurrentSmartPart
        {
            get { return _placeholder.SmartPart; }
        }

        public bool InitWorkspaceDone
        {
            get { return _initDone; }
        }

        public void InitWorkspace()
        {
            AddBarButtonItems();
        }

        public void DeinitWorkspace()
        {
            RemoveBarButtonItems();

            _smartPartManager.DeinitAll();
        }

        public void DestroyWorkspace()
        {
            _smartPartManager.DestroyAll();
        }

        public void ShowSmartPart(string key)
        {
            _placeholder.SmartPart = _smartPartManager.GetSmartPart(key);
        }

        #endregion
    }
}