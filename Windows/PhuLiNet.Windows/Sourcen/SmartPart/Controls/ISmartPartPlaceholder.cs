namespace Windows.Core.SmartPart.Controls
{
    /// <summary>
    /// When implemented by a control, provides a simple placeholder to be filled with a SmartPart at runtime.
    /// </summary>
    public interface ISmartPartPlaceholder
    {
        /// <summary>
        /// Gets or sets the default name for the PlaceholderName
        /// </summary>
        string PlaceholderName { get; set; }

        /// <summary>
        /// Gets or sets the SmartPart contained by this placeholder.
        /// </summary>
        ISmartPart SmartPart { get; set; }

        /// <summary>
        /// Removes the current SmartPart from the placeholder
        /// </summary>
        void RemoveSmartPart();
    }
}