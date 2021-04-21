using NSE.WebApp.Mvc.Models;
using Refit;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Interfaces
{
    public interface IShoppingCartService
    {
        [Get("/api/carrinho/")]
        Task<ShoppingCartViewModel> Get();

        [Post("/api/carrinho/")]
        Task<ErrorResponseViewModel> Post(ItemShoppingCartViewModel item);

        [Put("/api/carrinho/{productId}")]
        Task<ErrorResponseViewModel> Put(Guid productId, ItemShoppingCartViewModel item);

        [Delete("/api/carrinho/{productId}")]
        Task<ErrorResponseViewModel> Delete(Guid productId);
    }
}