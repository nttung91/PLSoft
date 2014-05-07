using System;

namespace PhuLiNet.Business.Common.Authorization
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class AuthorizationProgramIdAttribute : Attribute
    {
        public string ProgramId { get; set; }

        public AuthorizationProgramIdAttribute(string programId)
        {
            ProgramId = programId;
        }
    }
}