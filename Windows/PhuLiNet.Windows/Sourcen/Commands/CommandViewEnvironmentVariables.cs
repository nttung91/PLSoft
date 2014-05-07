using Technical.Permissions.Attrib;
using Windows.Core.Forms.Environment;

namespace Windows.Core.Commands
{
    [Permission(DefaultPermissions.ORG_Entwicklung)]
    public class CommandViewEnvironmentVariables : BaseWindowCommand
    {
        #region IApplicationCommand Members

        public override void Execute()
        {
            var envVarsForm = new FrmEnvironmentVariables();
            envVarsForm.ShowDialog();
            envVarsForm.Dispose();
        }

        #endregion
    }
}