using NSE.WebApp.Mvc.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Interfaces
{
    public interface IAuthService
    {
        Task<UserLogged> Login(UserLogin user);

        Task<UserLogged> Register(UserRegister user);
    }
}