using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandResetCulture : BaseCommand
    {
        public CommandResetCulture()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            CurrentCulture.Reset();
        }

        #endregion
    }
}