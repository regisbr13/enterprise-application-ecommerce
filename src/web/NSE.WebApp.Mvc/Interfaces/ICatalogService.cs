using NSE.WebApp.Mvc.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Interfaces
{
    public interface ICatalogService
    {
        [Get("/api/catalogo/")]
        Task<IEnumerable<ProductViewModel>> GetAll();

        [Get("/api/catalogo/{id}")]
        Task<ProductViewModel> GetById(Guid id);
    }
}