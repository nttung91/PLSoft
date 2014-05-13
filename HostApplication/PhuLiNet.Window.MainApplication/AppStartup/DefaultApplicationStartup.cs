using System;
using System.Windows.Forms;
using Windows.Core.Startup;
using MessageBox = Windows.Core.Forms.MessageBox;

namespace PhuLiNet.Window.MainApplication.AppStartup
{
    internal class DefaultApplicationStartup : IApplicationStartup
    {
        //private AppOptions _cmdLineOptions;
        private Form _mainForm;
        private Startup _startupLogic;
        private readonly string _startupPath;
        internal readonly string ConfigFile = "PhuLiNetMenu.xml"; 

        ////public AppOptions CmdLineOptions
        ////{
        ////    get { return _cmdLineOptions; }
        ////    set { _cmdLineOptions = value; }
        ////}

        public DefaultApplicationStartup()
        {
        }

        public DefaultApplicationStartup(string startupPath)
        {
            _startupPath = startupPath;
        }

        #region IApplicationStartup Members

        public void PreInit()
        {
            _startupLogic = new Startup();
            _startupLogic.InitWindowsForms();
            _startupLogic.InitApplicationName();
            _startupLogic.InitHostApplication();
        }

        public void Init()
        {
            try
            {
                _startupLogic.StartupPath = _startupPath;
                _startupLogic.AppConfigFile = ConfigFile;
                _startupLogic.InitPluginApplication(null);
            }
            catch (Exception e)
            {
                Windows.Core.Forms.MessageBox.ShowError("Error in PluginApplication", e, "PluginApplication");
                throw;
            }
        }

        public void BeforeSplash()
        {
            try
            {
                _startupLogic.SetApplicationInfo();
            }
            catch (Exception e)
            {
                MessageBox.ShowError("Error in PluginApplication", e, "PluginApplication");
                throw;
            }
        }

        public void ShowSplash()
        {
            try
            {
                _startupLogic.ShowSplash();
            }
            catch (Exception e)
            {
                MessageBox.ShowError("Error in PluginApplication", e, "PluginApplication");
                throw;
            }
        }

        public void AfterSplash()
        {
            try
            {
                _startupLogic.RunPluginApplication();
            }
            catch (Exception e)
            {
                MessageBox.ShowError("Error in PluginApplication", e, "PluginApplication");
                throw;
            }
        }

        public void BeforeRun()
        {
            try
            {
                //Startform vorbereiten
                _mainForm = new FrmStartForm();
                _startupLogic.InitWindowManager(_mainForm);
                //_startupLogic.SetMainForm(_mainForm, ((FrmStartForm)_mainForm).bsiStatus);
                _startupLogic.CloseSplash();
            }
            catch (Exception e)
            {
                MessageBox.ShowError("Error in PluginApplication", e, "PluginApplication");
                throw;
            }
        }

        public void Run()
        {
            Application.Run(_mainForm);
        }

        public void Shutdown()
        {
            var shutDownLogic = new Shutdown();
            shutDownLogic.UnSetMainForm();
            shutDownLogic.DeInitContexts();
            shutDownLogic.Logout();
        }

        #endregion
    }
}