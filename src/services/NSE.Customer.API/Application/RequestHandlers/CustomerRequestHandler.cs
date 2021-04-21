using FluentValidation.Results;
using MediatR;
using NSE.Core.MediatR;
using NSE.Customers.API.Application.Requests;
using NSE.Customers.API.Interfaces;
using NSE.Customers.API.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Customers.API.Application.RequestHandlers
{
    public class CustomerRequestHandler : MainRequestHandler, IRequestHandler<RegisterCustomerRequest, RequestResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRequestHandler(ICustomerRepository customerRepository)
            => _customerRepository = customerRepository;

        public async Task<RequestResult> Handle(RegisterCustomerRequest request, CancellationToken cancellationToken)
        {
            if (await _customerRepository.IsCpfAlreadyRegisteredAsync(request.Cpf))
                return ErrorResult("Cpf já registrado.");

            var customer = new Customer(request.Id, request.Name, request.Email, request.Cpf);
            return CommitResult(await _customerRepository.InsertAsync(customer));
        }
    }
}