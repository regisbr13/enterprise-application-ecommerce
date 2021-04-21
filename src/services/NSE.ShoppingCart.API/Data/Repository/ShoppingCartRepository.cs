using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.ShoppingCart.API.Interfaces;
using NSE.ShoppingCart.API.Models;
using System;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Data.Repository
{
    public class ShoppingCartRepository : Repository<CustomerShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ShoppingCartContext context) : base(context)
        {
        }

        public async Task<CustomerShoppingCart> GetShoppingCartByCustomerIdAsync(Guid id)
            => await _currentSet.AsNoTracking().Include(s => s.Items).FirstOrDefaultAsync(s => s.CustomerId == id);

        public new async Task<CustomerShoppingCart> GetByIdAsync(Guid id)
            => await _currentSet.AsNoTracking().Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
    }
}