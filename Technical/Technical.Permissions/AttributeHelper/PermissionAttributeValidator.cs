namespace Technical.Permissions.AttributeHelper
{
    public class PermissionAttributeValidator
    {
        private readonly object _instance;

        public PermissionAttributeValidator(object instance)
        {
            _instance = instance;
        }

        public bool HasPermissionOnInstance()
        {
            bool hasPermission = true;

            string permissionId = GetPermissionId();
            if (!string.IsNullOrEmpty(permissionId))
            {
                hasPermission = Provider.Get().HasPermission(permissionId);
            }

            return hasPermission;
        }

        public string GetPermissionId()
        {
            var permissionScanner = new PermissionAttributeScanner(_instance);
            return permissionScanner.GetPermissionId();
        }
    }
}