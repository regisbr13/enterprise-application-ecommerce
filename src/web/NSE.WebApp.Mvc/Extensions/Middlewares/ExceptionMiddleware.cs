using Microsoft.AspNetCore.Http;
using NSE.WebApp.Mvc.Extensions.Exceptions;
using System.Net;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Extensions.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHttpResponseException ex)
            {
                HandleRequestException(httpContext, ex);
            }
        }

        private void HandleRequestException(HttpContext httpContext, CustomHttpResponseException exception)
        {
            httpContext.Response.StatusCode = (int)exception.StatusCode;

            if (exception.StatusCode == HttpStatusCode.Unauthorized)
                httpContext.Response.Redirect($"/entrar?ReturnUrl={httpContext.Request.Path}");
        }
    }
}