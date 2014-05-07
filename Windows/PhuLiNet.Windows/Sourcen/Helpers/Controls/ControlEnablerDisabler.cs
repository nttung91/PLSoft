using System;
using System.Windows.Forms;

namespace Windows.Core.Helpers.Controls
{
    public class ControlEnablerDisabler
    {
        private ControlInfoList _controlInfoList;

        public ControlEnablerDisabler()
        {
            _controlInfoList = new ControlInfoList();
        }

        public void EnableWithChilds(Control control)
        {
            if (control == null) throw new ArgumentException("Control darf nicht null sein");

            _controlInfoList.AddWithChilds(control);

            _controlInfoList.EnableControl(control);

            EnableChildControls(control);
        }

        public void DisableWithChilds(Control control)
        {
            if (control == null) throw new ArgumentException("Control darf nicht null sein");

            _controlInfoList.AddWithChilds(control);

            _controlInfoList.DisableControl(control);

            DisableChildControls(control);
        }

        private void EnableChildControls(Control control)
        {
            if (control.Controls != null)
            {
                foreach (Control childControl in control.Controls)
                {
                    EnableWithChilds(childControl);
                }
            }
        }

        private void DisableChildControls(Control control)
        {
            if (control.Controls != null)
            {
                foreach (Control childControl in control.Controls)
                {
                    DisableWithChilds(childControl);
                }
            }
        }
    }
}