using NSE.Core.Data.Interfaces;
using NSE.ShoppingCart.API.Models;
using System;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Interfaces
{
    public interface IShoppingCartRepository : IRepository<CustomerShoppingCart>
    {
        Task<CustomerShoppingCart> GetShoppingCartByCustomerIdAsync(Guid id);

        new Task<CustomerShoppingCart> GetByIdAsync(Guid id);
    }
}