using System.Collections.Generic;

namespace NSE.WebApp.Mvc.Models
{
    public class UserLoggedViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public IEnumerable<UserClaimViewModel> Claims { get; set; }

        public ErrorResponseViewModel ErrorResponse { get; set; }
    }
}