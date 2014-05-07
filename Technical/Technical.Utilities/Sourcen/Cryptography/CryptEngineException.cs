using System;

namespace Technical.Utilities.Cryptography
{   
    [Serializable]
    public class CryptEngineException : ApplicationException
    {
        public CryptEngineException() { }
        public CryptEngineException(string message) : base(message) { }
        public CryptEngineException(string message, Exception inner) : base(message, inner) { }
        protected CryptEngineException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }   
}
