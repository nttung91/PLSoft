using Windows.Core.Forms.Localization;

namespace Windows.Core.Commands
{
    public class CommandSelectLanguage : BaseDialogCommand
    {
        #region IApplicationCommand Members

        public override void Execute()
        {
            var languageDialog = WindowManager.ShowDialog<FrmSelectLanguage>("Sprache wählen", false);
            DialogResult = languageDialog.DialogResult;
            languageDialog.Dispose();
        }

        #endregion
    }
}