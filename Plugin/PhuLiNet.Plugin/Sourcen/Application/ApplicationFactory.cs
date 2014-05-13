using System.Diagnostics;
using System.Xml;
using Manor.Plugin.Application;
using PhuLiNet.Plugin.Application.DataAdapter;

namespace PhuLiNet.Plugin.Application
{
    internal static class ApplicationFactory
    {
        internal static IApplicationInfo GetInstance(XmlDocument appConfig)
        {
            Debug.Assert(appConfig != null, "AppConfig is null");

            IApplicationInfo _application;

            IAppDataAdapter dataAdapter = new XmlDataAdapter(appConfig);
            dataAdapter.Validate();

            _application = dataAdapter.Load();

            return _application;
        }
    }
}