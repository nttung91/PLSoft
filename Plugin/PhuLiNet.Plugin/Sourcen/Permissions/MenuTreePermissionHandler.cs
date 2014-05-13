using System.Collections.Generic;
using PhuLiNet.Plugin.Menu;
using PhuLiNet.Plugin.Permissions;

namespace Manor.Plugin.Permissions
{
    internal class MenuTreePermissionHandler
    {
        private readonly List<IMenuItem> _menuList;

        public MenuTreePermissionHandler(List<IMenuItem> menuList)
        {
            _menuList = menuList;
        }

        public void SetVisibility()
        {
            foreach (IMenuItem m in _menuList)
            {
                SetVisibility(m);

                if (m.HasSubMenu)
                {
                    LoopSubMenuItems(m);
                }
            }
        }

        private void SetVisibility(IMenuItem m)
        {
            if (HasPermission(m))
            {
                m.IsVisible = true;
            }
            else
            {
                if (!m.HasVisibleSubMenuItems)
                {
                    m.IsVisible = false;
                }
            }

            if (!m.IsValid)
            {
                m.IsVisible = false;
            }

            if (m.HasPlugin && m.HasPluginAssigned)
            {
                m.Plugin.IsVisible = m.IsVisible;
            }
        }

        private bool HasPermission(IMenuItem menuItem)
        {
            bool hasPermission = false;

            if (menuItem.HasPluginAssigned)
            {
                var permissionHandler = new PermissionHandler();
                hasPermission = permissionHandler.HasPermissionOnPlugin(menuItem.Plugin);
            }

            return hasPermission;
        }

        private void LoopSubMenuItems(IMenuItem menuItem)
        {
            foreach (IMenuItem m in menuItem.SubMenus)
            {
                SetVisibility(m);

                if (m.HasSubMenu)
                {
                    LoopSubMenuItems(m);
                }
            }
        }
    }
}