using System.Windows.Forms;
using Windows.Core.Helpers;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.HelpProvider;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Commands
{
    public class CommandShowHelp : BaseCommand
    {
        internal const string HelpFileExtensionDefault = ".pdf";
        private readonly IHelpOnForm _help;

        public CommandShowHelp(Form form) : this((IHelpOnForm) form)
        {
        }

        public CommandShowHelp(IHelpOnForm help)
        {
            _help = help;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            using (new StatusBusy("Hilfe wird geladen ...", false))
            {
                var helpProvider = Provider.Get();
                if (helpProvider != null)
                    helpProvider.ShowHelp(_help);
                else
                    MessageBox.ShowInfo("Kein Hilfesystem (HelpProvider) konfiguriert.", "Hilfe");
            }
        }

        #endregion
    }
}