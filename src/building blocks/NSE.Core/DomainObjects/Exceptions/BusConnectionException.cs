using System;
using System.Runtime.Serialization;

namespace NSE.Core.DomainObjects.Exceptions
{
    [Serializable]
    public class BusConnectionException : Exception
    {
        public BusConnectionException(string message) : base($"Não foi possível conectar-se ao serviço de mensageria: {message}")
        {
        }

        public BusConnectionException()
        {
        }

        public BusConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusConnectionException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}