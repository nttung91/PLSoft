using System.Collections.Generic;
using System.Security.Principal;
using Technical.Permissions.Contracts;
using Technical.Utilities.Helpers;

namespace Technical.Permissions.Empty
{
    /// <summary>
    /// All permissions
    /// </summary>
    public class AllPermissionsProvider : IPermissionProvider
    {
        public IIdentity Identity { get; set; }

        public void Reset()
        {
        }

        public bool HasPermission(string permissionId)
        {
            //user has all permissions
            return true;
        }

        public bool CanAccessProgram(int artMepId)
        {
            //user has all permissions
            return true;
        }

        public bool CanAccessProgram(string mepId)
        {
            //user has no permissions
            return true;
        }

        public bool HasOperationForProgram(string programId, string operationId)
        {
            return true;
        }

        public bool HasOperationForProgram(string programId, EDefaultOperation defaultOperation)
        {
            return true;
        }

        public List<string> GetOperationsForProgram(string programId)
        {
            return new List<string>
            {
                EnumHelper.GetEnumDescription(EDefaultOperation.ReadDataAndAccessModule),
                EnumHelper.GetEnumDescription(EDefaultOperation.WriteData),
                EnumHelper.GetEnumDescription(EDefaultOperation.DeleteData)
            };
        }


        public void Initialize()
        {
        }
    }
}