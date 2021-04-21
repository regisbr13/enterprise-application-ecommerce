using Microsoft.AspNetCore.Mvc;
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
            if (!ProductAndQuantityIsValid(product, item.Quantity))
                return View(nameof(Index), await _shoppingCartService.Get());

            item.Name = product.Name;
            item.Image = product.Image;
            item.Value = product.Value;
            var response = await _shoppingCartService.Post(item);
            if (HasResponseErrors(response)) return View(nameof(Index), await _shoppingCartService.Get());

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("atualizar-item")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateItem(Guid productId, int quantity)
        {
            var product = await _catalogService.GetById(productId);
            if (!ProductAndQuantityIsValid(product, quantity))
                return View(nameof(Index), await _shoppingCartService.Get());

            var item = new ItemShoppingCartViewModel { ProductId = productId, Quantity = quantity };
            var response = await _shoppingCartService.Put(productId, item);
            if (HasResponseErrors(response)) return View(nameof(Index), await _shoppingCartService.Get());

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
                NotifyError($"O produto com o id {productId} não foi encontrado");
                return View(nameof(Index), await _shoppingCartService.Get());
            }

            var response = await _shoppingCartService.Delete(productId);
            if (HasResponseErrors(response)) return View(nameof(Index), await _shoppingCartService.Get());

            return RedirectToAction(nameof(Index));
        }

        private bool ProductAndQuantityIsValid(ProductViewModel product, int quantity)
        {
            if (product is null)
            {
                NotifyError($"O produto não foi encontrado");
                return false;
            }

            if (quantity > product.StockQuantity)
            {
                NotifyError($"O produto {product.Name} possui apenas {product.StockQuantity} unidades em estoque");
                return false;
            }

            return true;
        }
    }
}