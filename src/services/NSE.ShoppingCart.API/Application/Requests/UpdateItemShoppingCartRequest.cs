using MediatR;
using NSE.Core.MediatR;
using System;

namespace NSE.ShoppingCart.API.Application.Requests
{
    public class UpdateItemShoppingCartRequest : IRequest<RequestResult>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}