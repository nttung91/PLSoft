using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandFilter : BaseWindowCommand
    {
        public CommandFilter() : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var filterable = WindowManager.GetActiveWindow() as IFilterableForm;
                Debug.Assert(filterable != null, "This Form is not filterable!");
                filterable.Filter();
            }
        }

        #endregion
    }
}