using System.Collections.Generic;

namespace NSE.WebApp.Mvc.Models
{
    public class UserLogged
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public IEnumerable<UserClaim> Claims { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}