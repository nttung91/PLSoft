using System.Diagnostics;

namespace PhuLiNet.Business.Common.Audit
{
    /// <summary>
    /// Central audit logger instance
    /// </summary>
    public class AuditLogger
    {
        private static IUserAuditLogger _auditLoggerInstance;

        private AuditLogger()
        {
        }

        public static IUserAuditLogger GetInstance()
        {
            if (_auditLoggerInstance == null)
            {
                _auditLoggerInstance = new NoUserAuditLogger();
            }

            return _auditLoggerInstance;
        }

        public static void SetInstance(IUserAuditLogger auditLogger)
        {
            Debug.Assert(auditLogger != null, "auditLogger is null");
            Debug.Assert(_auditLoggerInstance == null, "AuditLogger exists already. Call SetInstance only at startup.");

            _auditLoggerInstance = auditLogger;
        }

        public static void DestroyInstance()
        {
            Debug.Assert(_auditLoggerInstance != null, "AuditLogger is null");
            _auditLoggerInstance = null;
        }
    }
}