using System;
using System.Runtime.Serialization;

namespace PhuLiNet.Business.Common.CslaListHelpers
{
    [Serializable]
    internal class FilterPropertyException : ApplicationException
    {
        public FilterPropertyException()
        {
        }

        public FilterPropertyException(string message) : base(message)
        {
        }

        public FilterPropertyException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FilterPropertyException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}