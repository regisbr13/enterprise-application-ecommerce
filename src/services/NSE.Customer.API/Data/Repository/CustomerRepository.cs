using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Customers.API.Interfaces;
using NSE.Customers.API.Models;
using System.Threading.Tasks;

namespace NSE.Customers.API.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersContext context) : base(context)
        {
        }

        public async Task<bool> IsCpfAlreadyRegisteredAsync(string cpf)
            => await _currentSet.AsNoTracking().AnyAsync(c => c.Cpf.Number == cpf);
    }
}