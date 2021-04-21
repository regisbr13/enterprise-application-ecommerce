using FluentValidation.Results;
using NSE.Core.DomainObjects;

namespace NSE.Core.MediatR
{
    public class RequestResult
    {
        public ValidationResult ValidationResult { get; set; }
        public Entity Content { get; set; }
        public bool IsValid => ValidationResult.IsValid;

        public RequestResult() => ValidationResult = new ValidationResult();
    }
}