namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can be filtered
    /// </summary>
    public interface IFilterableForm
    {
        /// <summary>
        /// Sets the filter on the form
        /// </summary>
        void Filter();
    }
}