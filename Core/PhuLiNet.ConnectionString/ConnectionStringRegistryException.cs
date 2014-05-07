using System;
using System.Runtime.Serialization;
using Technical.Utilities.Exceptions;

namespace Manor.ConnectionStrings
{
    [Serializable]
    public class ConnectionStringRegistryException : PhuLiException
    {
        public ConnectionStringRegistryException()
        {
        }

        public ConnectionStringRegistryException(string message) : base(message)
        {
        }

        public ConnectionStringRegistryException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConnectionStringRegistryException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}