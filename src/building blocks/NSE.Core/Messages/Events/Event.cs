using MediatR;
using System;

namespace NSE.Core.Messages.Events
{
    public abstract class Event : INotification
    {
        public DateTime TimeStamp { get; private set; }

        protected Event() => TimeStamp = DateTime.Now;
    }
}