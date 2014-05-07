using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmDisappearInfoMessageBox : XtraForm
    {
        internal FrmDisappearInfoMessageBox(int showforMilliseconds, string message, string caption)
        {
            InitializeComponent();

            meMessage.Text = message;
            Text = caption;
            timerDisappear.Interval = showforMilliseconds;

            lblDisappearInfo.Text = string.Format(lblDisappearInfo.Text,
                Math.Floor(Convert.ToDecimal(showforMilliseconds/1000)));
        }

        public void EnableTimer()
        {
            timerDisappear.Enabled = true;
        }

        private void timerDisappear_Tick(object sender, EventArgs e)
        {
            timerDisappear.Enabled = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FrmDisappearInfoMessageBox_Shown(object sender, EventArgs e)
        {
            picInfo.Focus();
        }
    }
}