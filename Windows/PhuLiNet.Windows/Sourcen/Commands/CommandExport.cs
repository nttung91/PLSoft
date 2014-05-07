using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandExport : BaseWindowCommand
    {
        private ExportType _exportType;

        public CommandExport(ExportType exportType) : base()
        {
            _exportType = exportType;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var exportable = WindowManager.GetActiveWindow() as IExportableForm;

                if (exportable != null)
                {
                    exportable.Export(_exportType);
                }
            }
        }

        #endregion
    }
}