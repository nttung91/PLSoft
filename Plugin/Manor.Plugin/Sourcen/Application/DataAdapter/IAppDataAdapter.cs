using Manor.Plugin.Application;

namespace PhuLiNet.Plugin.Application.DataAdapter
{
    internal interface IAppDataAdapter
    {
        IApplicationInfo Load();
        Configurations LoadConfigs();
        Dependencies LoadDependencies();
        void Validate();
    }
}