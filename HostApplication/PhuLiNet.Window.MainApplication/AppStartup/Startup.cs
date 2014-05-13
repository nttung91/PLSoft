using System.Windows.Forms;
using Windows.Core.Commands;
using Windows.Core.Helpers;
using Windows.Core.WindowsManager;
using DevExpress.XtraBars;
using Manor.Plugin;
using Manor.Plugin.Application;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Window.MainApplication.Host;

namespace PhuLiNet.Window.MainApplication.AppStartup
{
    internal class Startup
    {
        private string _startupPath;
        private string _appConfigFile;
        private Form _splashForm;

        public string AppConfigFile
        {
            get { return _appConfigFile; }
            set
            {
                _appConfigFile = value;
                if (_appConfigFile != null)
                    _appConfigFile = _appConfigFile.Trim();
            }
        }

        public string StartupPath
        {
            get { return _startupPath; }
            set { _startupPath = value; }
        }

        public void Login()
        {
            //ManorPrincipal.Login();
        }

        public void InitHostApplication()
        {
            HostApplication.SetInstance(HostApplicationInfo.Get());
            PluginHost.SetInstance(PluginHostImpl.Get());
        }

        public void InitApplicationName()
        {
            CommandExecutor.ExecuteNoLog(new CommandSetApplicationName());
        }

        public void InitPluginApplication(string configId)
        {
            HostApplicationFactory.CreateInstance(_startupPath, _appConfigFile, configId);
        }

        public void SetApplicationInfo()
        {
            IHostApplicationInternals pluginApp = HostApplicationFactory.GetInstance();
            //IApplicationInfo appInfo = pluginApp.GetApplicationInfo();
            //CommandExecutor.ExecuteNoLog(new CommandSetApplicationName(appInfo.Name));
            //CommandExecutor.ExecuteNoLog(new CommandSetApplicationVersion(appInfo.Version));
            //CommandExecutor.ExecuteNoLog(new CommandSetApplicationDate(appInfo.Date));
        }

        public void RunPluginApplication()
        {
            IHostApplicationInternals pluginApp = HostApplicationFactory.GetInstance();
            //pluginApp.LanguageCode = UserLanguage.Get().LangId;
            pluginApp.Run();
        }

        public void SetAutoStartPlugin(string autoStartPluginId)
        {
            IHostApplicationInternals pluginApp = HostApplicationFactory.GetInstance();
         //   pluginApp.AutoStartPluginId = autoStartPluginId;
        }

        public void ShowSplash()
        {
            var showSplash = new CommandShowSplash();
            CommandExecutor.Execute(showSplash);
            _splashForm = showSplash.SplashForm;
        }

        public void CloseSplash()
        {
            if (_splashForm != null)
            {
                _splashForm.Close();
                _splashForm.Dispose();
                _splashForm = null;
            }
        }

        public void SetMainForm(Form frmMain, BarItem statusBarItem)
        {
            StatusBusy.SetMainForm(frmMain, statusBarItem);
        }

        public void InitWindowManager(Form mdiContainer)
        {
            WindowManager.CreateInstance(mdiContainer);
        }

        public void InitWindowsForms()
        {
            CommandExecutor.Execute(new CommandInitWindowsFormsApp());
        }
    }
}