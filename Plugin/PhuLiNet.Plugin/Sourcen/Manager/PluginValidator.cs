using System.Collections.Generic;
using System.Linq;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin.Manager
{
    internal class PluginValidator : IPluginValidator
    {
        private readonly IPluginManager _pluginManager;

        public PluginValidator(IPluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public IList<IPlugin> GetCorruptedPluginsWithEqualShortcut()
        {
            var pluginsWithEqualShortcut = new List<IPlugin>();
            var shortcuts = new Dictionary<string, IPlugin>();

            foreach (var plugin in _pluginManager.GetPlugins())
            {
                if (plugin.Shortcut != null &&
                    !(plugin.IsExternal))
                {
                    if (!shortcuts.ContainsKey(plugin.Shortcut))
                    {
                        shortcuts.Add(plugin.Shortcut, plugin);
                    }
                    else
                    {
                        pluginsWithEqualShortcut.Add(plugin);
                    }
                }
            }

            return pluginsWithEqualShortcut;
        }

        public IList<IPlugin> GetCorruptedPluginsWithEqualId()
        {
            var pluginsWithEqualShortcut = new List<IPlugin>();
            var ids = new Dictionary<string, IPlugin>();

            foreach (var plugin in _pluginManager.GetPlugins())
            {
                if (!ids.ContainsKey(plugin.Id))
                {
                    ids.Add(plugin.Id, plugin);
                }
                else
                {
                    pluginsWithEqualShortcut.Add(plugin);
                }
            }

            return pluginsWithEqualShortcut;
        }

        public IList<IPlugin> GetCorruptedPluginsWithInvalidShortcut()
        {
            return _pluginManager.GetPlugins().Where(plugin => !plugin.IsExternal && !plugin.HasValidShortcut).ToList();
        }

        public bool HasCorruptedPlugins
        {
            get
            {
                return GetCorruptedPluginsWithEqualId().Count > 0 || GetCorruptedPluginsWithEqualShortcut().Count > 0 ||
                       GetCorruptedPluginsWithInvalidShortcut().Count > 0;
            }
        }
    }
}