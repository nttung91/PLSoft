using Technical.Permissions.Attrib;
using Windows.Core.Forms.AdminConsole;

namespace Windows.Core.Commands
{
    [Permission(DefaultPermissions.ORG_Entwicklung)]
    internal class CommandShowAssemblies : BaseDialogCommand
    {
        public CommandShowAssemblies()
            : base()
        {
        }

        #region IApplicationCommand Members

        public override void Execute()
        {
            WindowManager.ShowWindow<FrmAssemblies>("Assemblies anzeigen", false);
        }

        #endregion
    }
}