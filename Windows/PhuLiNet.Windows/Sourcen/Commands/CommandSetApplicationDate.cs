using System;
using Windows.Core.Helpers;
using Windows.Core.Helpers;

namespace Windows.Core.Commands
{
    public class CommandSetApplicationDate : BaseCommand
    {
        private DateTime _appDate;

        public CommandSetApplicationDate()
        {
        }

        public CommandSetApplicationDate(DateTime appDate)
        {
            _appDate = appDate;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            ApplicationHelper.ApplicationDate = _appDate;
        }

        #endregion
    }
}