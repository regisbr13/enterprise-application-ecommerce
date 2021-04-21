using FluentValidation;
using FluentValidation.Results;
using MediatR;
using NSE.Core.MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.WebApiCore.Validations
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TResponse : RequestResult
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationPipelineBehavior(IValidator<TRequest> validator = null)
            => _validator = validator;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResult = _validator?.Validate(request) ?? new ValidationResult();
            if (validationResult.IsValid)
                return next.Invoke();

            return Task.FromResult(new RequestResult { ValidationResult = validationResult } as TResponse);
        }
    }
}