using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using Csla;
using Technical.Utilities.Extensions;
using Technical.Utilities.Helpers;
using PhuLiNet.Business.Common.Languages;

namespace PhuLiNet.Business.Common.Security
{
    [Serializable]
    public class PhuLiIdentity : ReadOnlyBase<PhuLiIdentity>, IIdentity
    {
        #region Business Methods

        private bool _isAuthenticated;
        private string _name = string.Empty;
        private string _nameWithoutDomain = string.Empty;
        private Language _language;
        private readonly List<string> _roles = new List<string>();

        public string AuthenticationType
        {
            get { return "Csla"; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string NameWithoutDomain
        {
            get { return _nameWithoutDomain; }
        }

        public Language Language
        {
            get { return _language; }
            set { _language = value; }
        }

        protected override object GetIdValue()
        {
            return _name;
        }

        internal bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        #endregion

        #region Factory Methods

        internal static PhuLiIdentity UnauthenticatedIdentity()
        {
            return new PhuLiIdentity();
        }

        internal static PhuLiIdentity GetIdentity()
        {
            return DataPortal.Fetch<PhuLiIdentity>
                (new WindowsAuthenticationCriteria());
        }

        internal static PhuLiIdentity GetMobileIdentity()
        {
            return DataPortal.Fetch<PhuLiIdentity>
                (new MobileWindowsAuthenticationCriteria());
        }

        private PhuLiIdentity()
        {
            /* require use of factory methods */
        }

        #endregion

        #region Data Access

        [Serializable]
        private class WindowsAuthenticationCriteria
        {
        }

        [Serializable]
        private class MobileWindowsAuthenticationCriteria
        {
        }

        private void DataPortal_Fetch(WindowsAuthenticationCriteria criteria)
        {
            WindowsIdentity windowsUser = WindowsIdentity.GetCurrent();
            Debug.Assert(windowsUser != null, "windowsUser != null");
            var windowsPrincipal = new WindowsPrincipal(windowsUser);

            _name = windowsUser.Name;
            _nameWithoutDomain = windowsUser.NameWithoutDomain();

            _isAuthenticated = windowsUser.IsAuthenticated;

            if (windowsPrincipal.IsInRole(EnumHelper.GetEnumDescription(EPhuLiGroups.InformationTechnologyDepartment)))
            {
                _roles.Add(EPhuLiGroups.InformationTechnologyDepartment.ToString());
            }

            if (windowsPrincipal.IsInRole(EnumHelper.GetEnumDescription(EPhuLiGroups.SupportServicesHeadquarters)))
            {
                _roles.Add(EPhuLiGroups.SupportServicesHeadquarters.ToString());
            }
        }

        private void DataPortal_Fetch(MobileWindowsAuthenticationCriteria criteria)
        {
            WindowsIdentity windowsUser = WindowsIdentity.GetCurrent();
            Debug.Assert(windowsUser != null, "windowsUser != null");
            _name = windowsUser.Name;

            string[] split = {@"\"};
            string[] nameDomain = _name.Split(split, StringSplitOptions.None);
            if (nameDomain.Length > 1)
                _nameWithoutDomain = nameDomain[1];

            _isAuthenticated = true;
        }

        #endregion
    }
}