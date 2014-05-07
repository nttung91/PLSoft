using System.Windows.Forms;
using Windows.Core.Forms.AdminConsole;

namespace Windows.Core.Commands
{
    internal class CommandSelectForm : BaseDialogCommand
    {
        private Form _selectedForm;

        public Form SelectedForm
        {
            get { return _selectedForm; }
            set { _selectedForm = value; }
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            var form = WindowManager.PrepareShowDialog<FrmSelectForm>("Formular wählen", false);
            form.LoadBusiness();
            DialogResult = form.ShowDialog();

            if (DialogResult == DialogResult.OK)
            {
                _selectedForm = form.SelectedForm;
            }

            form.Dispose();
        }

        #endregion
    }
}