using Windows.Core.Forms;

namespace Windows.Core.Commands
{
    public class CommandAbout : BaseDialogCommand
    {
        public CommandAbout()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var about = WindowManager.ShowDialog<FrmAbout>("Info anzeigen", false);
            about.Dispose();
        }

        #endregion
    }
}