using System.Diagnostics;
using Technical.Permissions.Contracts;

namespace Technical.Permissions
{
    public static class Provider
    {
        private static IPermissionProvider _permissionProvider;

        public static void SetInstance(IPermissionProvider provider)
        {
            _permissionProvider = provider;
        }

        public static void ClearInstance()
        {
            Debug.Assert(_permissionProvider != null, "No Provider instance exists");

            _permissionProvider = null;
        }

        public static IPermissionProvider Get()
        {
            return _permissionProvider;
        }
    }
}