using System.Diagnostics;
using Manor.Plugin.Contracts;

namespace PhuLiNet.Plugin.Contracts
{
    public static class HostApplication
    {
        private static IHostApplication _hostApplication;

        public static void SetInstance(IHostApplication provider)
        {
            Debug.Assert(_hostApplication == null, "HostApplication instance exists already");

            _hostApplication = provider;
        }

        public static void ClearInstance()
        {
            Debug.Assert(_hostApplication != null, "No HostApplication instance exists");

            _hostApplication = null;
        }

        public static IHostApplication Get()
        {
            Debug.Assert(_hostApplication != null, "No HostApplication instance exists");

            return _hostApplication;
        }
    }
}