using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmWarningMessageBox : XtraForm
    {
        internal FrmWarningMessageBox(string message, string caption)
        {
            InitializeComponent();

            meMessage.Text = message;
            Text = caption;
        }
    }
}