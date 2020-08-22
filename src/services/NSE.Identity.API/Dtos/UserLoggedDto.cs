using System.Collections.Generic;

namespace NSE.Identity.API.Dtos
{
    public class UserLoggedDto
    {
        public string Id { get; }
        public string Email { get; }
        public string Token { get; }
        public IEnumerable<UserClaimDto> Claims { get; }

        public UserLoggedDto(string id, string email, string token, IEnumerable<UserClaimDto> claims)
        {
            Id = id;
            Email = email;
            Token = token;
            Claims = claims;
        }
    }
}