using System.Diagnostics;
using System.Xml;
using PhuLiNet.Plugin.Application.DataAdapter;

namespace PhuLiNet.Plugin.Application
{
    internal static class DependencyFactory
    {
        internal static Dependencies GetInstance(XmlDocument appConfig)
        {
            Debug.Assert(appConfig != null, "AppConfig is null");

            Dependencies _dependencies = null;
            IAppDataAdapter dataAdapter = new XmlDataAdapter(appConfig);
            dataAdapter.Validate();

            _dependencies = dataAdapter.LoadDependencies();

            return _dependencies;
        }
    }
}