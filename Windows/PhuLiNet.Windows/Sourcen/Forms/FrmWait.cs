using DevExpress.XtraWaitForm;

namespace Windows.Core.Forms
{
    internal partial class FrmWait : WaitForm
    {
        public FrmWait()
        {
            InitializeComponent();
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            lblStatusText.Text = description;
        }
    }
}