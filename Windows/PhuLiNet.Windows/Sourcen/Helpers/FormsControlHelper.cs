using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Windows.Core.Helpers
{
    public static class FormsControlHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetFocus();

        public static Control GetFocusedControl()
        {
            Control focused = null;
            IntPtr handle = GetFocus();
            if (handle != IntPtr.Zero)
            {
                focused = Control.FromHandle(handle);
            }
            return focused;
        }
    }
}