using System;
using System.Collections.Generic;

namespace NSE.WebApp.Mvc.Models
{
    public class ShoppingCartViewModel
    {
        public Guid CustomerId { get; set; }
        public decimal TotalValue { get; set; }
        public List<ItemShoppingCartViewModel> Items { get; set; }
        public ErrorResponseViewModel ErrorResponse { get; set; }
    }
}