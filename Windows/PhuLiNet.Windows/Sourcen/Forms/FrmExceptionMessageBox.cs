using System;
using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    internal partial class FrmExceptionMessageBox : XtraForm
    {
        internal FrmExceptionMessageBox(Exception exception)
        {
            InitializeComponent();
            picError.Image = IconManager.GetBitmap(EIcons.close_b_32);
            meExceptionText.Text = exception.ToString();
            if (exception.InnerException != null) meInnerException.Text = exception.InnerException.ToString();
            meStackTrace.Text = exception.StackTrace;
        }
    }
}