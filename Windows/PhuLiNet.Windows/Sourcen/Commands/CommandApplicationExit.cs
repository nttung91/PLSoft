using System.Windows.Forms;

namespace Windows.Core.Commands
{
    public class CommandApplicationExit : BaseCommand
    {
        public CommandApplicationExit()
        {
            Log = false;
            Audit = false;
        }

        public override void Execute()
        {
            var closeAllForms = new CommandCloseAllForms();
            CommandExecutor.Execute(closeAllForms);

            if (closeAllForms.ApplicationExit)
            {
                Application.Exit();
            }
        }
    }
}