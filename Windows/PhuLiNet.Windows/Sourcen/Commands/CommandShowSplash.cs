using System.Windows.Forms;
using Windows.Core.Forms;

namespace Windows.Core.Commands
{
    public class CommandShowSplash : BaseWindowCommand
    {
        private Form _splashForm = null;

        public Form SplashForm
        {
            get { return _splashForm; }
        }

        public CommandShowSplash()
            : base()
        {
            Log = false;
            Audit = false;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            _splashForm = new FrmSplash();
            _splashForm.Show();
            Application.DoEvents();
        }

        #endregion
    }
}