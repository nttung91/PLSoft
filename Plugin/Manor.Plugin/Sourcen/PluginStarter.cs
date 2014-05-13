using Manor.Plugin;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Plugin
{
    public class PluginStarter
    {
        private PluginStarter()
        {
        }

        public static PluginStarter CreateInstance()
        {
            var instance = new PluginStarter();
            return instance;
        }

        public void Start(IPlugin plugin, IStartParameter parameter)
        {
            if (plugin != null)
            {
                if (plugin.IsValid)
                {
                    plugin.Start(parameter);
                }
            }
        }

        private void Start(IMenuItem menuItem, IStartParameter parameter)
        {
            if (menuItem.IsValid && menuItem.HasPlugin)
            {
                Start(menuItem.Plugin, parameter);
            }
        }

        public void Start(object menuItemOrPlugin, IStartParameter parameter)
        {
            if (menuItemOrPlugin is IMenuItem)
            {
                Start((IMenuItem) menuItemOrPlugin, parameter);
            }
            else if (menuItemOrPlugin is IPlugin)
            {
                Start((IPlugin) menuItemOrPlugin, parameter);
            }
        }

        public void Start(string pluginShortcut, IStartParameter parameter)
        {
            IPlugin plugin = HostApplicationFactory.GetInstance().GetPluginByShortcut(pluginShortcut);

            if (plugin != null)
            {
                Start(plugin, parameter);
            }
        }
    }
}