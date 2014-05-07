using System.ComponentModel;

namespace PhuLiNet.Business.Common.Security
{
    /// <summary>
    /// Predefined Manor group definitions (Use Manor.Permissions to implement normal user rights)
    /// See http://umgui.um.m/Default.aspx 
    /// </summary>
    internal enum EPhuLiGroups
    {
        [Description("G_O_10016026")]
        InformationTechnologyDepartment,
        [Description("G_O_10014306")]
        SupportServicesHeadquarters
    }
}
