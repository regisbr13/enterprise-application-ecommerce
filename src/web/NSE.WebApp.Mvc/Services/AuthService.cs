﻿using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Extensions
{
    public class AuthService : Service, IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<UserLoggedViewModel> Login(UserLoginViewModel user)
        {
            var content = GetContent(user);
            var response = await _httpClient.PostAsync("/api/identidade/entrar", content);
            if (HasResponseErrors(response))
            {
                var responseErrors = await DeserializeObjectResponse<ErrorResponseViewModel>(response);
                return new UserLoggedViewModel { ErrorResponse = responseErrors };
            }

            var userLogged = await DeserializeObjectResponse<UserLoggedViewModel>(response);
            return userLogged;
        }

        public async Task<UserLoggedViewModel> Register(UserRegisterViewModel user)
        {
            var content = GetContent(user);
            var response = await _httpClient.PostAsync("/api/identidade/registrar", content);
            if (HasResponseErrors(response))
            {
                var responseErrors = await DeserializeObjectResponse<ErrorResponseViewModel>(response);
                return new UserLoggedViewModel { ErrorResponse = responseErrors };
            }

            var userLogged = await DeserializeObjectResponse<UserLoggedViewModel>(response);
            return userLogged;
        }
    }
}