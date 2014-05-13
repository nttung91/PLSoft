using System;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin.Menu.Plugins
{
    /// <summary>
    /// Plugin proxy, stores values for an plugin until real .net plugin is assign to menu item
    /// </summary>
    internal class PluginProxy : PluginBase
    {
        public override void Configure()
        {
            Description = PluginProxyRes.Description;
            Shortcut = PluginProxyRes.Shortcut;
            Version = new Version(1, 0, 0, 0);
        }

        public override void Start(IStartParameter parameter)
        {
            throw new NotImplementedException("Plugin Proxy can not execute something!");
        }
    }
}