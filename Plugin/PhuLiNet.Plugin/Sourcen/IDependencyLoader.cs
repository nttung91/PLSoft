using PhuLiNet.Plugin.Application;

namespace PhuLiNet.Plugin
{
    internal interface IDependencyLoader
    {
        Dependencies DependencyList { get; }
    }
}