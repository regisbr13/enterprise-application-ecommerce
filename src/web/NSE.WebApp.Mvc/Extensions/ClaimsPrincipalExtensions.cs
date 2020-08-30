using System.Security.Claims;

namespace NSE.WebApp.Mvc.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claims) => claims?.FindFirst("sub")?.Value;

        public static string GetUserEmail(this ClaimsPrincipal claims) => claims?.FindFirst("email")?.Value;

        public static string GetUserToken(this ClaimsPrincipal claims) => claims?.FindFirst("JWT")?.Value;
    }
}