using System.Collections.Generic;
using System.IO;
using Windows.Core.Helpers;
using DevExpress.XtraGrid.Views.Grid;
using Windows.Core.Export;
using Windows.Core.Helpers;
using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandExcelExport : BaseWindowCommand
    {
        #region Feilds/Properties

        private readonly string _fileName;
        private readonly string _title;
        private readonly IDictionary<string, string> _parameters;
        private readonly GridView _gridView;

        public bool IsCommandOk { get; set; }
        public string ErrorMsg { get; set; }

        #endregion

        public CommandExcelExport(string fileName,
            string title,
            IDictionary<string, string> parameters,
            GridView gridView)
        {
            _fileName = fileName;
            _title = title;
            _parameters = parameters;
            _gridView = gridView;
        }

        public override void Execute()
        {
            using (new StatusBusy(CommandRes.ExportingData, true))
            {
                var fileName = string.Format("{0}{1}.xlsx", Path.GetTempPath(), _fileName);
                var exporter = new ExcelExporter(fileName, _title, _parameters, _gridView);
                exporter.Export();

                if (exporter.IsExportOk)
                {
                    IsCommandOk = true;
                    CommandExecutor.Execute(new CommandShowExternalFile(fileName));
                }
                else
                {
                    IsCommandOk = false;
                    ErrorMsg = exporter.ErrorMsg;
                }
            }
        }
    }
}