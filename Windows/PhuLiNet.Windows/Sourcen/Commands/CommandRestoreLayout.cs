using Windows.Core.BaseForms;
using Windows.Core.Forms;
using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandRestoreLayout : BaseWindowCommand
    {
        private readonly string _layoutName;

        public CommandRestoreLayout(string layoutName)
        {
            _layoutName = layoutName;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var saveAndRestoreLayout = WindowManager.GetActiveWindow() as ISaveAndRestoreGridLayout;

                if (saveAndRestoreLayout != null)
                {
                    saveAndRestoreLayout.RestoreGridLayout(_layoutName);
                    MessageBox.ShowInfo(BaseFormMessages.LayoutReset);
                }
            }
        }

        #endregion
    }
}