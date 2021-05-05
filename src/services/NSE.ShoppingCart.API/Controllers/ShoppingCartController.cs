using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSE.Core.Utils;
using NSE.ShoppingCart.API.Application.Requests;
using NSE.ShoppingCart.API.Models;
using NSE.WebApiCore.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Controllers
{
    [Route("api/carrinho")]
    public class ShoppingCartController : MainController
    {
        private readonly IMediator _mediator;

        public ShoppingCartController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<CustomerShoppingCart>> Get()
            => CustomResponse(await _mediator.Send(new GetShoppingCartRequest()));

        [HttpPost]
        public async Task<ActionResult> Post(AddItemShoppingCartRequest request)
            => CustomResponse(await _mediator.Send(request));

        [HttpPut("{productId}")]
        public async Task<ActionResult> Put(Guid productId, UpdateItemShoppingCartRequest request)
        {
            if (productId != request.ProductId)
            {
                NotifyError(Resources.ProductsIdsDontMatch);
                return CustomResponse();
            }

            return CustomResponse(await _mediator.Send(request));
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(Guid productId)
            => CustomResponse(await _mediator.Send(new DeleteItemShoppingCartRequest { ProductId = productId }));
    }
}