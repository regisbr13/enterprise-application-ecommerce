using System;
using System.Net;
using System.Runtime.Serialization;

namespace NSE.WebApp.Mvc.Extensions.Exceptions
{
    [Serializable]
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public CustomHttpResponseException(HttpStatusCode statusCode) => StatusCode = statusCode;

        public CustomHttpResponseException()
        {
        }

        public CustomHttpResponseException(string message) : base(message)
        {
        }

        public CustomHttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomHttpResponseException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}