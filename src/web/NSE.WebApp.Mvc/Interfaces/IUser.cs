using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebApp.Mvc.Interfaces
{
    public interface IUser
    {
        public string GetId();

        public string GetName();

        public string GetEmail();

        public string GetToken();

        public bool IsAuthenticated();

        public bool IsInRole(string role);

        public IEnumerable<Claim> GetClaims();
    }
}