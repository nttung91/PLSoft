namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can be identified.
    /// </summary>
    public interface IIdentifiableForm
    {
        /// <summary>
        /// Returns the individual form ID
        /// </summary>
        /// <returns></returns>
        object GetIdValue();

        /// <summary>
        /// Returns an ID/Context of the loaded data
        /// </summary>
        /// <returns></returns>
        object GetIdValueData();
    }
}