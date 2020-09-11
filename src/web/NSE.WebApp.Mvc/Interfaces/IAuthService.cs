using NSE.WebApp.Mvc.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoggedViewModel> Login(UserLoginViewModel user);

        Task<UserLoggedViewModel> Register(UserRegisterViewModel user);
    }
}