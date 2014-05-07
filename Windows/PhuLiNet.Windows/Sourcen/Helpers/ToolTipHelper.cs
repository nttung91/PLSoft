using System.Windows.Forms;
using DevExpress.Utils;

namespace Windows.Core.Helpers
{
    public static class ToolTipHelper
    {
        public static void ShowHint(ToolTipController toolTipController, Control control, ToolTipIconType icon,
            string title, string message)
        {
            toolTipController.ShowHint(
                new ToolTipControllerShowEventArgs(control, null, message, title, ToolTipLocation.TopRight, true, false,
                    0, icon, ToolTipIconSize.Small, null, 0, null, null), control);
        }

        public static void ShowHintCenter(ToolTipController toolTipController, Control control, ToolTipIconType icon,
            string title, string message)
        {
            toolTipController.ShowHint(
                new ToolTipControllerShowEventArgs(control, null, message, title, ToolTipLocation.TopCenter, true, false,
                    0, icon, ToolTipIconSize.Small, null, 0, null, null), control);
        }
    }
}