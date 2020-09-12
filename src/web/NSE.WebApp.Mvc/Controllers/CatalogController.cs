using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Interfaces;
using System;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Controllers
{
    public class CatalogController : MainController
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
            => _service = service;

        [HttpGet]
        [Route("")]
        [Route("/produtos")]
        public async Task<IActionResult> Index() => View(await _service.GetAll());

        [HttpGet]
        [Route("/produtos/{id}")]
        public async Task<IActionResult> Details(Guid id) => View(await _service.GetById(id));
    }
}