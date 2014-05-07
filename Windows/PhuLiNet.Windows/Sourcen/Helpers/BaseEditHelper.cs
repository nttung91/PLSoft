using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.Helpers
{
    public class BaseEditHelper
    {
        public static BaseEditHelper GetBaseEditHelper(bool useRecursive)
        {
            return new BaseEditHelper(useRecursive);
        }

        private bool _useRecursive;

        public BaseEditHelper(bool useRecursive)
        {
            _useRecursive = useRecursive;
        }

        public void SetReadonly(Control control, bool isreadonly)
        {
            var baseEdit = control as BaseEdit;
            if (baseEdit != null)
            {
                baseEdit.Properties.ReadOnly = isreadonly;
            }

            if (_useRecursive && control.Controls != null)
            {
                foreach (Control subControl in control.Controls)
                {
                    SetReadonly(subControl, isreadonly);
                }
            }
        }

        public void SetTabStop(Control control, bool tabStop)
        {
            var baseEdit = control as BaseEdit;
            if (baseEdit != null)
            {
                baseEdit.TabStop = tabStop;
            }

            if (_useRecursive && control.Controls != null)
            {
                foreach (Control subControl in control.Controls)
                {
                    SetTabStop(subControl, tabStop);
                }
            }
        }
    }
}