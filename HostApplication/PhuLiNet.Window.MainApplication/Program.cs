using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Core.Startup;
using PhuLiNet.Window.MainApplication.AppStartup;

namespace PhuLiNet.Window.MainApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IApplicationStartup startupLogic = new DefaultApplicationStartup(Application.StartupPath);
            startupLogic.PreInit();

            startupLogic.Init();
            startupLogic.BeforeSplash();
            startupLogic.ShowSplash();
            startupLogic.AfterSplash();
            startupLogic.BeforeRun();

            //Run application and show main form
            startupLogic.Run();

            //Shutdown application
            startupLogic.Shutdown();
        }
    }
}
