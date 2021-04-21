using FluentValidation.Results;
using NSE.Core.MediatR;

namespace NSE.Core.Messages
{
    public class ResponseMessage
    {
        public ValidationResult ValidationResult { get; private set; }
        public bool Succeeded => ValidationResult.IsValid;

        public ResponseMessage(RequestResult result)
        {
            ValidationResult = result.ValidationResult;
        }
    }
}