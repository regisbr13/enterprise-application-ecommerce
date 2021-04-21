using MediatR;
using NSE.Core.MediatR;
using System;

namespace NSE.ShoppingCart.API.Application.Requests
{
    public class DeleteItemShoppingCartRequest : IRequest<RequestResult>
    {
        public Guid ProductId { get; set; }
    }
}