using Microsoft.AspNetCore.Mvc;
using NSE.Catalog.API.Interfaces;
using NSE.Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Catalog.API.Controllers
{
    [Route("api/catalogo")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
            => _repository = repository;

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
            => await _repository.GetAll();

        [HttpGet("{id}")]
        public async Task<Product> Get(Guid id)
            => await _repository.GetById(id);
    }
}