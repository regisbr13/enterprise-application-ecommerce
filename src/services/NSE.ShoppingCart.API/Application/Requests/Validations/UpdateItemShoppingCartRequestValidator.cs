using FluentValidation;
using NSE.ShoppingCart.API.Models;
using System;

namespace NSE.ShoppingCart.API.Application.Requests.Validations
{
    public class UpdateItemShoppingCartRequestValidator : AbstractValidator<UpdateItemShoppingCartRequest>
    {
        public static string InvalidProductIdError => "Id do produto inválido";
        public static string InvalidMinQuantityError => $"A quantidade mínima é de {ItemShoppingCart.MIN_QUANTITY} unidade";
        public static string InvalidMaxQuantityError => $"A quantidade máxima é de {ItemShoppingCart.MAX_QUANTITY} unidades";

        public UpdateItemShoppingCartRequestValidator()
        {
            RuleFor(i => i.ProductId).NotEqual(Guid.Empty).WithMessage(InvalidProductIdError);
            RuleFor(i => i.ProductId).NotEqual(Guid.Empty).WithMessage(InvalidProductIdError);
            RuleFor(i => i.Quantity).GreaterThanOrEqualTo(ItemShoppingCart.MIN_QUANTITY).WithMessage(InvalidMinQuantityError);
            RuleFor(i => i.Quantity).LessThanOrEqualTo(ItemShoppingCart.MAX_QUANTITY).WithMessage(InvalidMaxQuantityError);
        }
    }
}