namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can save
    /// itself.
    /// </summary>
    public interface ISavableForm
    {
        /// <summary>
        /// Saves the object to the database.
        /// </summary>
        bool Save();

        /// <summary>
        /// Save enabled
        /// </summary>
        bool SaveEnabled { get; set; }
    }
}