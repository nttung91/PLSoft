using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandReload : BaseWindowCommand
    {
        public CommandReload() : base()
        {
            Log = true;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var reloadable = WindowManager.GetActiveWindow() as IReloadableForm;
                if (reloadable != null)
                {
                    reloadable.ReloadBusiness();
                }
            }
        }

        #endregion
    }
}