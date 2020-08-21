using Microsoft.EntityFrameworkCore;
using NSE.Identity.API.Data;

namespace NSE.Identity.API.Extensions
{
    public class DatabaseService
    {
        private readonly AppDbContext _context;

        public DatabaseService(AppDbContext context) => _context = context;

        public void CreateDatabase()
        {
            if (!_context.DatabaseExists()) _context.Database.Migrate();
        }
    }
}