using System;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmInfoMessageBox : XtraForm
    {
        internal FrmInfoMessageBox(string message, string caption)
        {
            InitForm(message, caption, false);
        }

        internal FrmInfoMessageBox(string message, string caption, bool showCancel)
        {
            InitForm(message, caption, showCancel);
        }

        private void InitForm(string message, string caption, bool showCancel)
        {
            InitializeComponent();

            sbCancel.Visible = showCancel;
            meMessage.Text = message;
            Text = caption;
        }

        private void FrmInfoMessageBox_Shown(object sender, EventArgs e)
        {
            btnOk.Focus();
        }
    }
}