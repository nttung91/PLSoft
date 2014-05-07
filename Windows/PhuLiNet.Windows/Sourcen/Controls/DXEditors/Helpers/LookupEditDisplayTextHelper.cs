using System;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;

namespace Windows.Core.Controls.DXEditors.Helpers
{
    /// <summary>
    /// Helper class with custom display text stuffs in LookUpEdit
    /// </summary>
    public static class LookupEditDisplayTextHelper
    {
        public static void SetCustomDisplayText(CustomDisplayTextEventArgs e, FormatInfo displayFormat, string nullText)
        {
            var formatteableValue = e.Value as IFormattable;
            if (formatteableValue != null &&
                displayFormat.FormatType == FormatType.Custom &&
                !string.IsNullOrEmpty(displayFormat.FormatString))
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.DisplayText = formatteableValue.ToString(displayFormat.FormatString, null);
                }
            }
            else
            {
                if ((string.IsNullOrEmpty(e.DisplayText) || e.DisplayText == nullText) &&
                    e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
        }
    }
}