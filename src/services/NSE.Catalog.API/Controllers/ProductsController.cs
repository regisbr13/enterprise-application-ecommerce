using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Interfaces;
using NSE.Catalog.API.Models;
using NSE.WebApiCore.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalog.API.Controllers
{
    [Route("api/catalogo")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
            => _repository = repository;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Product>> Get()
            => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        //[ClaimAuthorize("Catalog", "Read")]
        public async Task<Product> Get(Guid id)
            => await _repository.GetByIdAsync(id);
    }
}