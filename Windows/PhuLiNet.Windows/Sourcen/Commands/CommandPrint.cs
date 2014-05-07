using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandPrint : BaseWindowCommand
    {
        public CommandPrint()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var printable = WindowManager.GetActiveWindow() as IPrintableForm;
                Debug.Assert(printable != null, "This Form is not printable!");
                printable.Print();
            }
        }

        #endregion
    }
}