namespace Windows.Core.Controls
{
    /// <summary>
    /// Specifies that the control can be filtered
    /// </summary>
    public interface IFilterableControl
    {
        /// <summary>
        /// Sets the filter on the control
        /// </summary>
        void Filter();
    }
}