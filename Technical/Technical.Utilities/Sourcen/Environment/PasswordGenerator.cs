using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Technical.Utilities.Extensions;

namespace Technical.Utilities.Environment
{
    public class PasswordGenerator
    {
        private readonly IIdentity _identity;

        [DllImport("Manor_Perl_WinCall.dll", EntryPoint = "Manor_Standard_WinCall_getPswd", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void Manor_getPswd(string userLogin, StringBuilder userPwd);
        internal static string GetPwd(string benutzer)
        {
            var calculatedPwd = new StringBuilder();
            Manor_getPswd(benutzer, calculatedPwd);
            return calculatedPwd.ToString();
        }

        public PasswordGenerator()
        {
            _identity = WindowsIdentity.GetCurrent();
        }

        public PasswordGenerator(IIdentity identity)
        {
            _identity = identity;
        }

        public string GeneratePassword()
        {
            var password = GetPwd(_identity.NameWithoutDomainToUpper());
            return password;
        }
    }
}
