using FluentValidation;
using NSE.ShoppingCart.API.Models;
using System;

namespace NSE.ShoppingCart.API.Application.Requests.Validations
{
    public class AddItemShoppingCartRequestValidator : AbstractValidator<AddItemShoppingCartRequest>
    {
        public static string InvalidProductIdError => "Id do produto inválido";
        public static string InvalidProductNameError => "O nome do produto precisa ser informado";
        public static string InvalidMinQuantityError => $"A quantidade mínima é de {ItemShoppingCart.MIN_QUANTITY} unidade";
        public static string InvalidMaxQuantityError => $"A quantidade máxima é de {ItemShoppingCart.MAX_QUANTITY} unidades";
        public static string InvalidValueError => "O valor do item não pode ser 0";

        public AddItemShoppingCartRequestValidator()
        {
            RuleFor(i => i.ProductId).NotEqual(Guid.Empty).WithMessage(InvalidProductIdError);
            RuleFor(i => i.Name).NotEmpty().WithMessage(InvalidProductNameError);
            RuleFor(i => i.Quantity).GreaterThanOrEqualTo(ItemShoppingCart.MIN_QUANTITY).WithMessage(InvalidMinQuantityError);
            RuleFor(i => i.Quantity).LessThanOrEqualTo(ItemShoppingCart.MAX_QUANTITY).WithMessage(InvalidMaxQuantityError);
            RuleFor(i => i.Value).GreaterThan(0).WithMessage(InvalidValueError);
        }
    }
}