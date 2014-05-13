using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Manor.Plugin.Application;
using PhuLiNet.Plugin.Xml;

namespace PhuLiNet.Plugin.Application.DataAdapter
{
    internal class XmlDataAdapter : IAppDataAdapter
    {
        private XmlDocument _appConfig;
        private XmlNamespaceManager _nsmgr;
        private static bool _isValid;

        internal XmlDataAdapter(XmlDocument appConfig)
        {
            _appConfig = appConfig;
            _isValid = true;
        }

        #region IAppDataAdapter Members

        public IApplicationInfo Load()
        {
            CreateNamespaceManager();

            var app = new ApplicationInfo();

            XmlNode root = _appConfig.DocumentElement;
            XmlNode xmlAppSettings = root.SelectSingleNode("pa:settings", _nsmgr);

            
            XmlNode xmlName = xmlAppSettings.SelectSingleNode("pa:appName", _nsmgr);
            app.Name = xmlName.InnerText;

            XmlNode xmlVersion = xmlAppSettings.SelectSingleNode("pa:appVersion", _nsmgr);
            app.Version = new Version(xmlVersion.InnerText);

            XmlNode xmlDate = xmlAppSettings.SelectSingleNode("pa:appDate", _nsmgr);
            app.Date = DateTime.Parse(xmlDate.InnerText);

            XmlNode xmlAutoStart = xmlAppSettings.SelectSingleNode("pa:autoStart", _nsmgr);
            if (xmlAutoStart != null)
            {
                app.AutoStart = Convert.ToBoolean(xmlAutoStart.InnerText);
            }

            return app;
        }

        public Configurations LoadConfigs()
        {
            Debug.Assert(_isValid, "AppConfig is not valid");

            CreateNamespaceManager();

            var configs = new Configurations();

            XmlNode root = _appConfig.DocumentElement;
            XmlNodeList xmlConfigs = root.SelectNodes("pa:config", _nsmgr);

            foreach (XmlNode node in xmlConfigs)
            {
                Configuration config = CreateConfig(node);
                configs.Add(config);
            }

            return configs;
        }

        public Dependencies LoadDependencies()
        {
            Debug.Assert(_isValid, "AppConfig is not valid");

            CreateNamespaceManager();

            var dependencies = new Dependencies();

            XmlNode root = _appConfig.DocumentElement;
            XmlNodeList xmlConfigs = root.SelectNodes("pa:dependencies", _nsmgr);

            if (xmlConfigs.Count == 1)
            {
                xmlConfigs = xmlConfigs[0].SelectNodes("pa:dependency", _nsmgr);

                foreach (XmlNode node in xmlConfigs)
                {
                    Dependency d = CreateDependency(node);
                    dependencies.Add(d);
                }
            }

            return dependencies;
        }

        #endregion

        private void CreateNamespaceManager()
        {
            //Add the namespace.
            _nsmgr = new XmlNamespaceManager(_appConfig.NameTable);
            _nsmgr.AddNamespace("pa", "http://www.manor.ch/PluginApp.xsd");
        }

        private Dependency CreateDependency(XmlNode node)
        {
            var d = new Dependency();

            if (node.Attributes["id"] != null)
            {
                d.Id = node.Attributes["id"].Value;
            }

            if (node.Attributes["file"] != null)
            {
                d.ConfigFile = node.Attributes["file"].Value;
            }

            if (node.Attributes["type"] != null)
            {
                d.ResolverType = node.Attributes["type"].Value;
            }

            return d;
        }

        private Configuration CreateConfig(XmlNode node)
        {
            var config = new Configuration();
            config.Id = node.Attributes["id"].Value;

            if (node.Attributes["default"] != null)
            {
                config.Default = Convert.ToBoolean(node.Attributes["default"].Value);
            }

            XmlNodeList xmlMenus = node.SelectNodes("pa:menu", _nsmgr);

            foreach (XmlNode menuNode in xmlMenus)
            {
                IMenuConfig menu = CreateMenu(menuNode);
                config.MenuConfigs.Add(menu);
            }

            return config;
        }

        private IMenuConfig CreateMenu(XmlNode node)
        {
            IMenuConfig menu = null;

            if (node.Attributes["file"] != null)
            {
                menu = new MenuConfigByFile();
            }
            else if (node.Attributes["database"] != null)
            {
                menu = new MenuConfigByDb();
            }
            else
            {
                throw new PluginHostException("Corrupted menu config");
            }

            if (node.Attributes["type"] != null)
            {
                menu.Type = node.Attributes["type"].Value;
            }

            if (node.Attributes["file"] != null)
            {
                ((MenuConfigByFile) menu).ConfigFile = node.Attributes["file"].Value;
            }

            if (node.Attributes["database"] != null)
            {
                ((MenuConfigByDb) menu).ConfigString = node.Attributes["database"].Value;
            }

            return menu;
        }

        public void Validate()
        {
            XmlSchema menuItemsSchema = LoadMenuItemsSchema();
            _appConfig.Schemas.Add(menuItemsSchema);

            _appConfig.Validate(MenuItemsValidationEventHandler);
        }

        private void MenuItemsValidationEventHandler(object sender, ValidationEventArgs args)
        {
            _isValid = false;
            string message = string.Format("Xml-AppConfig [{0}] validation failed: {1}", _appConfig.BaseURI,
                args.Message);
            Debug.Assert(false, message);
            throw new PluginHostException(message);
        }

        private void SchemaValidationEventHandler(object sender, ValidationEventArgs args)
        {
            _isValid = false;
            string message = "Schema validation failed " + args.Message;
            Debug.Assert(false, message);
            throw new PluginHostException(message);
        }

        private XmlSchema LoadMenuItemsSchema()
        {
            XmlDocument xmlSchemaDoc = XmlLoader.FromEmbeddedResource(Assembly.GetAssembly(typeof (XmlDataAdapter)),
                "PhuLiNet.Plugin.Application.DataAdapter.PluginApp.xsd");
            XmlSchema menuItems = null;

            using (var xnr = new XmlNodeReader(xmlSchemaDoc))
            {
                menuItems = XmlSchema.Read(xnr, SchemaValidationEventHandler);
            }

            return menuItems;
        }
    }
}