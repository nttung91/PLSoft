using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandSetCulture : BaseCommand
    {
        private string _cultureName;

        public CommandSetCulture(string cultureName)
        {
            _cultureName = cultureName;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            CurrentCulture.Set(_cultureName);
        }

        #endregion
    }
}