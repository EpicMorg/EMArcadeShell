using System;
using System.Runtime.Serialization;

namespace minifmod4net
{
    public class MiniFmodException : Exception
    {
        public MiniFmodException()
        {
        }

        public MiniFmodException(string message) : base(message)
        {
        }

        public MiniFmodException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MiniFmodException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}