namespace PhuLiNet.Business.Common.Audit
{
    public class NoUserAuditLogger : IUserAuditLogger
    {
        public void LogStart(string moduleName)
        {
        }

        public void LogStart(string moduleName, string objType)
        {
        }
    }
}