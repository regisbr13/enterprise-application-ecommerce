using MediatR;
using NSE.Core.MediatR;
using System;

namespace NSE.ShoppingCart.API.Application.Requests
{
    public class AddItemShoppingCartRequest : IRequest<RequestResult>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string Image { get; set; }
    }
}