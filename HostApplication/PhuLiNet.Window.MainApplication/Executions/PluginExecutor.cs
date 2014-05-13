using PhuLiNet.Plugin;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Menu;

namespace PhuLiNet.Window.MainApplication.Executions
{
    public class PluginExecutor
    {
        private readonly IHostApplication _hostApplication;

        private PluginExecutor(IHostApplication hostApplication)
        {
            _hostApplication = hostApplication;
        }

        public static PluginExecutor CreateInstance()
        {
            return CreateInstance(HostApplication.Get(), false);
        }

        public static PluginExecutor CreateInstance(IHostApplication hostApplication, bool testMode)
        {
            var instance = new PluginExecutor(hostApplication);
            return instance;
        }

        public void Execute(object menuItemOrPlugin)
        {
            Execute(menuItemOrPlugin, new StartParameter());
        }

        public void Execute(object menuItemOrPlugin, IStartParameter parameter)
        {
            if (menuItemOrPlugin == null) return;
            ((StartParameter)parameter).CtrlPressed = _hostApplication.CtrlPressed;

            var plugin = GetPlugin(menuItemOrPlugin);
            if (plugin != null)
            {
                TryStartPlugin(plugin, parameter);
            }
        }

        private void TryStartPlugin(IPlugin plugin, IStartParameter parameter)
        {
            var starter = PluginStarter.CreateInstance();
            starter.Start(plugin, parameter);
        }

        private IPlugin GetPlugin(object menuItemOrPlugin)
        {
            IPlugin plugin = null;

            if (menuItemOrPlugin is IPlugin)
            {
                plugin = menuItemOrPlugin as IPlugin;
            }
            else if (menuItemOrPlugin is IMenuItem)
            {
                var menu = menuItemOrPlugin as IMenuItem;
                if (menu.HasPluginAssigned)
                {
                    plugin = menu.Plugin;
                }
            }

            return plugin;
        }
    }
}