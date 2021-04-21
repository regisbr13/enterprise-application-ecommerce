using MediatR;
using NSE.Core.MediatR;
using NSE.ShoppingCart.API.Application.Requests;
using NSE.ShoppingCart.API.Interfaces;
using NSE.ShoppingCart.API.Models;
using NSE.WebApiCore.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Application.RequestHandlers
{
    public class ReadShoppingCartRequestHandler : MainRequestHandler, IRequestHandler<GetShoppingCartRequest, RequestResult>
    {
        private readonly IShoppingCartRepository _repository;
        private readonly IAspNetUser _user;

        public ReadShoppingCartRequestHandler(IShoppingCartRepository repository, IAspNetUser user)
        {
            _repository = repository;
            _user = user;
        }

        public async Task<RequestResult> Handle(GetShoppingCartRequest request, CancellationToken cancellationToken)
        {
            var customerId = Guid.Parse(_user.GetId());
            var shoppingCart = await _repository.GetShoppingCartByCustomerIdAsync(customerId) ?? new CustomerShoppingCart(customerId);
            return new RequestResult { Content = shoppingCart };
        }
    }
}