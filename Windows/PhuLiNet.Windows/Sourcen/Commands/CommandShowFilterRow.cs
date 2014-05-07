using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandShowFilterRow : BaseWindowCommand
    {
        private bool _showFilterRow;

        public CommandShowFilterRow(bool showFilterRow)
            : base()
        {
            _showFilterRow = showFilterRow;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var showFilterRow = WindowManager.GetActiveWindow() as IShowFilterRow;
                Debug.Assert(showFilterRow != null, "This Form is not filterable!");
                showFilterRow.SetFilterRow(_showFilterRow);
            }
        }

        #endregion
    }
}