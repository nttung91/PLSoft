namespace Windows.Core.BaseForms
{
    public enum ExportType
    {
        XLS,
        XLSX,
        PDF,
        TXT,
        RTF
    }

    /// <summary>
    /// Specifies that the form can be exported
    /// </summary>
    public interface IExportableForm
    {
        /// <summary>
        /// Exports the form or grid data
        /// </summary>
        void Export(ExportType exportType);

        /// <summary>
        /// Export of form enabled
        /// </summary>
        bool ExportEnabled { get; }
    }
}