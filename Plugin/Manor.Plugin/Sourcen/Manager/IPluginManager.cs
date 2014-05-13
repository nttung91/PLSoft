using System;
using System.Collections.Generic;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin.Manager
{
    public interface IPluginManager
    {
        /// <summary>
        /// Add plugin to managed list
        /// </summary>
        /// <param name="plugin"></param>
        void AddPlugin(IPlugin plugin);

        /// <summary>
        /// Get a plugin by id.
        /// </summary>
        /// <param name="pluginKey"></param>
        /// <returns></returns>
        IPlugin GetPlugin(string pluginId);

        /// <summary>
        /// Returns true if plugin is installed
        /// </summary>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        bool PluginExists(string pluginId);

        /// <summary>
        /// Get plugin by type
        /// </summary>
        /// <param name="pluginType"></param>
        /// <returns></returns>
        IPlugin GetPlugin(Type pluginType);

        /// <summary>
        /// Get plugin by shortcut
        /// </summary>
        /// <param name="pluginKey"></param>
        /// <returns></returns>
        IPlugin GetPluginByShortcut(string pluginShortcut);

        /// <summary>
        /// Get all loaded plugins
        /// </summary>
        /// <returns></returns>
        List<IPlugin> GetPlugins();

        /// <summary>
        /// Get all loaded, valid and allowed plugins
        /// </summary>
        /// <returns></returns>
        List<IPlugin> GetPluginsAllowed();

        /// <summary>
        /// Get plugin summary
        /// </summary>
        /// <returns></returns>
        List<IPluginSummary> GetPluginSummary();

        /// <summary>
        /// Get plugin summary for allowed plugins
        /// </summary>
        /// <returns></returns>
        List<IPluginSummary> GetPluginSummaryAllowed();

        /// <summary>
        /// Get replacement for this plugin
        /// </summary>
        /// <param name="oldPlugin"></param>
        /// <returns></returns>
        IList<IPlugin> GetReplacementPlugin(IPlugin oldPlugin);
    }
}