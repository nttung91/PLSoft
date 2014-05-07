using System;
using System.Reflection;
using Technical.Permissions.Attrib;

namespace Technical.Permissions.AttributeHelper
{
    public class PermissionAttributeScanner
    {
        private readonly object _instance;

        public PermissionAttributeScanner(object instance)
        {
            _instance = instance;
        }

        public bool HasPermissionAttribute()
        {
            return (GetAttribute() != null);
        }

        public string GetPermissionId()
        {
            string permissionId = null;
            PermissionAttribute attribute = GetAttribute();

            if (attribute != null)
            {
                permissionId = attribute.PermissionId;
            }

            return permissionId;
        }

        private PermissionAttribute GetAttribute()
        {
            PermissionAttribute permissionAttribute = null;

            MemberInfo info = _instance.GetType();
            object[] attributes = info.GetCustomAttributes(false);

            foreach (Attribute attribute in attributes)
            {
                if (attribute is PermissionAttribute)
                {
                    permissionAttribute = attribute as PermissionAttribute;
                    break;
                }
            }

            return permissionAttribute;
        }
    }
}