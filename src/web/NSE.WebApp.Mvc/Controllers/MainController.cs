using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;
using System.Linq;

namespace NSE.WebApp.Mvc.Controllers
{
    public abstract class MainController : Controller
    {
        protected bool HasResponseErrors(ErrorResponseViewModel response)
        {
            if (response != null && response.Errors.Any())
            {
                response.Errors.ForEach(e => ModelState.AddModelError(string.Empty, e));
                return true;
            }

            return false;
        }
    }
}