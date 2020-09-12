using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace NSE.WebApiCore.Authentication
{
    public static class CustomAuthorization
    {
        public static bool ClaimValidate(HttpContext context, string claimType, string claimValue)
            => context.User.Identity.IsAuthenticated
                    && context.User.Claims.Any(x => x.Type == claimType && x.Value.Contains(claimValue));
    }

    public class ClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public ClaimFilter(Claim claim)
            => _claim = claim;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new UnauthorizedResult();

            if (!CustomAuthorization.ClaimValidate(context.HttpContext, _claim.Type, _claim.Value))
                context.Result = new ForbidResult();
        }
    }

    public sealed class ClaimAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimFilter))
            => Arguments = new object[] { new Claim(claimType, claimValue) };
    }
}