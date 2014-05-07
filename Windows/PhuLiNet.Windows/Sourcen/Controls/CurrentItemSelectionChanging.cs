using System;

namespace Windows.Core.Controls
{
    public class CurrentMasterDetailSelectionChanging : EventArgs
    {
        public object CurrentItem { get; private set; }
        public bool Allow { get; set; }

        public CurrentMasterDetailSelectionChanging(object currentItem)
        {
            CurrentItem = currentItem;
        }
    }
}