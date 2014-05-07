using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandShowDisplayOptions : BaseDialogCommand
    {
        public CommandShowDisplayOptions()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var form = WindowManager.PrepareShowDialog<FrmOptionenBase>("Anzeige-Optionen laden", false);
            form.ControlBox = false;
            form.HideAppParameterTab();
            form.ShowDialog(WindowManager.GetActiveWindow());

            form.Dispose();
        }

        #endregion
    }
}