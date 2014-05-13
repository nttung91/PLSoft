using System.Diagnostics;
using System.Xml;
using PhuLiNet.Plugin.Application.DataAdapter;

namespace PhuLiNet.Plugin.Application
{
    internal static class ConfigurationFactory
    {
        internal static Configurations GetInstance(XmlDocument appConfig)
        {
            Debug.Assert(appConfig != null, "AppConfig is null");

            IAppDataAdapter dataAdapter = new XmlDataAdapter(appConfig);
            dataAdapter.Validate();

            Configurations configurations = dataAdapter.LoadConfigs();

            return configurations;
        }

        internal static Configurations GetInstance(string menuRootNode)
        {
            var configurations = new Configurations();
            var config = new Configuration {Default = true, Id = "Dynamic"};
            config.MenuConfigs.Add(new MenuConfigByDb
            {
                Type = "main",
                ConfigString = string.Format("MenuRootNode={0}", menuRootNode)
            });
            configurations.Add(config);

            return configurations;
        }
    }
}