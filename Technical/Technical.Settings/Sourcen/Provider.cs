using System.Diagnostics;
using Technical.Settings.Contracts;

namespace Technical.Settings
{
    public static class Provider
    {
        private static IConfigProvider _config;

        public static void SetInstance(IConfigProvider config)
        {
            _config = config;
        }

        public static void ClearInstance()
        {
            Debug.Assert(_config != null, "No Config instance exists");

            _config = null;
        }

        public static IConfigProvider Get()
        {
            return _config;
        }
    }
}