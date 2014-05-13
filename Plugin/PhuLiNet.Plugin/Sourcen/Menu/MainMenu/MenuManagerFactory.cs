using System.Collections.Generic;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Menu.MainMenu.Repository;

namespace PhuLiNet.Plugin.Menu.MainMenu
{
    internal static class MenuManagerFactory
    {
        internal static IMenuManager CreateInstanceByPlugin(List<IPlugin> list)
        {
            var repository = new PluginMenuRepository(list);
            var menuManager = new MenuManager { MenuRepository = repository };
            menuManager.Init();
            menuManager.Cleanup();
            return menuManager;
        }
    }
}