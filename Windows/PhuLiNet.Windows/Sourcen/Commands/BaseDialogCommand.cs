using System.Windows.Forms;

namespace Windows.Core.Commands
{
    /// <summary>
    /// Base application command for showing modal dialogs
    /// </summary>
    public abstract class BaseDialogCommand : BaseCommand
    {
        public DialogResult DialogResult { get; set; }

        protected BaseDialogCommand()
        {
        }
    }
}