using System;
using System.Runtime.Serialization;

namespace Technical.Utilities.Exceptions
{
    /// <summary>
    /// Occurs when we test exception handling and logging
    /// </summary>
    [Serializable]
    internal class TestException : PhuLiException
    {
        public TestException()
        {
        }

        public TestException(string message) : base(message)
        {
        }

        public TestException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TestException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public static void Throw()
        {
            throw new TestException("Test exception handling and logging");
        }
    }
}