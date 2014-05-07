using Csla.Rules;
using Technical.Permissions;
using Technical.Permissions.Contracts;

namespace PhuLiNet.Business.Common.Authorization.Rules
{
    public class CanDelete : AuthorizationRule
    {
        private readonly string _programId;

        public CanDelete(AuthorizationActions action, string programId)
            : base(action)
        {
            _programId = programId;
        }

        protected override void Execute(AuthorizationContext context)
        {
            context.HasPermission = Provider.Get().HasOperationForProgram(_programId, EDefaultOperation.DeleteData);
        }
    }
}