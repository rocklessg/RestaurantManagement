using Microsoft.EntityFrameworkCore;
using Foody.Services.ProductApi.Models;

namespace Foody.Services.ProductApi.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Product> Products { get; set; }
       // public DbSet<Product> Products { get; set; }
    }
}
