using NSE.Catalog.API.Interfaces;
using NSE.Catalog.API.Models;
using NSE.Core.Data;

namespace NSE.Catalog.API.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context) : base(context)
        {
        }
    }
}