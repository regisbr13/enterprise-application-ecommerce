using Microsoft.EntityFrameworkCore.Internal;
using NSE.Catalog.API.Data;
using NSE.Catalog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Catalog.API.Services
{
    public static class SeedService
    {
        public static void Seed(CatalogContext context)
        {
            var products = new List<Product>
            {
                new Product("Camiseta Code Life Preta", "Camiseta 100% algodão, resistente a lavagens e altas temperaturas.", true, 90, 10, DateTime.Now, "camiseta2.jpg"),
                new Product("Caneca No Coffee No Code", "Caneca de porcelana com impressão térmica de alta resistência.", true, 30, 5, DateTime.Now, "caneca4.jpg")
            };

            products.ForEach(product =>
            {
                if (!context.Products.Any(p => p.Name == product.Name))
                    context.Products.Add(product);
            });

            context.SaveChanges();
        }
    }
}