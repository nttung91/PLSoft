using System;
using System.Runtime.Serialization;
using Manor.Utilities.Exceptions;

namespace Manor.ConnectionStrings
{
    [Serializable]
    public class ConnectionStringRegistryException : ManorException
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