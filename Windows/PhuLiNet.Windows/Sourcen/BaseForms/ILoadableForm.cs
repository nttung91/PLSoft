namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can load business data.
    /// </summary>
    public interface ILoadableForm
    {
        /// <summary>
        /// Load business data from database
        /// </summary>
        void LoadBusiness();
    }
}