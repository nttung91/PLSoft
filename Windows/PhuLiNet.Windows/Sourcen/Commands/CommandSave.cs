using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandSave : BaseWindowCommand
    {
        public CommandSave() : base()
        {
            Log = true;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var savable = WindowManager.GetActiveWindow() as ISavableForm;

                if (savable != null)
                {
                    Debug.Assert(savable.SaveEnabled, "Save is disabled");
                    if (savable.SaveEnabled)
                    {
                        savable.Save();
                    }
                }
            }
        }

        #endregion
    }
}