using System.Collections.Generic;
using System.Security.Principal;

namespace Technical.Permissions.Contracts
{
    public interface IPermissionProvider
    {
        IIdentity Identity { get; set; }

        /// <summary>
        /// Initalize permissions
        /// </summary>
        void Initialize();

        /// <summary>
        /// Reset permissions (delete all)
        /// </summary>
        void Reset();

        /// <summary>
        /// Returns true if permission is assigned to user
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        bool HasPermission(string permissionId);

        /// <summary>
        /// Returns true if user can access/start the given program.
        /// ONLY for compatility reasons to check permissions for external plugins/programs
        /// </summary>
        /// <returns></returns>
        bool CanAccessProgram(int programArtId);

        /// <summary>
        /// Returns true if user can access/start the given program
        /// </summary>
        /// <returns></returns>
        bool CanAccessProgram(string programId);

        /// <summary>
        /// Returns true if user has the given operation
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="operationId"></param>
        /// <returns></returns>
        bool HasOperationForProgram(string programId, string operationId);

        /// <summary>
        /// Returns true if user has the given default operation
        /// </summary>
        /// <param name="programId"></param>
        /// <param name="defaultOperation"></param>
        /// <returns></returns>
        bool HasOperationForProgram(string programId, EDefaultOperation defaultOperation);

        /// <summary>
        /// Returns all allowed operations
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        List<string> GetOperationsForProgram(string programId);
    }
}