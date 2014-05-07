using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Occurs when an object state is not valid for an operation
    /// </summary>
    [Serializable]
    public class InvalidStateException : PhuLiException
    {
        public string ExpectedState { get; set; }
        public string ExistingState { get; set; }

        public InvalidStateException()
        {
        }

        public InvalidStateException(string message) : base(message)
        {
        }

        public InvalidStateException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InvalidStateException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}