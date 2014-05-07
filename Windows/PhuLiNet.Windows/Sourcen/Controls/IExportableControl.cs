using Windows.Core.BaseForms;

namespace Windows.Core.Controls
{
    /// <summary>
    /// Specifies that the control can be exported
    /// </summary>
    public interface IExportableControl
    {
        /// <summary>
        /// Exports the control or grid data
        /// </summary>
        void Export(ExportType exportType);
    }
}