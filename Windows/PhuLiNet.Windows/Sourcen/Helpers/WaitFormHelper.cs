using System;
using DevExpress.XtraSplashScreen;
using Windows.Core.Forms;
using Windows.Core.WindowsManager;

namespace Windows.Core.Helpers
{
    internal static class WaitFormHelper
    {
        private static readonly Object ThisLock = new Object();

        private static readonly SplashScreenManager SplashScreenManager =
            new SplashScreenManager(WindowManager.GetInstance().GetMainWindow(), typeof (FrmWait), true, true);

        public static void Start(string statusText)
        {
            if (!SplashScreenManager.IsSplashFormVisible)
            {
                lock (ThisLock)
                {
                    if (!SplashScreenManager.IsSplashFormVisible)
                    {
                        SplashScreenManager.ShowWaitForm();
                        SplashScreenManager.SetWaitFormDescription(statusText);
                    }
                }
            }
            else
            {
                SplashScreenManager.SetWaitFormDescription(statusText);
            }
        }

        public static void Stop()
        {
            if (SplashScreenManager.IsSplashFormVisible)
            {
                lock (ThisLock)
                {
                    if (SplashScreenManager.IsSplashFormVisible)
                    {
                        SplashScreenManager.CloseWaitForm();
                        SplashScreenManager.WaitForSplashFormClose();
                    }
                }
            }
        }
    }
}