using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Core.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<bool> InsertAsync(T obj);

        Task<bool> UpdateAsync(T obj);

        Task<bool> DeleteAsync(T obj);
    }
}