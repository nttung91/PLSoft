using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Windows.Core.Settings
{
    public static class RegistryHelper
    {
        public static string CurrentUserApplicationPath
        {
            get { return Application.UserAppDataRegistry.ToString(); }
        }

        public static string CurrentUserApplicationPathWithoutHKey
        {
            get
            {
                return Application.UserAppDataRegistry.ToString().Replace(Registry.CurrentUser.Name + @"\", String.Empty);
            }
        }

        private static void stripCurrentUser(ref string key)
        {
            key = key.Replace(Registry.CurrentUser.Name + @"\", "");
        }

        public static bool CurrentUserHasKey(string key)
        {
            stripCurrentUser(ref key);
            bool result = false;
            RegistryKey subKey = Registry.CurrentUser.OpenSubKey(key);
            if (subKey != null)
            {
                result = true;
                subKey.Close();
            }

            return result;
        }

        public static void DeleteCurrentUserKey(string key)
        {
            stripCurrentUser(ref key);
            RegistryKey subKey = Registry.CurrentUser.OpenSubKey(key);

            if (subKey != null)
            {
                subKey.Close();
                Registry.CurrentUser.DeleteSubKeyTree(key);
            }
        }
    }
}