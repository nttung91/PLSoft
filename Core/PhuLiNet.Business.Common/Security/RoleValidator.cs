using Csla;

namespace PhuLiNet.Business.Common.Security
{
    /// <summary>
    /// Validates predefined manor roles
    /// Don not use to check other business permissions (Use Manor.Permissions for implementing user rights)
    /// </summary>
    public class RoleValidator
    {
        public static bool IsInformationTechnologyOrSupportServicesStaff()
        {
            return ApplicationContext.User.IsInRole(EPhuLiGroups.InformationTechnologyDepartment.ToString()) ||
                   ApplicationContext.User.IsInRole(EPhuLiGroups.SupportServicesHeadquarters.ToString());
        }
    }
}