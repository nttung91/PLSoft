using System;
using System.Security;
using System.Windows.Forms;
using Windows.Core.BaseForms;
using Windows.Core.DxExtensions;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Menu;
using PhuLiNet.Window.MainApplication.Executions;
using PhuLiNet.Window.MainApplication.Extenders;

namespace PhuLiNet.Window.MainApplication
{
    public partial class FrmStartForm : FrmBase
    {
        public FrmStartForm()
        {
            InitializeComponent();
        }

        private void FrmStartForm_Load(object sender, System.EventArgs e)
        {
            LoadInit();
        }

        private void LoadInit()
        {
            var hostApplication = HostApplicationFactory.GetInstance();
            InitIcons();
            PopulateMenus();
        }

        private void PopulateMenus()
        {
            PopulateTreeView();
            //PopulateApplicationMenu();
            PopulateToolbars();
        }

        private static void PopulateToolbars()
        {
        }

        //private static void PopulateApplicationMenu()
        //{
        //    var pluginApplication = HostApplicationFactory.GetInstance();
        //    var barSubItemExtender = new BarSubItemExtender(barManager, bsApps, pluginApplication.GetMainMenu())
        //    {
        //        ClickEventHandler = bbiMenuItem_ItemClick
        //    };
        //    barSubItemExtender.Clear();
        //    barSubItemExtender.Extend();
        //}

        private void bbiMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            RunPlugin(e.Item.Tag);
        }

        private void OnTreeClick(object sender, EventArgs e)
        {
            var treeList = sender as TreeList;
            var mouseEventArgs = (MouseEventArgs)e;
            if (treeList == null) return;
            var treeListHitInfo = treeList.CalcHitInfo(mouseEventArgs.Location);

            if (mouseEventArgs.Clicks == 1 &&
                     mouseEventArgs.Button == MouseButtons.Left &&
                     treeListHitInfo.Node != null &&
                     treeListHitInfo.Node.Tag != null)
            {
                if (treeListHitInfo.HitInfoType == HitInfoType.Cell ||
                    treeListHitInfo.HitInfoType == HitInfoType.SelectImage)
                {
                    treeListHitInfo.Node.Selected = true;
                    treeListHitInfo.Node.Expanded = !treeListHitInfo.Node.Expanded;
                }

                RunPlugin(treeListHitInfo.Node.Tag);
            }
        }

        private void RunPlugin(object menuItem)
        {
            var pluginExecutor = PluginExecutor.CreateInstance();
            pluginExecutor.Execute(menuItem);
        }

        private void PopulateTreeView()
        {
            var pluginApplication = HostApplicationFactory.GetInstance();
            var treeListExtender = new TreeListExtender(treeNavigation, pluginApplication.GetMainMenu());
            treeListExtender.Clear();
            treeListExtender.Extend();
        }

        private static void InitIcons()
        {
        }
    }
}
