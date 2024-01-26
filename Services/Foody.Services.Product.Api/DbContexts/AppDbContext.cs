using Microsoft.EntityFrameworkCore;

namespace Foody.Services.Product.Api.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
                
        }
    }
}
