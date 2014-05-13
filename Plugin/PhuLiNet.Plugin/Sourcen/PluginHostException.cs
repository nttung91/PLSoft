using System;
using System.Runtime.Serialization;
using Technical.Utilities.Exceptions;

namespace PhuLiNet.Plugin
{
    [Serializable]
    public class PluginHostException : PhuLiException
    {
        public PluginHostException()
        {
        }

        public PluginHostException(string message) : base(message)
        {
        }

        public PluginHostException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PluginHostException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}