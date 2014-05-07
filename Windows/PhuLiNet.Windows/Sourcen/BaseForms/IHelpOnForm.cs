namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies that the form has a help file
    /// </summary>
    public interface IHelpOnForm
    {
        string HelpFileName { get; set; }
        string HelpFileExtension { get; set; }
    }
}