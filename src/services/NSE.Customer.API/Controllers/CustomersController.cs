using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSE.Customers.API.Application.Requests;
using NSE.WebApiCore.Controllers;
using System;
using System.Threading.Tasks;

namespace NSE.Customers.API.Controllers
{
    [Route("api/clientes")]
    public class CustomersController : MainController
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator) => _mediator = mediator;

        [HttpGet("registrar")]
        public async Task<ActionResult> Get()
        {
            var customerRequest = new RegisterCustomerRequest(Guid.NewGuid(), "Regis", "regis@email.com", "476.671.200-56");
            var result = await _mediator.Send(customerRequest);
            return CustomResponse(result);
        }
    }
}