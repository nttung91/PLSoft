using DevExpress.XtraEditors;

namespace Windows.Core.Forms
{
    public partial class FrmProgress : XtraForm
    {
        public FrmProgress(string statusText)
        {
            InitializeComponent();

            lblStatusText.Text = statusText;
        }

        public void SetProgress(int pct)
        {
            if (pct > pbgProgress.Properties.Minimum && pct <= pbgProgress.Properties.Maximum)
                pbgProgress.Position = pct;
        }
    }
}