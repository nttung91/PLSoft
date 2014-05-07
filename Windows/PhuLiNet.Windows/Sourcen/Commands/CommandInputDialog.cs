using System.Windows.Forms;
using Windows.Core.Forms;
using Windows.Core.Localization;

namespace Windows.Core.Commands
{
    public class CommandInputDialog<T> : BaseDialogCommand
    {
        private readonly string _inputMessage;
        private readonly string _dialogTitle;
        private T _inputValue;

        public T InputValue
        {
            get { return _inputValue; }
            set { _inputValue = value; }
        }

        public CommandInputDialog(string inputMessage) : this(inputMessage, inputMessage)
        {
        }

        public CommandInputDialog(string dialogTitle, string inputMessage)
        {
            _inputMessage = inputMessage;
            _dialogTitle = dialogTitle;
        }

        public override void Execute()
        {
            var inputDialog = WindowManager.PrepareShowDialog<FrmInputDialog>(BaseFormMessages.ShowField, false);
            inputDialog.InputMessage = _inputMessage;
            inputDialog.InputValue = _inputValue;
            inputDialog.DialogTitle = _dialogTitle;
            inputDialog.InputType = typeof (T);
            inputDialog.LoadBusiness();

            DialogResult = inputDialog.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                _inputValue = (T) inputDialog.InputValue;
            }
            inputDialog.Dispose();
        }
    }
}