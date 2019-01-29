using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Data
{
    public class ShoppingCartDbContext : DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
       
}
