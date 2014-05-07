using System;

namespace PhuLiNet.Business.Common.Authorization
{
    public class CheckCommandResult
    {
        public bool Allowed { get; private set; }
        public string NotAllowedReason { get; private set; }

        public CheckCommandResult(bool allowed, string notAllowedReason = null)
        {
            Allowed = allowed;
            NotAllowedReason = notAllowedReason;
        }

        public static implicit operator CheckCommandResult(bool allowed)
        {
            return new CheckCommandResult(allowed);
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