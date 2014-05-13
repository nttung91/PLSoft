using System.Diagnostics;
using Manor.Plugin;

namespace PhuLiNet.Plugin
{
    public static class HostApplicationFactory
    {
        private static IHostApplicationInternals _pluginApplication;

        public static IHostApplicationInternals GetInstance()
        {
            return _pluginApplication;
        }

        public static IHostApplicationInternals CreateInstance(string startupPath, string appConfigFile, string configId)
        {
            if (_pluginApplication != null) throw new PluginHostException("Plugin Host exists already.");

            if (_pluginApplication == null)
            {
                _pluginApplication = new InternalHostApplication
                {
                    StartupPath = startupPath,
                    AppConfigFile = appConfigFile,
                  //  ConfigId = configId,
                  //  MenuRootNode = null
                };
            }

            return _pluginApplication;
        }

        public static void SetInstance(IHostApplicationInternals hostApplicationInternals)
        {
            _pluginApplication = hostApplicationInternals;
        }
    }
}