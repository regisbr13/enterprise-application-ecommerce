using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Customers.API.Models;

namespace NSE.Customers.API.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Street).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Number).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Cep).IsRequired().HasMaxLength(20);
            builder.Property(a => a.City).IsRequired().HasMaxLength(100);
            builder.Property(a => a.District).IsRequired().HasMaxLength(100);
            builder.Property(a => a.State).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Complement).IsRequired().HasMaxLength(150);
        }
    }
}