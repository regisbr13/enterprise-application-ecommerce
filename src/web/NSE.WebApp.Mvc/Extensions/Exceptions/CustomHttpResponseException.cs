using System;
using System.Net;

namespace NSE.WebApp.Mvc.Extensions.Exceptions
{
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public CustomHttpResponseException(HttpStatusCode statusCode) => StatusCode = statusCode;
    }
}