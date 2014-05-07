using System.Collections;
using System.Windows.Forms;
using Technical.Permissions;

namespace Windows.Core.Components.Permissions
{
    internal class UIPermissionActivator : IUIPermissionActivator
    {
        private Hashtable _permissions;

        private UIPermissionActivator()
        {
        }

        public UIPermissionActivator(Hashtable permissions)
        {
            _permissions = permissions;
        }

        public void ActivatePermissionsOnUI()
        {
            foreach (DictionaryEntry item in _permissions)
            {
                var control = item.Key as Control;
                if (control != null)
                {
                    UIPermissionInfo val = null;
                    if (item.Value != null)
                    {
                        val = item.Value as UIPermissionInfo;
                        if (!string.IsNullOrEmpty(val.Permission))
                        {
                            bool hasPermission = HasPermission(val.Permission);
                            control.Enabled = hasPermission;
                            if (val.Visible.HasValue && !val.Visible.Value)
                            {
                                control.Visible = hasPermission;
                            }
                        }
                    }
                }
            }
        }

        private static bool HasPermission(string permission)
        {
            return Provider.Get().HasPermission(permission);
        }
    }
}