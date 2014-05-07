namespace PhuLiNet.Business.Common.Audit
{
    /// <summary>
    /// Logs user actions
    /// </summary>
    public interface IUserAuditLogger
    {
        void LogStart(string moduleName);
        void LogStart(string moduleName, string objType);
    }
}