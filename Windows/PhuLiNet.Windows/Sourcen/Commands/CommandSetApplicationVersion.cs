using System;
using Windows.Core.Helpers;
using Windows.Core.Helpers;

namespace Windows.Core.Commands
{
    public class CommandSetApplicationVersion : BaseCommand
    {
        private Version _appVersion;

        public CommandSetApplicationVersion()
        {
        }

        public CommandSetApplicationVersion(Version appVersion)
        {
            _appVersion = appVersion;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            ApplicationHelper.ApplicationVersion = _appVersion;
        }

        #endregion
    }
}