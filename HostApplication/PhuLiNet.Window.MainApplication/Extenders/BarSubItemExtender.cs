using System.Collections.Generic;
using DevExpress.XtraBars;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Window.MainApplication.Extenders
{
    internal class BarSubItemExtender : IMenuExtender
    {
        private readonly BarManager _barManager;
        private readonly BarSubItem _barSubItemRoot;
        private readonly List<IMenuItem> _menuList;
        private ItemClickEventHandler _linkEventHandler;
        private readonly MenuItemImageHandler _menuItemImageHandler;

        public ItemClickEventHandler ClickEventHandler
        {
            get { return _linkEventHandler; }
            set { _linkEventHandler = value; }
        }

        public BarSubItemExtender(BarManager barManager, BarSubItem barSubItem, List<IMenuItem> menuList)
        {
            _barManager = barManager;
            _barSubItemRoot = barSubItem;
            _menuList = menuList;
            _menuItemImageHandler = new MenuItemImageHandler(MenuItemImageHandler.EImageSize.Small);
        }

        #region IMenuExtender Members

        public void Extend()
        {
            foreach (IMenuItem menuItem in _menuList)
            {
                BarItem item = CreateItem(menuItem);
                if (item != null)
                {
                    _barSubItemRoot.AddItem(item);

                    if (menuItem.HasSubMenu)
                    {
                        CreateSubMenuItems(menuItem, (BarSubItem) item);
                    }
                }
            }
        }

        #endregion

        private void CreateSubMenuItems(IMenuItem menuItem, BarSubItem subItem)
        {
            foreach (IMenuItem m in menuItem.SubMenus)
            {
                BarItem item = CreateItem(m);
                if (item != null)
                {
                    subItem.AddItem(item);

                    if (m.HasSubMenu)
                    {
                        CreateSubMenuItems(m, (BarSubItem) item);
                    }
                }
            }
        }

        private BarItem CreateItem(IMenuItem menuItem)
        {
            BarItem item = null;

            if (menuItem.IsValid && menuItem.IsVisible)
            {
                if (menuItem.HasSubMenu)
                {
                    if (menuItem.HasVisibleSubMenuItems)
                    {
                        item = CreateSubItem(menuItem);
                    }
                }
                else
                {
                    item = CreateButtonItem(menuItem);
                }
            }

            return item;
        }

        private BarButtonItem CreateButtonItem(IMenuItem menuItem)
        {
            var bbi = new BarButtonItem(_barManager, menuItem.Caption);
            bbi.Name = "bbi" + menuItem.Id;
            bbi.Tag = menuItem;
            bbi.Hint = menuItem.ToolTipText;

            if (menuItem.HasPlugin &&
                !string.IsNullOrEmpty(menuItem.Plugin.Shortcut))
            {
                bbi.Hint = menuItem.ToolTipText + " - " + menuItem.Plugin.Shortcut;
            }

            bbi.Glyph = _menuItemImageHandler.GetImage(menuItem);
            bbi.ItemClick += _linkEventHandler;

            return bbi;
        }

        private BarSubItem CreateSubItem(IMenuItem menuItem)
        {
            var bsi = new BarSubItem(_barManager, menuItem.Caption);
            bsi.Name = "bsi" + menuItem.Id;
            bsi.Tag = menuItem;
            bsi.Glyph = _menuItemImageHandler.GetImageForFolder(menuItem);
            return bsi;
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
    }
}