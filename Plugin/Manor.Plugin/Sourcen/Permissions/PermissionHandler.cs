using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using Technical.Permissions.AttributeHelper;

namespace PhuLiNet.Plugin.Permissions
{
    internal class PermissionHandler
    {
        public bool HasPermissionOnPlugin(IPlugin plugin)
        {
            return HasAttributePermission(plugin) && HasProgramPermission(plugin);
        }

        private bool HasProgramPermission(IPlugin plugin)
        {
            // Use ArtId (artificial key) for permission check on external plugins and Id for internal plugins
            // The standard permission check should be performed via plugin Id
            // Reason:
            // External plugins exists more than once in MAINDB program table (MEP_ID is not unique in database)
            // For internal plugins the MEP_ID is unique in MAINDB
            var permissionValidator = plugin.IsExternal
                ? new ProgramPermissionValidator(plugin.ArtId)
                : new ProgramPermissionValidator(plugin.Id);
            return permissionValidator.HasProgramPermission();
        }

        private bool HasAttributePermission(IPlugin plugin)
        {
            var permissionAttributeValidator = new PermissionAttributeValidator(plugin);
            return permissionAttributeValidator.HasPermissionOnInstance();
        }
    }
}