using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Windows.Core.Components.Permissions
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof (ResFinder), "Windows.Core.ManorIcon.bmp")]
    [ProvideProperty("Permission", typeof (Control))]
    [ProvideProperty("VisibleWhenDisabled", typeof (Control))]
    public partial class UIPermissionProvider : Component, IExtenderProvider, IUIPermissionActivator
    {
        private readonly Hashtable _permissions;
        private readonly IUIPermissionActivator _permissionActivator;

        public UIPermissionProvider()
        {
            _permissions = new Hashtable();
            _permissionActivator = new UIPermissionActivator(_permissions);
            InitializeComponent();
        }

        public UIPermissionProvider(IContainer container)
        {
            _permissions = new Hashtable();
            _permissionActivator = new UIPermissionActivator(_permissions);
            container.Add(this);
            InitializeComponent();
        }

        [Category("Permission")]
        public string GetPermission(Control control)
        {
            return EnsurePropertiesExists(control).Permission;
        }

        public void SetPermission(Control control, string value)
        {
            EnsurePropertiesExists(control).Permission = value;
        }

        [Category("Permission")]
        public bool? GetVisibleWhenDisabled(Control control)
        {
            return EnsurePropertiesExists(control).Visible;
        }

        public void SetVisibleWhenDisabled(Control control, bool? value)
        {
            EnsurePropertiesExists(control).Visible = value;
        }

        public bool CanExtend(object extendee)
        {
            return extendee is Control;
        }

        private UIPermissionInfo EnsurePropertiesExists(object key)
        {
            var p = (UIPermissionInfo) _permissions[key];

            if (p == null)
            {
                p = new UIPermissionInfo();
                _permissions[key] = p;
            }

            return p;
        }

        public void ActivatePermissionsOnUI()
        {
            _permissionActivator.ActivatePermissionsOnUI();
        }
    }
}