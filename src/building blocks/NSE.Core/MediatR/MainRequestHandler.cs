using FluentValidation.Results;

namespace NSE.Core.MediatR
{
    public abstract class MainRequestHandler
    {
        protected RequestResult RequestResult;

        protected MainRequestHandler() => RequestResult = new RequestResult();

        protected RequestResult ErrorResult(string errorMessage)
        {
            var validationResult = new ValidationResult();
            validationResult.Errors.Add(new ValidationFailure(string.Empty, errorMessage));
            RequestResult.ValidationResult = validationResult;
            return RequestResult;
        }

        protected RequestResult CommitResult(bool result)
        {
            if (!result)
                return ErrorResult("Erro ao persistir informação no banco de dados.");

            return RequestResult;
        }
    }
}