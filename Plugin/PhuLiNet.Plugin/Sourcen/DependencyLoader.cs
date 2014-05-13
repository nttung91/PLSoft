using System.Diagnostics;
using System.IO;
using System.Xml;
using Manor.Plugin;
using PhuLiNet.Plugin.Application;

namespace PhuLiNet.Plugin
{
    internal class DependencyLoader : IDependencyLoader
    {
        private string _startupPath;
        private string _appConfigFile;
        private Dependencies _dependencies;

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

        public Dependencies DependencyList
        {
            get { return _dependencies; }
        }

        internal DependencyLoader()
        {
        }

        private XmlDocument LoadConfig()
        {
            string appConfigPath = Path.Combine(_startupPath, _appConfigFile);
            Debug.Assert(File.Exists(appConfigPath), string.Format("File not found [{0}]", appConfigPath));

            if (!File.Exists(appConfigPath))
            {
                throw new PluginHostException(string.Format("File not found [{0}]", appConfigPath));
            }

            var appConfig = new XmlDocument();
            appConfig.Load(appConfigPath);
            return appConfig;
        }

        internal void Run()
        {
            _dependencies = DependencyFactory.GetInstance(LoadConfig());
        }
    }
}