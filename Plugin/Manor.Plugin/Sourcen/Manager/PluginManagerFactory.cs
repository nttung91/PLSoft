namespace PhuLiNet.Plugin.Manager
{
    internal static class PluginManagerFactory
    {
        private static PluginManager _manager;

        internal static IPluginManager CreateInstance(string path)
        {
            if (_manager == null)
            {
                _manager = new PluginManager {Path = path};
                _manager.Start();
            }

            return _manager;
        }

        internal static IPluginManager GetInstance()
        {
            return _manager;
        }
    }
}