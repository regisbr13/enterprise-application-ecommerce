using Microsoft.EntityFrameworkCore.Internal;
using NSE.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.ShoppingCart.API.Models
{
    public class CustomerShoppingCart : Entity
    {
        public Guid CustomerId { get; private set; }
        public decimal TotalValue { get; private set; }
        public List<ItemShoppingCart> Items { get; private set; }

        public CustomerShoppingCart(Guid customerId)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Items = new List<ItemShoppingCart>();
        }

        public bool AddItem(ItemShoppingCart item)
        {
            if (HasItem(item.ProductId))
            {
                var itemRegistered = GetItem(item.ProductId);
                itemRegistered.AddQuantity(item.Quantity);

                if (!itemRegistered.IsValid())
                    return false;
            }
            else
                Items.Add(item);

            CalculateTotalValue();
            return true;
        }

        public bool UpdateItem(Guid productId, int quantity)
        {
            var itemRegistered = GetItem(productId);
            itemRegistered.UpdateQuantity(quantity);
            if (!itemRegistered.IsValid())
                return false;

            CalculateTotalValue();
            return true;
        }

        public void RemoveItem(ItemShoppingCart item)
        {
            Items.Remove(item);
            CalculateTotalValue();
        }

        public bool HasItem(Guid productId) => Items.Any(i => i.ProductId == productId);

        public ItemShoppingCart GetItem(Guid productId) => Items.FirstOrDefault(i => i.ProductId == productId);

        private void CalculateTotalValue() => TotalValue = Items.Sum(i => i.GetTotalValue());
    }
}