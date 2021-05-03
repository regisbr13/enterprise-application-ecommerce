using FluentValidation.Results;

namespace NSE.Core.Messages
{
    public class ResponseMessage
    {
        public ValidationResult ValidationResult { get; set; }
        public bool Succeeded => ValidationResult?.IsValid ?? false;

        public ResponseMessage() => ValidationResult = new ValidationResult();
    }
}