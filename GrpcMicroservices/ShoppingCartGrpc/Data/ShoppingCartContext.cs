using Microsoft.EntityFrameworkCore;
using ShoppingCartGrpc.Models;

namespace ShoppingCartGrpc.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
