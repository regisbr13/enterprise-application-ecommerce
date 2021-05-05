using Microsoft.AspNetCore.Mvc;
using NSE.WebApiCore.Controllers;

namespace NSE.Customers.API.Controllers
{
    [Route("api/clientes")]
    public class CustomersController : MainController
    {
        [HttpGet("health-check")]
        public ActionResult Get() => Ok();
    }
}