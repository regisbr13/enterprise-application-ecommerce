using Microsoft.AspNetCore.Http;
using NSE.WebApp.Mvc.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebApp.Mvc.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor context) => _accessor = context;

        public string GetId() => _accessor.HttpContext.User.GetUserId();

        public string GetName() => _accessor.HttpContext.User.Identity.Name;

        public string GetEmail() => _accessor.HttpContext.User.GetUserEmail();

        public string GetToken() => _accessor.HttpContext.User.GetUserToken();

        public bool IsAuthenticated() => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public bool IsInRole(string role) => _accessor.HttpContext.User.IsInRole(role);

        public IEnumerable<Claim> GetClaims() => _accessor.HttpContext.User.Claims;
    }
}