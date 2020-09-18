using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Core.DomainObjects;

namespace NSE.Core.Extensions
{
    public static class EntityTypeBuilder
    {
        public static void ApplyDefaultConfig<T>(this EntityTypeBuilder<T> builder)
            where T : Entity => builder.HasKey(i => i.Id);
    }
}