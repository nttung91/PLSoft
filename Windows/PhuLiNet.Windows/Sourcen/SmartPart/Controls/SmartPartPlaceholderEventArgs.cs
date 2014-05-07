using System;
using Windows.Core.SmartPart.Utility;

namespace Windows.Core.SmartPart.Controls
{
    /// <summary>
    /// Used by the the smartpart placeholder.
    /// </summary>
    public class SmartPartPlaceholderEventArgs : EventArgs
    {
        private ISmartPart _smartPart;

        public SmartPartPlaceholderEventArgs(ISmartPart smartPart)
        {
            Guard.ArgumentNotNull(smartPart, "smartPart");
            _smartPart = smartPart;
        }

        /// <summary>
        /// Gets the SmartPart associated with this event.
        /// </summary>
        public ISmartPart SmartPart
        {
            get { return _smartPart; }
        }
    }
}