using System.Windows.Forms;
using Windows.Core.Forms;

namespace Windows.Core.Helpers
{
    internal class AsyncStatusBusy
    {
        private readonly Form _form;

        public AsyncStatusBusy(Form form)
        {
            _form = form;
        }

        public void StartWait(string message)
        {
            var asyncWait = new FrmAsyncWait(message)
            {Owner = _form, StartPosition = FormStartPosition.CenterScreen};
            asyncWait.Show();
        }

        public void EndWait()
        {
            OwnedFormsHelper.RemoveOwnedForm<FrmAsyncWait>(_form);
        }
    }
}