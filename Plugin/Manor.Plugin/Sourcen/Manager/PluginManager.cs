using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Permissions;
using StructureMap;

namespace PhuLiNet.Plugin.Manager
{
    internal class PluginManager : IPluginManager
    {
        private string _path;
        private IList<IPlugin> _plugins;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public void Start()
        {
            Compose();
            ConfigurePlugins();
        }

        private void Compose()
        {
            var windowAssembly = GetAssemblies("PhuLiNet.Window.dll");
            var windowsAssemblies = GetAssemblies("PhuLiNet.Window.*.dll");

            var assembliesWithPlugins = new List<string>();
            assembliesWithPlugins.AddRange(windowAssembly);
            assembliesWithPlugins.AddRange(windowsAssemblies);

            var container = new Container();

            Action scanAction = () => container.Configure(r =>
                r.Scan(s =>
                {
                    foreach (var assembly in assembliesWithPlugins)
                    {
                        s.Assembly(assembly);
                    }
                    s.Convention<PluginConvention>();
                }));
            scanAction();
            _plugins = container.GetAllInstances<IPlugin>();
        }

        private IEnumerable<string> GetAssemblies(string searchPattern)
        {
            var files = Directory.GetFiles(_path, searchPattern);
            return files.Select(System.IO.Path.GetFileNameWithoutExtension).ToList();
        }

        private void ConfigurePlugins()
        {
            foreach (IPlugin plugin in _plugins)
            {
                plugin.Configure();
            }
        }

        #region IPluginManager Members

        public void AddPlugin(IPlugin plugin)
        {
            _plugins.Add(plugin);
        }

        public IPlugin GetPlugin(string pluginId)
        {
            IPlugin found = null;

            foreach (IPlugin plugin in _plugins)
            {
                if (plugin.Id == pluginId)
                {
                    found = plugin;
                    break;
                }
            }

            return found;
        }

        public bool PluginExists(string pluginId)
        {
            return GetPlugin(pluginId) != null;
        }

        public IPlugin GetPlugin(Type pluginType)
        {
            return _plugins.FirstOrDefault(p => p.GetType() == pluginType);
        }

        public IPlugin GetPluginByShortcut(string pluginShortcut)
        {
            IPlugin found = null;

            if (!string.IsNullOrEmpty(pluginShortcut))
            {
                pluginShortcut = pluginShortcut.ToUpper();

                foreach (IPlugin plugin in _plugins)
                {
                    if (!string.IsNullOrEmpty(plugin.Shortcut) &&
                        plugin.Shortcut == pluginShortcut)
                    {
                        found = plugin;
                        break;
                    }
                }
            }

            return found;
        }

        public List<IPlugin> GetPlugins()
        {
            var plugins = new List<IPlugin>();

            foreach (IPlugin plugin in _plugins)
            {
                plugins.Add(plugin);
            }

            return plugins;
        }

        public List<IPluginSummary> GetPluginSummary()
        {
            var plugins = new List<IPluginSummary>();

            foreach (IPlugin plugin in _plugins)
            {
                plugins.Add(PluginSummary.CreateSummary(plugin));
            }

            return plugins;
        }

        public List<IPluginSummary> GetPluginSummaryAllowed()
        {
            var plugins = new List<IPluginSummary>();
            var permissionHandler = new PermissionHandler();

            foreach (IPlugin plugin in _plugins)
            {
                if (permissionHandler.HasPermissionOnPlugin(plugin))
                {
                    plugins.Add(PluginSummary.CreateSummary(plugin));
                }
            }

            return plugins;
        }

        public IList<IPlugin> GetReplacementPlugin(IPlugin oldPlugin)
        {
            var plugins = new List<IPlugin>();

            foreach (IPlugin plugin in _plugins)
            {
                if (plugin.PreviousShortcuts != null &&
                    plugin.PreviousShortcuts.Contains(oldPlugin.Shortcut))
                {
                    plugins.Add(plugin);
                }
            }

            return plugins;
        }

        public List<IPlugin> GetPluginsAllowed()
        {
            var plugins = new List<IPlugin>();
            var permissionHandler = new PermissionHandler();

            foreach (IPlugin plugin in _plugins)
            {
                if (plugin.IsValid && permissionHandler.HasPermissionOnPlugin(plugin))
                {
                    plugins.Add(plugin);
                }
            }

            return plugins;
        }

        #endregion
    }
}