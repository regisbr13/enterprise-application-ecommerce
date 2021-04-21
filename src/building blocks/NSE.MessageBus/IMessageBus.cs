using EasyNetQ;
using NSE.Core.Messages;
using NSE.Core.Messages.Events;
using System;
using System.Threading.Tasks;

namespace NSE.MessageBus
{
    public interface IMessageBus : IDisposable
    {
        bool IsConnected { get; }

        IAdvancedBus AdvancedBus { get; }

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : Event
            where TResponse : ResponseMessage;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : Event
            where TResponse : ResponseMessage;
    }
}