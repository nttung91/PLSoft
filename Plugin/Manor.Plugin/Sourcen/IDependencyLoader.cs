using Manor.Plugin.Application;
using PhuLiNet.Plugin.Application;

namespace Manor.Plugin
{
    internal interface IDependencyLoader
    {
        Dependencies DependencyList { get; }
    }
}