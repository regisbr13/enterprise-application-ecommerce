using Microsoft.EntityFrameworkCore;
using NSE.Core.Data.Interfaces;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Core.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext _context;
        private readonly DbSet<T> _currentSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _currentSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
            => await _currentSet.AsNoTracking().ToListAsync();

        public async Task<T> GetById(Guid id)
            => await _currentSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<int> SaveChanges()
            => await _context.SaveChangesAsync();
    }
}