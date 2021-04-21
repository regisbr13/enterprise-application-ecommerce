using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    public class IdentityController : MainController
    {
        private readonly IAuthService _service;

        public IdentityController(IAuthService service) => _service = service;

        [HttpGet]
        [Route("registrar")]
        public IActionResult Register() => View();

        [HttpPost]
        [Route("registrar")]
        public async Task<IActionResult> Register(UserRegisterViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var response = await _service.Register(user);
            if (HasResponseErrors(response.ErrorResponse)) return View(user);

            await MakeLogin(response);

            return RedirectToAction("Index", "Catalog");
        }

        [HttpGet]
        [Route("entrar")]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("entrar")]
        public async Task<IActionResult> Login(UserLoginViewModel user, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(user);

            var response = await _service.Login(user);
            if (HasResponseErrors(response.ErrorResponse)) return View(user);

            await MakeLogin(response);

            if (returnUrl != null) return LocalRedirect(returnUrl);

            return RedirectToAction("Index", "Catalog");
        }

        [HttpGet]
        [Route("sair")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        private async Task MakeLogin(UserLoggedViewModel user)
        {
            var token = GetFormattedToken(user.Token);
            var claims = new List<Claim>
            {
                new Claim("JWT", user.Token)
            };
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }

        private JwtSecurityToken GetFormattedToken(string token) => new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
    }
}