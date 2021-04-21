using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebApiCore.User
{
    public interface IAspNetUser
    {
        public string GetId();

        public string GetName();

        public string GetEmail();

        public string GetToken();

        public HttpContext GetHttpContext();

        public bool IsAuthenticated();

        public bool IsInRole(string role);

        public IEnumerable<Claim> GetClaims();
    }
}