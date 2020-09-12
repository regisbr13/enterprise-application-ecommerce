using NSE.WebApp.Mvc.Interfaces;
using NSE.WebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.Mvc.Services
{
    public class CatalogService : Service, ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/catalogo/");
            if (HasResponseErrors(response)) return new List<ProductViewModel>();

            var products = await DeserializeObjectResponse<List<ProductViewModel>>(response);
            return products;
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/catalogo/{id}");
            if (HasResponseErrors(response)) return new ProductViewModel();

            var product = await DeserializeObjectResponse<ProductViewModel>(response);
            return product;
        }
    }
}