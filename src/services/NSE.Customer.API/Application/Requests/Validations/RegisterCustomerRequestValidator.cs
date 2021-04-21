using FluentValidation;
using NSE.Core.DomainObjects.ValueObjects;
using System;

namespace NSE.Customers.API.Application.Requests.Validations
{
    public class RegisterCustomerRequestValidator : AbstractValidator<RegisterCustomerRequest>
    {
        public RegisterCustomerRequestValidator()
        {
            RuleFor(r => r.Id).NotEqual(Guid.Empty).WithMessage("Id do cliente inválido");
            RuleFor(r => r.Name).NotEmpty().WithMessage("Nome não informado");
            RuleFor(r => r.Cpf).Must(Cpf.IsValid).WithMessage("Cpf informado inválido");
            RuleFor(r => r.Email).Must(Email.IsValid).WithMessage("Email informado inválido");
        }
    }
}