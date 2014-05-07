using System;

namespace Windows.Core.Controls
{
    public class CurrentMasterDetailSelectionChanged : EventArgs
    {
        public object CurrentItem { get; private set; }

        public CurrentMasterDetailSelectionChanged(object currentItem)
        {
            CurrentItem = currentItem;
        }
    }
}