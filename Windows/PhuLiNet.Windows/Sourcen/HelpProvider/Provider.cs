using System.Diagnostics;

namespace Windows.Core.HelpProvider
{
    public static class Provider
    {
        private static IHelpProvider _helpProvider;

        public static void SetInstance(IHelpProvider provider)
        {
            _helpProvider = provider;
        }

        public static void ClearInstance()
        {
            Debug.Assert(_helpProvider != null, "No help provider instance exists");
            _helpProvider = null;
        }

        public static IHelpProvider Get()
        {
            return _helpProvider;
        }
    }
}