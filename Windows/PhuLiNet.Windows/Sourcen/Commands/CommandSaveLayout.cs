using System.Diagnostics;
using Windows.Core.BaseForms;

namespace Windows.Core.Commands
{
    public class CommandSaveLayout : BaseWindowCommand
    {
        private readonly string _layoutName;

        public CommandSaveLayout(string layoutName)
            : base()
        {
            _layoutName = layoutName;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var saveAndRestoreLayout = WindowManager.GetActiveWindow() as ISaveAndRestoreGridLayout;
                Debug.Assert(saveAndRestoreLayout != null, "This Form does not implement layout save & restore");
                saveAndRestoreLayout.SaveGridLayout(_layoutName);
            }
        }

        #endregion
    }
}