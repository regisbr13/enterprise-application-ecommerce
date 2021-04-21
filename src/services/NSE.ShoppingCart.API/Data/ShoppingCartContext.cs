using Microsoft.EntityFrameworkCore;
using NSE.ShoppingCart.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.ShoppingCart.API.Data
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<ItemShoppingCart> ShoppingCartItems { get; set; }
        public DbSet<CustomerShoppingCart> ShoppingCarts { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
    }
}