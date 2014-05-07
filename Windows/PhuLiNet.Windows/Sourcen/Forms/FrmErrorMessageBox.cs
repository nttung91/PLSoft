using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmErrorMessageBox : XtraForm
    {
        internal FrmErrorMessageBox(string message, string errortext, string caption)
        {
            InitializeComponent();

            lblInfo.Text = message;
            Text = caption;
            meErrortext.Text = errortext;
        }
    }
}