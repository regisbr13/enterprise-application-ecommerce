using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}