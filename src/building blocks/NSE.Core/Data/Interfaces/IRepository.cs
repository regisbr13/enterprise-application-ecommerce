using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Core.Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(Guid id);

        Task<int> SaveChanges();
    }
}