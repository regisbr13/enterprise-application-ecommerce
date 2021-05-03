using Microsoft.AspNetCore.Mvc;
using NSE.Core.Utils;
using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    [Route("carrinho")]
    public class ShoppingCartController : MainController
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICatalogService _catalogService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, ICatalogService catalogService)
        {
            _shoppingCartService = shoppingCartService;
            _catalogService = catalogService;
        }

        public async Task<ActionResult> Index() => View(await _shoppingCartService.Get());

        [HttpPost]
        [Route("adicionar-item")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(ItemShoppingCartViewModel item)
        {
            var product = await _catalogService.GetById(item.ProductId);
            if (!ProductIsValid(product, item.ProductId))
                return View(nameof(Index), await _shoppingCartService.Get());

            if (!ProductQuantityIsValid(product, item.Quantity))
                return View(nameof(Index), await _shoppingCartService.Get());

            item.Name = product.Name;
            item.Image = product.Image;
            item.Value = product.Value;
            var response = await _shoppingCartService.Post(item);
            if (HasResponseErrors(response))
                return View(nameof(Index), await _shoppingCartService.Get());

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("atualizar-item")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateItem(Guid productId, int quantity)
        {
            var product = await _catalogService.GetById(productId);
            if (!ProductIsValid(product, productId))
                return View(nameof(Index), await _shoppingCartService.Get());

            if (!ProductQuantityIsValid(product, quantity))
                return View(nameof(Index), await _shoppingCartService.Get());

            var item = new ItemShoppingCartViewModel { ProductId = productId, Quantity = quantity };
            var response = await _shoppingCartService.Put(productId, item);
            if (HasResponseErrors(response))
                return View(nameof(Index), await _shoppingCartService.Get());

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("deletar-item")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteItem(Guid productId)
        {
            var product = await _catalogService.GetById(productId);
            if (product is null)
            {
                NotifyError(Resources.ProductNotFound(productId));
                return View(nameof(Index), await _shoppingCartService.Get());
            }

            var response = await _shoppingCartService.Delete(productId);
            if (HasResponseErrors(response)) 
                return View(nameof(Index), await _shoppingCartService.Get());

            return RedirectToAction(nameof(Index));
        }

        private bool ProductIsValid(ProductViewModel product, Guid productId)
        {
            if (product is null)
            {
                NotifyError(Resources.ProductNotFound(productId));
                return false;
            }

            return true;
        }

        private bool ProductQuantityIsValid(ProductViewModel product, int quantity)
        {
            if (quantity > product.StockQuantity)
            {
                NotifyError(Resources.ProductInvalidQuantity(product.Name, quantity));
                return false;
            }

            return true;
        }
    }
}