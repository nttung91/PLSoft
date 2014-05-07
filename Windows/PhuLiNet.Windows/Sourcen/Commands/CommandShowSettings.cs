using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandShowSettings : BaseWindowCommand
    {
        public CommandShowSettings()
            : base()
        {
            Log = true;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var formSettings = WindowManager.GetActiveWindow() as IFormSettings;
                Debug.Assert(formSettings != null, "This Form has is no settings!");
                formSettings.ShowSettings();
            }
        }

        #endregion
    }
}