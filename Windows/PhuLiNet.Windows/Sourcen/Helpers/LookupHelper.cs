using DevExpress.XtraEditors.Controls;

namespace Windows.Core.Helpers
{
    public static class LookupHelper
    {
        public static void SetCustomDisplayText(CustomDisplayTextEventArgs e)
        {
            if (string.IsNullOrEmpty(e.DisplayText) && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.DisplayText = e.Value.ToString();
            }
        }
    }
}