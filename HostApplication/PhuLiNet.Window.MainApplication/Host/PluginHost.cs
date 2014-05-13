using System.Collections.Generic;
using PhuLiNet.Plugin;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Window.MainApplication.Executions;

namespace PhuLiNet.Window.MainApplication.Host
{
    internal class PluginHostImpl : IPluginHost
    {
        private static PluginHostImpl _singleton;

        private PluginHostImpl()
        {
        }

        internal static PluginHostImpl Get()
        {
            if (_singleton == null) _singleton = new PluginHostImpl();
            return _singleton;
        }

        public void ExecutePlugin(string pluginId)
        {
            ExecutePlugin(pluginId, new Dictionary<string, object>());
        }

        public void ExecutePlugin(string pluginId, Dictionary<string, object> parameters)
        {
            Dictionary<string, object> returnValues;
            ExecutePlugin(pluginId, parameters, out returnValues);
        }

        public void ExecutePlugin(string pluginId, Dictionary<string, object> parameters,
            out Dictionary<string, object> returnValues)
        {
            IPlugin plugin = HostApplicationFactory.GetInstance().GetPlugin(pluginId);
            if (plugin != null)
            {
                Execute(plugin, parameters, out returnValues);
            }
            else
            {
                throw new PluginHostException(string.Format("Plugin with id [{0}] not found", pluginId));
            }
        }

        public void ExecutePluginByShortcut(string pluginShortcut)
        {
            ExecutePluginByShortcut(pluginShortcut, new Dictionary<string, object>());
        }

        public void ExecutePluginByShortcut(string pluginShortcut, Dictionary<string, object> parameters)
        {
            Dictionary<string, object> returnValues;
            ExecutePluginByShortcut(pluginShortcut, parameters, out returnValues);
        }

        public void ExecutePluginByShortcut(string pluginShortcut, Dictionary<string, object> parameters,
            out Dictionary<string, object> returnValues)
        {
            IPlugin plugin = HostApplicationFactory.GetInstance().GetPluginByShortcut(pluginShortcut);
            if (plugin != null)
            {
                Execute(plugin, parameters, out returnValues);
            }
            else
            {
                throw new PluginHostException(string.Format("Plugin with shortcut [{0}] not found", pluginShortcut));
            }
        }

        private void Execute(IPlugin plugin, Dictionary<string, object> parameters,
            out Dictionary<string, object> returnValues)
        {
            var pluginExecutor = PluginExecutor.CreateInstance();
            var startParameter = new StartParameter {Parameters = parameters};
            pluginExecutor.Execute(plugin, startParameter);
            returnValues = startParameter.ReturnValues;
        }
    }
}