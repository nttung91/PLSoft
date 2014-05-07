using System;

namespace Windows.Core.Controls.Adapters
{
    public class ItemChangingEventArgs : EventArgs
    {
        public object NewElement { get; set; }
        public bool Allow { get; set; }
    }
}