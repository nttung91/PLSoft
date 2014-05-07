namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can reload business data.
    /// </summary>
    public interface IReloadableForm
    {
        /// <summary>
        /// Reload business data from database
        /// </summary>
        void ReloadBusiness();
    }
}