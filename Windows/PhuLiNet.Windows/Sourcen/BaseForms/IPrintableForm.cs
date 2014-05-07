namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form can be printed
    /// </summary>
    public interface IPrintableForm
    {
        /// <summary>
        /// Prints the form data
        /// </summary>
        void Print();

        /// <summary>
        /// Print of form enabled
        /// </summary>
        bool PrintEnabled { get; }
    }
}