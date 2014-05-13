using System.Collections.Generic;
using System.Diagnostics;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin.Menu.MainMenu.Repository
{
    internal class PluginMenuRepository : IMenuRepository
    {
        private IList<IPlugin> _plugins; 
        internal PluginMenuRepository(IList<IPlugin> plugins)
        {
            Debug.Assert(plugins != null, "Menu Plug-in is null");

            _plugins = plugins;
        }

        #region IMenuDataAdapter Members

        public List<IMenuItem> Load()
        {
            var menuItems = new List<IMenuItem>();
            int sequenceCounter = 0;
           
            foreach (var plugin in _plugins)
            {
                sequenceCounter++;
                MenuItemBase menuItem = CreateMenuItem(plugin, sequenceCounter);
                menuItems.Add(menuItem);
            }

            return menuItems;
        }

        private MenuItemBase CreateMenuItem(IPlugin node, int sortSequence)
        {
            var menuItem = new MenuItemDefault
            {
                SortSequence = sortSequence,
                Id = node.Id,
                Caption = node.Description,
                Plugin = node
            };
            return menuItem;
        }

        #endregion
    }
}