using System.Collections.Generic;
using DevExpress.XtraBars;
using PhuLiNet.Plugin;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class ToolbarExtender : IMenuExtender
    {
        private readonly BarManager _barManager;
        private readonly List<IMenuItem> _menuList;
        private ItemClickEventHandler _linkEventHandler;
        private readonly MenuItemImageHandler _menuItemImageHandler;

        public ItemClickEventHandler ClickEventHandler
        {
            get { return _linkEventHandler; }
            set { _linkEventHandler = value; }
        }

        public ToolbarExtender(BarManager barManager, List<IMenuItem> menuList)
        {
            _barManager = barManager;
            _menuList = menuList;
            _menuItemImageHandler = new MenuItemImageHandler(MenuItemImageHandler.EImageSize.Small);
        }

        #region IMenuExtender Members

        public void Extend()
        {
            foreach (IMenuItem menuItem in _menuList)
            {
                Bar toolBar = CreateToolbar(menuItem);
                if (toolBar != null)
                {
                    if (menuItem.HasSubMenu)
                    {
                        CreateBarButtons(menuItem, toolBar);
                    }
                }
            }
        }

        public void Clear()
        {
            for (int i = _barManager.Items.Count - 1; i >= 0; i--)
            {
                var barSubItem = _barManager.Items[i];
                if (barSubItem.Tag is IMenuItem)
                {
                    barSubItem.ItemClick -= null;
                    _barManager.Items.RemoveAt(i);
                }
            }
        }

        #endregion

        private Bar CreateToolbar(IMenuItem menuItem)
        {
            var toolBar = new Bar(_barManager, menuItem.Id);
            toolBar.Text = menuItem.Caption;
            toolBar.DockStyle = BarDockStyle.Top;
            toolBar.CanDockStyle = BarCanDockStyle.Top;
            toolBar.OptionsBar.DrawDragBorder = false;
            toolBar.DockRow = 1;
            return toolBar;
        }

        private void CreateBarButtons(IMenuItem menuItem, Bar toolBar)
        {
            foreach (IMenuItem m in menuItem.SubMenus)
            {
                BarItem item = CreateButtonItem(m);
                if (item != null)
                {
                    toolBar.AddItem(item);

                    if (m.HasSubMenu)
                    {
                        throw new PluginHostException(
                            "ToolBar does not support sub menu levels greater than 1. Please check your menu config file.");
                    }
                }
            }
        }

        private BarButtonItem CreateButtonItem(IMenuItem menuItem)
        {
            var bbi = new BarButtonItem(_barManager, menuItem.Caption);
            bbi.Name = "bbi" + menuItem.Id;
            bbi.Tag = menuItem;
            bbi.Hint = menuItem.ToolTipText;

            if (menuItem.HasPlugin && menuItem.HasPluginAssigned && !string.IsNullOrEmpty(menuItem.Plugin.Shortcut))
            {
                bbi.Hint = menuItem.ToolTipText + " - " + menuItem.Plugin.Shortcut;
            }
            bbi.Glyph = _menuItemImageHandler.GetImage(menuItem);
            bbi.ItemClick += _linkEventHandler;

            return bbi;
        }
    }
}