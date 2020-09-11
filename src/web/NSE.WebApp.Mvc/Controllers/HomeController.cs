using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;

namespace NSE.WebApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("erro/{errorCode:length(3,3)}")]
        public IActionResult Error(int errorCode)
        {
            var errorViewModel = new ErrorViewModel() { Code = errorCode };

            switch (errorCode)
            {
                case 403:
                    errorViewModel.Title = "Acesso negado!";
                    errorViewModel.Message = "Você não tem permissão para fazer isso.";
                    break;

                case 404:
                    errorViewModel.Title = "Página não encontrada!";
                    errorViewModel.Message = "A Página que você tentou acessar não existe.";
                    break;

                default:
                    errorViewModel.Title = "Ocorreu um erro!";
                    errorViewModel.Message = "Não foi possível completar a sua solicitação.";
                    break;
            }

            return View("Error", errorViewModel);
        }
    }
}