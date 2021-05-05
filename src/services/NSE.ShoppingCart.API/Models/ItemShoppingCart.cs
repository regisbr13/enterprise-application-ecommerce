using NSE.Core.DomainObjects;
using System;
using System.Text.Json.Serialization;

namespace NSE.ShoppingCart.API.Models
{
    public class ItemShoppingCart : Entity
    {
        public const int MIN_QUANTITY = 1;
        public const int MAX_QUANTITY = 10;
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Value { get; private set; }
        public string Image { get; private set; }
        public Guid CustomerShoppingCartId { get; set; }

        [JsonIgnore]
        public CustomerShoppingCart CustomerShoppingCart { get; set; }

        protected ItemShoppingCart()
        {
        }

        public ItemShoppingCart(Guid productId, string name, int quantity, decimal value, string image, Guid customerShoppingCartId)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            Value = value;
            Image = image;
            CustomerShoppingCartId = customerShoppingCartId;
        }

        public void AddQuantity(int quantity) => Quantity += quantity;

        public void UpdateQuantity(int quantity) => Quantity = quantity;

        public bool IsValid() => Quantity >= MIN_QUANTITY && Quantity <= MAX_QUANTITY;

        public decimal GetTotalValue() => Quantity * Value;
    }
}