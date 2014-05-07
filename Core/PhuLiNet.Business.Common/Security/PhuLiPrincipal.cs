using System;
using System.Diagnostics;
using System.Security.Principal;
using Csla;
using Csla.Security;

namespace PhuLiNet.Business.Common.Security
{
    [Serializable]
    public class PhuLiPrincipal : CslaPrincipal
    {
        private PhuLiPrincipal(IIdentity identity)
            : base(identity)
        {
        }

        public static bool Login()
        {
            return SetPrincipal(PhuLiIdentity.GetIdentity());
        }

        public static bool LoginAsWindowsPrincipal()
        {
            WindowsIdentity windowsUser = WindowsIdentity.GetCurrent();
            Debug.Assert(windowsUser != null, "windowsUser != null");
            var windowsPrincipal = new WindowsPrincipal(windowsUser);

            if (windowsUser.IsAuthenticated)
            {
                ApplicationContext.User = windowsPrincipal;
            }

            return windowsUser.IsAuthenticated;
        }

        public static bool MobileLogin()
        {
            return SetPrincipal(PhuLiIdentity.GetMobileIdentity());
        }

        private static bool SetPrincipal(PhuLiIdentity identity)
        {
            if (identity.IsAuthenticated)
            {
                var principal = new PhuLiPrincipal(identity);
                ApplicationContext.User = principal;
            }
            return identity.IsAuthenticated;
        }

        public static void Logout()
        {
            var identity = PhuLiIdentity.UnauthenticatedIdentity();
            var principal = new PhuLiPrincipal(identity);
            ApplicationContext.User = principal;
        }

        public override bool IsInRole(string role)
        {
            var identity = (PhuLiIdentity) Identity;
            return identity.IsInRole(role);
        }
    }
}