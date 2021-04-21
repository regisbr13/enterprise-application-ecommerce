using MediatR;
using NSE.Core.MediatR;
using NSE.ShoppingCart.API.Application.Requests;
using NSE.ShoppingCart.API.Application.Requests.Validations;
using NSE.ShoppingCart.API.Interfaces;
using NSE.ShoppingCart.API.Models;
using NSE.WebApiCore.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Application.RequestHandlers
{
    public class WriteShoppingCartRequestHandler : MainRequestHandler, IRequestHandler<AddItemShoppingCartRequest, RequestResult>,
        IRequestHandler<UpdateItemShoppingCartRequest, RequestResult>, IRequestHandler<DeleteItemShoppingCartRequest, RequestResult>
    {
        private const string NullShoppingCartError = "Carrinho de compras não existe";
        private const string HasNotProductShoppingCartError = "Carrinho não possui o produto";
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IItemShoppingCartRepository _itemShoppingCartRepository;
        private readonly Guid _customerId;

        public WriteShoppingCartRequestHandler(IShoppingCartRepository shoppingCartRepository,
            IItemShoppingCartRepository itemShoppingCartRepository, IAspNetUser user)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _itemShoppingCartRepository = itemShoppingCartRepository;
            _customerId = Guid.Parse(user.GetId());
        }

        public async Task<RequestResult> Handle(AddItemShoppingCartRequest request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByCustomerIdAsync(_customerId);
            var item = new ItemShoppingCart(request.ProductId, request.Name, request.Quantity, request.Value, request.Image, shoppingCart?.Id ?? Guid.Empty);

            if (shoppingCart == null)
            {
                shoppingCart = new CustomerShoppingCart(_customerId);
                shoppingCart.AddItem(item);
                return CommitResult(await _shoppingCartRepository.InsertAsync(shoppingCart));
            }

            var itemExists = shoppingCart.HasItem(item.ProductId);
            if (!shoppingCart.AddItem(item))
                return ErrorResult(AddItemShoppingCartRequestValidator.InvalidMaxQuantityError);

            if (!itemExists)
                await _itemShoppingCartRepository.InsertAsync(item);

            return CommitResult(await _shoppingCartRepository.UpdateAsync(shoppingCart));
        }

        public async Task<RequestResult> Handle(UpdateItemShoppingCartRequest request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByCustomerIdAsync(_customerId);
            if (shoppingCart == null)
                return ErrorResult(NullShoppingCartError);

            if (!shoppingCart.HasItem(request.ProductId))
                return ErrorResult(HasNotProductShoppingCartError);

            if (!shoppingCart.UpdateItem(request.ProductId, request.Quantity))
                return ErrorResult(AddItemShoppingCartRequestValidator.InvalidMaxQuantityError);

            return CommitResult(await _shoppingCartRepository.UpdateAsync(shoppingCart));
        }

        public async Task<RequestResult> Handle(DeleteItemShoppingCartRequest request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByCustomerIdAsync(_customerId);
            if (shoppingCart == null)
                return ErrorResult(NullShoppingCartError);

            if (!shoppingCart.HasItem(request.ProductId))
                return ErrorResult(HasNotProductShoppingCartError);

            var item = shoppingCart.GetItem(request.ProductId);
            shoppingCart.RemoveItem(item);
            return CommitResult(await _shoppingCartRepository.UpdateAsync(shoppingCart) && await _itemShoppingCartRepository.DeleteAsync(item));
        }
    }
}