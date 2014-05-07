using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmAsyncWait : XtraForm
    {
        public FrmAsyncWait(string message)
        {
            InitializeComponent();

            meMessage.Text = message;
        }
    }
}