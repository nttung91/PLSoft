using System;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmYesNoMessageBox : XtraForm
    {
        private bool _displayAgainValue = true;

        public bool DisplayAgainValue
        {
            get { return _displayAgainValue; }
        }

        internal FrmYesNoMessageBox(string message, string caption, bool showDisplayAgainFlag)
        {
            InitializeComponent();

            meMessage.Text = message;
            Text = caption;
            chkDisplay.Visible = showDisplayAgainFlag;
        }

        private void chkDisplay_CheckedChanged(object sender, EventArgs e)
        {
            _displayAgainValue = !chkDisplay.Checked;
        }
    }
}