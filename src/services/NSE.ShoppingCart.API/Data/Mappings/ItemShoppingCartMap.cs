using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.ShoppingCart.API.Models;

namespace NSE.ShoppingCart.API.Data.Mappings
{
    public class ItemShoppingCartMap : IEntityTypeConfiguration<ItemShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ItemShoppingCart> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(150);
            builder.Property(i => i.Quantity);
            builder.Property(i => i.Image).IsRequired().HasMaxLength(150);
            builder.Property(i => i.Value).IsRequired().HasColumnType("decimal");
            builder.HasOne(i => i.CustomerShoppingCart).WithMany(c => c.Items).HasForeignKey(i => i.CustomerShoppingCartId);
            builder.ToTable("ShoppingCartItems");
        }
    }
}