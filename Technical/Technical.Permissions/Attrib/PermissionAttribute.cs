using System;

namespace Technical.Permissions.Attrib
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PermissionAttribute : Attribute
    {
        private readonly string _permissionId;

        public string PermissionId
        {
            get { return _permissionId; }
        }

        public PermissionAttribute(string permissionId)
        {
            _permissionId = permissionId;
        }

        public override string ToString()
        {
            return _permissionId;
        }
    }
}