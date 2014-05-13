using System.Collections.Generic;
using System.Diagnostics;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Manager;
using PhuLiNet.Plugin.Menu;
using PhuLiNet.Plugin.Menu.Plugins;

namespace PhuLiNet.Plugin
{
    /// <summary>
    /// Zuweisung von konkreten Plugins zu Menüpunkten
    /// </summary>
    internal class PluginAllocator
    {
        private readonly IPluginManager _pluginManager;

        public PluginAllocator(IPluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public void AssignPluginsToMenu(IEnumerable<IMenuItem> menuItems)
        {
            AssignPlugins(menuItems);
        }

        private void AssignPlugins(IEnumerable<IMenuItem> menuItemList)
        {
            if (menuItemList != null)
            {
                foreach (IMenuItem menuItem in menuItemList)
                {
                    if (menuItem is MenuItemDefault) AssignPlugin((MenuItemDefault) menuItem);
                }
            }
        }

        private void AssignPlugin(MenuItemDefault menuItem)
        {
            if (menuItem.PluginId != null &&
                !menuItem.HasPluginAssigned)
            {
                IPlugin plugin = _pluginManager.GetPlugin(menuItem.PluginId);

                if (plugin != null)
                {
                    menuItem.Plugin = plugin;
                    menuItem.Caption = plugin.Description;
                    menuItem.Image = plugin.Image;
                    menuItem.ToolTipText = plugin.Description;
                }
            }
        }
    }
}