using System.ComponentModel;
using System.Windows.Forms;

namespace Windows.Core.Helpers
{
    internal static class BaseFormsUtilities
    {
        /// <summary>
        /// Checks whether a control or its parent is in design mode.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns>Returns TRUE if in design mode, false otherwise.</returns>
        public static bool IsDesignerHosted(Control ctrl)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return true;

            while (ctrl != null)
            {
                if ((ctrl.Site != null) && ctrl.Site.DesignMode) return true;
                ctrl = ctrl.Parent;
            }
            return false;
        }
    }
}