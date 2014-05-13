using System;
using Manor.Plugin.Contracts;
using PhuLiNet.Plugin.Contracts;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace PhuLiNet.Plugin.Manager
{
    public class PluginConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            var interfaceType = typeof (IPlugin);

            if (!type.Name.StartsWith("Plugin"))
            {
                return;
            }
            if (type == typeof (PluginBase))
            {
                return;
            }

            registry.For(interfaceType).Use(type);
        }
    }
}