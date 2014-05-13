using System.Collections.Generic;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal class MenuValidator
    {
        private readonly List<IMenuItem> _menuList;
        private readonly Dictionary<string, IMenuItem> _menuItemDictionary;

        public MenuValidator(List<IMenuItem> menuList)
        {
            _menuList = menuList;
            _menuItemDictionary = new Dictionary<string, IMenuItem>();
        }

        public void Validate()
        {
            LoopMenuItems();
        }

        private void LoopMenuItems()
        {
            foreach (IMenuItem m in _menuList)
            {
                AddToDictionary(m);
                LoopMenuSubItems(m);
            }
        }

        private void LoopMenuSubItems(IMenuItem menuItem)
        {
            if (menuItem.SubMenus != null)
            {
                foreach (IMenuItem m in menuItem.SubMenus)
                {
                    AddToDictionary(m);
                    LoopMenuSubItems(m);
                }
            }
        }

        private void AddToDictionary(IMenuItem menuItem)
        {
            if (!_menuItemDictionary.ContainsKey(menuItem.Id))
            {
                _menuItemDictionary.Add(menuItem.Id, menuItem);
            }
            else
            {
                throw new PluginHostException(
                    string.Format("MenuItem Id [{0}] is not unique. Please check your menu config file.", menuItem.Id));
            }
        }
    }
}