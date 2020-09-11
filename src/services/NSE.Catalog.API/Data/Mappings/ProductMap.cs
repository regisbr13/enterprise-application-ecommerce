using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Image).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Value).IsRequired().HasColumnType("decimal");
            builder.ToTable("Products");
        }
    }
}