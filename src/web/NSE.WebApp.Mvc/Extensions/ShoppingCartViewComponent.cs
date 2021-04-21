using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Extensions
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IShoppingCartService _service;

        public ShoppingCartViewComponent(IShoppingCartService service) => _service = service;

        public async Task<IViewComponentResult> InvokeAsync() => View(await _service.Get() ?? new ShoppingCartViewModel());
    }
}