using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.Forms.ObjectSpy;
using Windows.Core.BaseForms;
using Windows.Core.Commands;

namespace Windows.Core.Commands
{
    public class CommandSpyForm : BaseWindowCommand
    {
        private Form _form;

        public CommandSpyForm(Form form)
            : base()
        {
            _form = form;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (_form != null)
            {
                var spy = _form as ISpyObject;
                Debug.Assert(spy != null, "Can't spy this form!");
                if (spy != null)
                {
                    var frmSpy = new FrmObjectSpy();
                    frmSpy.SetDataSource(spy.SpyObject());
                    frmSpy.WindowState = FormWindowState.Normal;

                    frmSpy.ShowDialog();
                    frmSpy.Dispose();
                }
            }
        }

        #endregion
    }
}