using System.Collections.Generic;

namespace Manor.Plugin.Contracts
{
    public interface IPluginHost
    {
        void ExecutePlugin(string pluginId);
        void ExecutePlugin(string pluginId, Dictionary<string, object> parameters);

        void ExecutePlugin(string pluginId, Dictionary<string, object> parameters,
            out Dictionary<string, object> returnValues);

        void ExecutePluginByShortcut(string pluginShortcut);
        void ExecutePluginByShortcut(string pluginShortcut, Dictionary<string, object> parameters);

        void ExecutePluginByShortcut(string pluginShortcut, Dictionary<string, object> parameters,
            out Dictionary<string, object> returnValues);
    }
}