using System.Windows.Forms;
using Windows.Core.Forms.ObjectSpy;
using Windows.Core.Commands;

namespace Windows.Core.Commands
{
    public class CommandSpyObject : BaseWindowCommand
    {
        private object _objectToSpy;

        public CommandSpyObject(object objectToSpy)
            : base()
        {
            _objectToSpy = objectToSpy;
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (_objectToSpy != null)
            {
                var frmSpy = new FrmObjectSpy();
                frmSpy.SetDataSource(_objectToSpy);
                frmSpy.WindowState = FormWindowState.Normal;
                frmSpy.ShowDialog();
                frmSpy.Dispose();
            }
        }

        #endregion
    }
}