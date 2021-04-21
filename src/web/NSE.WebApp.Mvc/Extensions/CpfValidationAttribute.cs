using NSE.Core.DomainObjects.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace NSE.WebApp.Mvc.Extensions
{
    public sealed class CpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            => (Cpf.IsValid(value.ToString()) ? ValidationResult.Success : new ValidationResult(Cpf.ErrorMessage));
    }
}