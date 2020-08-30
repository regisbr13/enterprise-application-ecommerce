using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Services
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<UserLogged> Login(UserLogin user)
        {
            var content = GetContent(user);
            var response = await _httpClient.PostAsync("/api/identidade/entrar", content);
            if (HasResponseErrors(response))
            {
                var responseErrors = await DeserializeObjectResponse<ErrorResponse>(response);
                return new UserLogged { ErrorResponse = responseErrors };
            }

            var userLogged = await DeserializeObjectResponse<UserLogged>(response);
            return userLogged;
        }

        public async Task<UserLogged> Register(UserRegister user)
        {
            var content = GetContent(user);
            var response = await _httpClient.PostAsync("/api/identidade/registrar", content);
            if (HasResponseErrors(response))
            {
                var responseErrors = await DeserializeObjectResponse<ErrorResponse>(response);
                return new UserLogged { ErrorResponse = responseErrors };
            }

            var userLogged = await DeserializeObjectResponse<UserLogged>(response);
            return userLogged;
        }
    }
}