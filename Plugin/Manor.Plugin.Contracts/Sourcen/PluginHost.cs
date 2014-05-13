using System.Diagnostics;
using Manor.Plugin.Contracts;

namespace PhuLiNet.Plugin.Contracts
{
    public class PluginHost
    {
        private static IPluginHost _pluginHost;

        public static void SetInstance(IPluginHost provider)
        {
            Debug.Assert(_pluginHost == null, "HostApplication instance exists already");

            _pluginHost = provider;
        }

        internal static void ClearInstance()
        {
            Debug.Assert(_pluginHost != null, "No HostApplication instance exists");

            _pluginHost = null;
        }

        public static IPluginHost Get()
        {
            Debug.Assert(_pluginHost != null, "No HostApplication instance exists");

            return _pluginHost;
        }
    }
}