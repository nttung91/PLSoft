using Technical.Permissions.Attrib;
using Windows.Core.Forms.Logging;

namespace Windows.Core.Commands
{
    [Permission(DefaultPermissions.ORG_Entwicklung)]
    public class CommandShowLog : BaseWindowCommand
    {
        public CommandShowLog()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            WindowManager.ShowWindow<FrmShowLog>("Log-Fenster laden", true);
        }

        #endregion
    }
}