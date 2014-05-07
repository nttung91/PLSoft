using System;
using Windows.Core.Helpers;
using DevExpress.XtraEditors;
using Windows.Core.Helpers;

namespace Windows.Core.Forms
{
    internal partial class FrmSplash : XtraForm
    {
        public FrmSplash()
        {
            InitializeComponent();
            lblInfo.Text = ApplicationHelper.ApplicationName;
            lblVersion.Text = String.Format("Version {0}  -  {1}", ApplicationHelper.ApplicationVersion,
                ApplicationHelper.ApplicationDateString);
        }
    }
}