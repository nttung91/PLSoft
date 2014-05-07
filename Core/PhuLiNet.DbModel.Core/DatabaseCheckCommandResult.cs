using System;

namespace DbModel.Core
{
    public class DatabaseCheckCommandResult
    {
        public bool Allowed { get; set; }
        public string NotAllowedReason { get; set; }

        public DatabaseCheckCommandResult(bool allowed, string notAllowedReason = null)
        {
            Allowed = allowed;
            NotAllowedReason = notAllowedReason;
        }

        public static implicit operator DatabaseCheckCommandResult(bool allowed)
        {
            return new DatabaseCheckCommandResult(allowed);
        }

        public string CreateMessage(string error)
        {
            if (!string.IsNullOrEmpty(NotAllowedReason))
            {
                error += Environment.NewLine + NotAllowedReason;
            }
            return error;
        }
    }
}