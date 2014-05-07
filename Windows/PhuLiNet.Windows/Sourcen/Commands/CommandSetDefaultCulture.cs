using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandSetDefaultCulture : BaseCommand
    {
        public CommandSetDefaultCulture()
        {
            Log = false;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            //Aktuelle Culture auf de-CH setzen, da Menu-Server Englisch sind
            CurrentCulture.Set("de-CH");
        }

        #endregion
    }
}