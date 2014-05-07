using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraVerticalGrid;
using Windows.Core.Helpers.Controls.Item;

namespace Windows.Core.Helpers.Controls
{
    internal class ControlInfoList
    {
        private List<IControlInfo> _list;

        internal ControlInfoList()
        {
            _list = new List<IControlInfo>();
        }

        // Hier sind alle Control Typen welche Enabled/Disabled werden sollen
        private static bool IsControlHandled(Control control)
        {
            return
                control is BaseEdit ||
                control is GridControl ||
                control is VGridControl;
        }

        internal void AddWithChilds(Control control)
        {
            if (GetControlInfo(control) == null)
            {
                if (IsControlHandled(control))
                {
                    if (control is GridControl)
                    {
                        _list.Add(new GridEnablerDisabler((GridControl) control));
                    }
                    else if (control is BaseEdit)
                    {
                        _list.Add(new EditorEnablerDisabler(control));
                    }
                }

                AddChilds(control);
            }
        }

        private void AddChilds(Control control)
        {
            if (control.Controls == null) return;

            foreach (Control childControl in control.Controls)
            {
                AddWithChilds(childControl);
            }
        }

        internal void EnableControl(Control control)
        {
            if (IsControlHandled(control))
            {
                GetControlInfo(control).Enabled = true;
            }
        }

        internal void DisableControl(Control control)
        {
            if (IsControlHandled(control))
            {
                GetControlInfo(control).Enabled = false;
            }
        }

        private IControlInfo GetControlInfo(Control control)
        {
            IControlInfo result = null;

            foreach (IControlInfo controlInfo in _list)
            {
                if (controlInfo.IsControl(control))
                    result = controlInfo;
            }

            return result;
        }
    }
}