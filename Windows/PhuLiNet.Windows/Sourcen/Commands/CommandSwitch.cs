using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandSwitch : BaseWindowCommand
    {
        public CommandSwitch() : base()
        {
            Log = true;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var switchable = WindowManager.GetActiveWindow() as ISwitchableForm;
                if (switchable != null) switchable.Switch();
            }
        }

        #endregion
    }
}