using System;
using Windows.Core.WindowsManager;

namespace Windows.Core.Commands
{
    public abstract class BaseCommand : IApplicationCommand
    {
        protected IWindowManager WindowManager
        {
            get { return WindowsManager.WindowManager.GetInstance(); }
        }

        #region IApplicationCommand Members

        public bool Log { get; set; }

        public bool Audit { get; set; }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }

        #endregion

        protected BaseCommand()
        {
            Log = true;
            Audit = true;
        }
    }
}