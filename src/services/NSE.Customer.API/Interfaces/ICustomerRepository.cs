using NSE.Core.Data.Interfaces;
using NSE.Customers.API.Models;
using System.Threading.Tasks;

namespace NSE.Customers.API.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> IsCpfAlreadyRegisteredAsync(string cpf);
    }
}