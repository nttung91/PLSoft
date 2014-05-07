using System;

namespace Windows.Core.Helpers.PopupHelper
{
    public class PopupMenuHelperEventArgs : EventArgs
    {
        public PopupMenuItemType Type { get; set; }

        public PopupMenuHelperEventArgs(PopupMenuItemType type)
        {
            Type = type;
        }
    }
}