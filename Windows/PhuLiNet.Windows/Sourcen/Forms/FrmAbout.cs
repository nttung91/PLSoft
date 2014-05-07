using System;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;
using Windows.Core.BaseForms;
using Windows.Core.Helpers;

namespace Windows.Core.Forms
{
    internal partial class FrmAbout : FrmBase
    {
        public FrmAbout()
        {
            InitializeComponent();
            Text = String.Format("Über {0}", ApplicationHelper.ApplicationName);
            lblProductName.Text = ApplicationHelper.ApplicationName;
            lblVersion.Text = String.Format("Version {0} vom {1}", ApplicationHelper.ApplicationVersion,
                ApplicationHelper.ApplicationDateString);
            lblCopyright.Text = ApplicationHelper.ApplicationCopyright;
            lblCompanyName.Text = ApplicationHelper.ApplicationCompany;
            lblMaschineName.Text = String.Format("Hostname: {0}", System.Environment.MachineName);
        }
    }
}