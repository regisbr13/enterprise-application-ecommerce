using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.ShoppingCart.API.Models;

namespace NSE.ShoppingCart.API.Data.Mappings
{
    public class CustomerShoppingCartMap : IEntityTypeConfiguration<CustomerShoppingCart>
    {
        public void Configure(EntityTypeBuilder<CustomerShoppingCart> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TotalValue).IsRequired().HasColumnType("decimal");
            builder.HasIndex(p => p.CustomerId).HasDatabaseName("IDX_Customer");
            builder.HasMany(p => p.Items).WithOne(c => c.CustomerShoppingCart).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("ShoppingCarts");
        }
    }
}