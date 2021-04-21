using Microsoft.EntityFrameworkCore;
using NSE.Core.Data.Interfaces;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Core.Data
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext _context;
        protected readonly DbSet<T> _currentSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _currentSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _currentSet.AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
            => await _currentSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<bool> InsertAsync(T obj)
        {
            _currentSet.Add(obj);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(T obj)
        {
            _currentSet.Update(obj);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T obj)
        {
            _currentSet.Remove(obj);
            return await SaveChangesAsync();
        }

        protected async Task<bool> SaveChangesAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}