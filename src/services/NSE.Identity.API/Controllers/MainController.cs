using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Identity.API.Controllers
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
    }
}