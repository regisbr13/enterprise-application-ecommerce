using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NSE.Core.MediatR;
using System.Collections.Generic;
using System.Linq;

namespace NSE.WebApiCore.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Errors = new List<string>();

        protected bool OperationIsValid() => !Errors.Any();

        protected void NotifyError(string error) => Errors.Add(error);

        protected void NotifyModelErrors()
        {
            var errors = ModelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                NotifyError(error.Exception != null ? error.Exception.Message : error.ErrorMessage);
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid()) return Ok(result);

            return BadRequest(new { errors = Errors });
        }

        protected ActionResult CustomResponse(RequestResult result)
        {
            if (result.IsValid) return Ok(result.Content);

            return Ok(new { errors = result.ValidationResult.Errors.Select(e => e.ErrorMessage) });
        }

        protected ActionResult CustomResponse(ValidationResult result)
        {
            if (result.IsValid) return Ok();

            return BadRequest(new { errors = result.Errors.Select(e => e.ErrorMessage) });
        }
    }
}