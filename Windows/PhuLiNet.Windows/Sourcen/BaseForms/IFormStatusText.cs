namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Provides status information (Warengruppe, Kategorie) about the form
    /// </summary>
    public interface IFormStatusText
    {
        string StatusText { get; }
        string StatusTextShort { get; }
    }
}