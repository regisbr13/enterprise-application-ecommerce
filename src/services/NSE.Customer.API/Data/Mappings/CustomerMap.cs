using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Core.DomainObjects.ValueObjects;
using NSE.Customers.API.Models;

namespace NSE.Customers.API.Data.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

            builder.OwnsOne(c => c.Cpf, p =>
                p.Property(c => c.Number).IsRequired().HasMaxLength(Cpf.CpfMaxLength).HasColumnName("Cpf"));
            builder.OwnsOne(c => c.Email, p =>
                p.Property(c => c.Address).IsRequired().HasMaxLength(Email.MaxLength).HasColumnName("Email"));

            builder.HasOne(c => c.Address).WithOne(a => a.Customer);
        }
    }
}