using System.Collections.Generic;
using System.Security.Principal;
using Technical.Permissions.Contracts;

namespace Technical.Permissions.Empty
{
    /// <summary>
    /// No permissions
    /// </summary>
    public class NoPermissionsProvider : IPermissionProvider
    {
        public IIdentity Identity { get; set; }

        public void Reset()
        {
        }

        public bool HasPermission(string permissionId)
        {
            //user has no permissions
            return false;
        }

        public bool CanAccessProgram(int artMepId)
        {
            //user has no permissions
            return false;
        }

        public bool CanAccessProgram(string mepId)
        {
            //user has no permissions
            return false;
        }

        public bool HasOperationForProgram(string programId, string operationId)
        {
            return false;
        }

        public bool HasOperationForProgram(string programId, EDefaultOperation defaultOperation)
        {
            return false;
        }

        public List<string> GetOperationsForProgram(string programId)
        {
            return new List<string>();
        }


        public void Initialize()
        {
        }
    }
}