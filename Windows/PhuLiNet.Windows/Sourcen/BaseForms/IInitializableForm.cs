namespace Windows.Core.BaseForms
{
    /// <summary>
    /// Specifies, that a form needs initalization with custom paramters.
    /// </summary>
    public interface IInitializableForm
    {
        void InitializeForm(object parameter);
    }
}