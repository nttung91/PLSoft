using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Manor.Plugin;
using Manor.Plugin.Application;
using Manor.Plugin.Contracts;
using Manor.Plugin.Menu.MainMenu;
using PhuLiNet.Plugin.Application;
using PhuLiNet.Plugin.Contracts;
using PhuLiNet.Plugin.Manager;
using PhuLiNet.Plugin.Menu;
using PhuLiNet.Plugin.Menu.MainMenu;

namespace PhuLiNet.Plugin
{
    public class InternalHostApplication : IHostApplicationInternals
    {
        private string _startupPath;
        private string _appConfigFile;
        //private string _configId;
        private IPluginManager _pluginManager;
        private IMenuManager _mainMenuManager;
        //private IMenuManager _toolbarManager;
        //private Configurations _configs;
        //private Configuration _activeConfig;

        //public EMenuSource MenuSource
        //{
        //    get
        //    {
        //        if (_activeConfig != null &&
        //            _activeConfig.GetMainMenuConfig() is MenuConfigByDb)
        //        {
        //            return EMenuSource.Database;
        //        }
        //        return EMenuSource.XmlFile;
        //    }
        //}

        public string AppConfigFile
        {
            get { return _appConfigFile; }
            internal set { _appConfigFile = value; }
        }

        public string StartupPath
        {
            get { return _startupPath; }
            internal set { _startupPath = value; }
        }

        //public string LanguageCode { get; set; }
        //public string MenuRootNode { get; set; }

        //public string ConfigId
        //{
        //    get { return _configId; }
        //    internal set { _configId = value; }
        //}

        //public IApplicationInfo GetApplicationInfo()
        //{
        //    if (_applicationInfo == null)
        //    {
        //        LoadApplicationInfo();
        //    }
        //    return _applicationInfo;
        //}

        //public List<IMenuItem> GetMainMenu()
        //{
        //    return _mainMenuManager.GetMenu();
        //}

        //public List<IMenuItem> GetToolbarMenu()
        //{
        //    return _toolbarManager != null ? _toolbarManager.GetMenu() : null;
        //}

        //public IMenuItem GetAutoStartMenuItem()
        //{
        //    IMenuItem autoStartMenuItem = null;

        //    foreach (IMenuItem item in _mainMenuManager.GetMenu())
        //    {
        //        if (item.HasSubMenu)
        //        {
        //            foreach (IMenuItem subMenu in item.SubMenus)
        //            {
        //                if (subMenu.IsValid && subMenu.IsVisible && subMenu.SupportsAutoStart)
        //                {
        //                    autoStartMenuItem = subMenu;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return autoStartMenuItem;
        //}

        public string AutoStartPluginId { get; set; }

        public void AddPlugin(IPlugin plugin)
        {
            _pluginManager.AddPlugin(plugin);
        }

        public IPlugin GetPlugin(string pluginId)
        {
            return _pluginManager.GetPlugin(pluginId);
        }

        public bool PluginExists(string pluginId)
        {
            return _pluginManager.PluginExists(pluginId);
        }

        public IPlugin GetPlugin(Type pluginType)
        {
            return _pluginManager.GetPlugin(pluginType);
        }

        public IList<IPlugin> GetReplacementPlugin(IPlugin oldPlugin)
        {
            return _pluginManager.GetReplacementPlugin(oldPlugin);
        }

        public IPlugin GetPluginByShortcut(string pluginShortcut)
        {
            return _pluginManager.GetPluginByShortcut(pluginShortcut);
        }

        public List<IPlugin> GetPlugins()
        {
            return _pluginManager.GetPlugins();
        }

        public List<IPlugin> GetPluginsAllowed()
        {
            return _pluginManager.GetPluginsAllowed();
        }

        public List<IPluginSummary> GetPluginSummary()
        {
            return _pluginManager.GetPluginSummary();
        }

        public List<IPluginSummary> GetPluginSummaryAllowed()
        {
            return _pluginManager.GetPluginSummaryAllowed();
        }

        public IPluginValidator GetPluginValidator()
        {
            var pluginValidator = new PluginValidator(_pluginManager);
            return pluginValidator;
        }

        //internal void LoadApplicationInfo()
        //{
        //    _applicationInfo = ApplicationFactory.GetInstance(LoadConfig());
        //}

        public void Run()
        {
            InitPluginManager();
            InitMenus();
        }

        public List<IMenuItem> GetMainMenu()
        {
            return _mainMenuManager.GetMenu();
        }

        private void InitPluginManager()
        {
            _pluginManager = PluginManagerFactory.CreateInstance(_startupPath);
        }

        private void InitMenus()
        {
            InitMainMenuManager();
           // InitToolbarMenuManager();

            AssignPluginsToMenu(GetMainMenu());
           // AssignPluginsToMenu(GetToolbarMenu());
        }

        public void ReRun()
        {
            InitMenus();
        }

        private void InitMainMenuManager()
        {
            _mainMenuManager = MenuManagerFactory.CreateInstanceByPlugin(GetPlugins());
        }

        //private void InitToolbarMenuManager()
        //{
        //    if (_activeConfig.ToolbarConfigExists())
        //    {
        //        if (_activeConfig.GetToolbarConfig() is MenuConfigByFile)
        //        {
        //            var menuConfigByFile = _activeConfig.GetToolbarConfig() as MenuConfigByFile;
        //            _toolbarManager =
        //                MenuManagerFactory.CreateInstanceByFile(Path.Combine(_startupPath, menuConfigByFile.ConfigFile));
        //        }
        //        else
        //        {
        //            throw new PluginHostException("Unkown menu config found");
        //        }
        //    }
        //}

        private void AssignPluginsToMenu(IEnumerable<IMenuItem> menuItemList)
        {
            var pluginAllocator = new PluginAllocator(_pluginManager);
            pluginAllocator.AssignPluginsToMenu(menuItemList);
        }
    }
}