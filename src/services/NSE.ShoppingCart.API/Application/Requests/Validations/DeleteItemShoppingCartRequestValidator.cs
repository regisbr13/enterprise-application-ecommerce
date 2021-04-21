using FluentValidation;
using System;

namespace NSE.ShoppingCart.API.Application.Requests.Validations
{
    public class DeleteItemShoppingCartRequestValidator : AbstractValidator<DeleteItemShoppingCartRequest>
    {
        public static string InvalidProductIdError => "Id do produto inválido";

        public DeleteItemShoppingCartRequestValidator()
            => RuleFor(i => i.ProductId).NotEqual(Guid.Empty).WithMessage(InvalidProductIdError);
    }
}