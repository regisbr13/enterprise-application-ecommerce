using Microsoft.EntityFrameworkCore;

namespace NSE.Core.Extensions
{
    public static class CheckDatabase
    {
        public static bool DatabaseExists(this DbContext context) => (context.Database.EnsureCreated());
    }
}