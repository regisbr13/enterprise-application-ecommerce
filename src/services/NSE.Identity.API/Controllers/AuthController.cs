using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NSE.Core.DomainObjects.Exceptions;
using NSE.Core.Messages;
using NSE.Core.Messages.Events;
using NSE.Identity.API.Dtos;
using NSE.MessageBus;
using NSE.WebApiCore.Authentication;
using NSE.WebApiCore.Controllers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Identity.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenSettings _tokenSettings;
        private readonly IMessageBus _bus;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, TokenSettings tokenSettings, IMessageBus bus)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenSettings = tokenSettings;
            _bus = bus;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserLoggedDto>> Register(UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelErrors();
                return CustomResponse();
            }

            var user = new IdentityUser
            {
                UserName = userRegisterDto.Email,
                Email = userRegisterDto.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);
            if (result.Succeeded)
            {
                var eventResult = await SendRegisterCustomerEvent(userRegisterDto);
                if (!eventResult.Succeeded)
                {
                    await _userManager.DeleteAsync(user);
                    return CustomResponse(eventResult.ValidationResult);
                }

                return CustomResponse(await GetUserLogged(user.Email));
            }

            foreach (var error in result.Errors) NotifyError(error.Description);
            return CustomResponse();
        }

        [HttpPost("entrar")]
        public async Task<ActionResult<UserLoggedDto>> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelErrors();
                return CustomResponse();
            }

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Email, userLoginDto.Password, false, false);
            if (result.Succeeded) return CustomResponse(await GetUserLogged(userLoginDto.Email));

            NotifyError("Usuário ou senha inválidos");
            return CustomResponse();
        }

        private async Task<UserLoggedDto> GetUserLogged(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await GetClaims(user);
            var token = GetToken(claims);

            return new UserLoggedDto(user.Id, user.Email, token, claims.Claims.Select(c => new UserClaimDto(c.Type, c.Value)));
        }

        private async Task<ClaimsIdentity> GetClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            return new ClaimsIdentity(claims);
        }

        private string GetToken(ClaimsIdentity claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_tokenSettings.Secret);

            return tokenHandler.CreateEncodedJwt(new SecurityTokenDescriptor
            {
                Issuer = _tokenSettings.Issuer,
                Audience = _tokenSettings.ValidUri,
                Expires = DateTime.UtcNow.AddHours(_tokenSettings.ExpirationTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),
                Subject = claims
            });
        }

        private async Task<ResponseMessage> SendRegisterCustomerEvent(UserRegisterDto userDto)
        {
            var user = await _userManager.FindByEmailAsync(userDto.Email);
            var customerRegistredEvent = new CustomerRegisteredEvent(Guid.Parse(user.Id), userDto.Name, userDto.Email, userDto.Cpf);

            try
            {
                return await _bus.RequestAsync<CustomerRegisteredEvent, ResponseMessage>(customerRegistredEvent);
            }
            catch (Exception ex)
            {
                await _userManager.DeleteAsync(user);
                throw new BusConnectionException(ex.Message);
            }
        }
    }
}