using System.Collections.Generic;
using PhuLiNet.Plugin.Contracts;

namespace PhuLiNet.Plugin.Manager
{
    public interface IPluginValidator
    {
        bool HasCorruptedPlugins { get; }
        IList<IPlugin> GetCorruptedPluginsWithEqualShortcut();
        IList<IPlugin> GetCorruptedPluginsWithEqualId();
        IList<IPlugin> GetCorruptedPluginsWithInvalidShortcut();
    }
}