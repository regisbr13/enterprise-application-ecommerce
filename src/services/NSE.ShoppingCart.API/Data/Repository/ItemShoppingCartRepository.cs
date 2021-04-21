using NSE.Core.Data;
using NSE.ShoppingCart.API.Interfaces;
using NSE.ShoppingCart.API.Models;

namespace NSE.ShoppingCart.API.Data.Repository
{
    public class ItemShoppingCartRepository : Repository<ItemShoppingCart>, IItemShoppingCartRepository
    {
        public ItemShoppingCartRepository(ShoppingCartContext context) : base(context)
        {
        }
    }
}