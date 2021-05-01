using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Core.Messages;
using NSE.Core.Messages.Events;
using NSE.Customers.API.Application.Requests;
using NSE.MessageBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Customers.API.Application.EventHandlers
{
    public class CustomerEventHandlerService : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CustomerEventHandlerService(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _bus.AdvancedBus.Connected += OnConnected;
            SetResponder();
            return Task.CompletedTask;
        }

        private void SetResponder()
        {
            if (_bus.IsConnected)
                _bus.RespondAsync<CustomerRegisteredEvent, ResponseMessage>(async request => await SendRegisterCustomerRequest(request));
        }

        private void OnConnected(object sender, EventArgs e) => SetResponder();

        private async Task<ResponseMessage> SendRegisterCustomerRequest(CustomerRegisteredEvent request)
        {
            var customerRequest = new RegisterCustomerRequest(request.Id, request.Name, request.Email, request.Cpf);

            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            return new ResponseMessage(await mediator.Send(customerRequest));
        }
    }
}