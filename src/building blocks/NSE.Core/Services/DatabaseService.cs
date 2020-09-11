using Microsoft.EntityFrameworkCore;

namespace NSE.Core.Services
{
    public static class DatabaseService
    {
        public static void SetUpDataBase(DbContext context)
            => context.Database.Migrate();
    }
}