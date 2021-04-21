using FluentValidation.Results;
using MediatR;
using NSE.Core.MediatR;
using NSE.Core.Utils;
using NSE.WebApiCore.Validations;
using System;

namespace NSE.Customers.API.Application.Requests
{
    public class RegisterCustomerRequest : IRequest<RequestResult>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegisterCustomerRequest(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf.OnlyNumbers(cpf);
        }
    }
}