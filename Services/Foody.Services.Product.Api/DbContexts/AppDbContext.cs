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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Shawarma",
                Price = 15,
                Description = "Our Shawarma, prepared to perfection, is an irresistible blend of flavors and textures. Elevate your taste buds with our signature sauces, crisp vegetables, and delightful condiments.",
                ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/12.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Chiken Palakash",
                Price = 13.99,
                Description = "Indulge in the rich flavors of our Chicken Palak — a culinary masterpiece that combines tender chicken with a luscious spinach-based curry. Immerse your taste buds in a symphony of aromatic spices and wholesome ingredients, creating a dining experience that's both delicious and nutritious.",
                ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/14.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet Pie",
                Price = 10.99,
                Description = "Satisfy your sweet cravings with our delectable Sweet Pie, a delightful treat. Each slice is a journey into sweetness, with a perfect balance of textures and a hint of homemade goodness.",
                ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/11.jpg",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Honey Pie",
                Price = 15,
                Description = "Experience the golden sweetness of our Honey Pie, a delectable creation that combines the richness of honey with a flaky, buttery crust.",
                ImageUrl = "https://dotnetmastery.blob.core.windows.net/mango/13.jpg",
                CategoryName = "Entree"
            });
        }
    }
}
