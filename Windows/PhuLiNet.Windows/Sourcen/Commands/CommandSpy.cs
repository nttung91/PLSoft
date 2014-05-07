using System.Diagnostics;
using System.Windows.Forms;
using Windows.Core.Forms.ObjectSpy;
using Windows.Core.BaseForms;
using Windows.Core.Commands;

namespace Windows.Core.Commands
{
    public class CommandSpy : BaseWindowCommand
    {
        public CommandSpy()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            if (WindowManager.GetActiveWindow() != null)
            {
                var spy = WindowManager.GetActiveWindow() as ISpyObject;
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