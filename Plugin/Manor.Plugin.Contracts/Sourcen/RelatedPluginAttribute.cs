using System;

namespace PhuLiNet.Plugin.Contracts
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RelatedPluginAttribute : Attribute
    {
        public Type PluginType { get; private set; }

        /// <summary>
        /// Constructs a new instance of <c>RelatedPluginAttribute</c>.
        /// </summary>
        /// <param name="pluginType">must be of type <c>IPlugin</c> (see section Exceptions)</param>
        /// <exception cref="ArgumentException">if passed type is not e IPlugin type</exception>
        public RelatedPluginAttribute(Type pluginType)
        {
            if (!typeof (IPlugin).IsAssignableFrom(pluginType))
                throw new ArgumentException("related plugin type must be of type IPlugin.");
            PluginType = pluginType;
        }

        public override string ToString()
        {
            return string.Format("Full name of realted plugin: {0}", PluginType.FullName);
        }
    }
}