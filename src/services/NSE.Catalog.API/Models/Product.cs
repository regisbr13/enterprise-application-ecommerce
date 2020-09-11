using NSE.Core.DomainObjects;
using System;

namespace NSE.Catalog.API.Models
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime Register { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, bool active, decimal value, int stockQuantity, DateTime register, string image)
        {
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            StockQuantity = stockQuantity;
            Register = register;
            Image = image;
        }
    }
}