using System.Windows.Forms;
using PhuLiNet.Business.Common.Audit;
using Manor.Logging;
using Technical.Permissions.AttributeHelper;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace Windows.Core.Commands
{
    public class CommandExecutor
    {
        private static CommandExecutor _instance;
        private const string CmdType = "Command";

        private CommandExecutor()
        {
        }

        public static void Execute(IApplicationCommand cmd)
        {
            GetInstance().Execute(cmd, true, true);
        }

        public static void ExecuteNoLog(IApplicationCommand cmd)
        {
            GetInstance().Execute(cmd, false, false);
        }

        private static CommandExecutor GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CommandExecutor();
            }

            return _instance;
        }

        private void Execute(IApplicationCommand cmd, bool log, bool audit)
        {
            if (audit && cmd.Audit)
            {
                AuditCommand(cmd);
            }

            if (log && cmd.Log)
            {
                Logger.GetInstance().Debug(typeof (CommandExecutor), "Executing command " + cmd.GetType().Name, null);
            }

            if (HasPermissionOnCmd(cmd))
            {
                cmd.Execute();
            }
            else
            {
                ShowNoPermissionMessage();
            }
        }

        private bool HasPermissionOnCmd(IApplicationCommand cmd)
        {
            var permissionValidator = new PermissionAttributeValidator(cmd);
            var hasPermission = permissionValidator.HasPermissionOnInstance();

            return hasPermission;
        }

        private void ShowNoPermissionMessage()
        {
            MessageBox.ShowWarning(CommandExecutorRes.NoPermissionMsg, CommandExecutorRes.NoPermissionCaption);
        }

        private void AuditCommand(IApplicationCommand cmd)
        {
            string moduleName = GetModuleName(cmd);
            AuditLogger.GetInstance().LogStart(moduleName);
        }

        private string GetModuleName(IApplicationCommand cmd)
        {
            string moduleName = string.Format("{0}|{1}|{2}|{3}", Application.ProductName, CmdType,
                cmd.GetType().Assembly.GetName().Name, cmd.GetType().Name);
            return moduleName;
        }
    }
}