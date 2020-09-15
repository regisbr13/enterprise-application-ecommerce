using Microsoft.AspNetCore.Http;
using NSE.WebApp.Mvc.Extensions.Exceptions;
using Polly.CircuitBreaker;
using Refit;
using System;
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
                HandleRequestException(httpContext, ex.StatusCode);
            }
            catch (ApiException ex)
            {
                HandleRequestException(httpContext, ex.StatusCode);
            }
            catch (BrokenCircuitException)
            {
                HandleCircuitBreakException(httpContext);
            }
        }

        private void HandleRequestException(HttpContext httpContext, HttpStatusCode statusCode)
        {
            httpContext.Response.StatusCode = (int)statusCode;

            if (statusCode == HttpStatusCode.Unauthorized)
                httpContext.Response.Redirect($"/entrar?ReturnUrl={httpContext.Request.Path}");
        }

        private void HandleCircuitBreakException(HttpContext httpContext)
        {
            httpContext.Response.Redirect("/sistema-indisponivel");
        }
    }
}