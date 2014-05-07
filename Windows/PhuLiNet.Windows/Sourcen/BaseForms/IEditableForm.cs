namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form edits data.
    /// </summary>
    public interface IEditableForm
    {
        bool IsDirty { get; }
        bool IsValid { get; }
    }
}