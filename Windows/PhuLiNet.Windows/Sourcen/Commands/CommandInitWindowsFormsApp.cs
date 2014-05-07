using System.Windows.Forms;

namespace Windows.Core.Commands
{
    public class CommandInitWindowsFormsApp : BaseCommand
    {
        public CommandInitWindowsFormsApp()
        {
            Log = false;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        #endregion
    }
}