using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Foody.Services.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeededProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Our Shawarma, prepared to perfection, is an irresistible blend of flavors and textures. Elevate your taste buds with our signature sauces, crisp vegetables, and delightful condiments.", "https://dotnetmastery.blob.core.windows.net/mango/12.jpg", "Shawarma", 15.0 },
                    { 2, "Appetizer", "Indulge in the rich flavors of our Chicken Palak — a culinary masterpiece that combines tender chicken with a luscious spinach-based curry. Immerse your taste buds in a symphony of aromatic spices and wholesome ingredients, creating a dining experience that's both delicious and nutritious.", "https://dotnetmastery.blob.core.windows.net/mango/14.jpg", "Chiken Palakash", 13.99 },
                    { 3, "Dessert", "Satisfy your sweet cravings with our delectable Sweet Pie, a delightful treat. Each slice is a journey into sweetness, with a perfect balance of textures and a hint of homemade goodness.", "https://dotnetmastery.blob.core.windows.net/mango/11.jpg", "Sweet Pie", 10.99 },
                    { 4, "Entree", "Experience the golden sweetness of our Honey Pie, a delectable creation that combines the richness of honey with a flaky, buttery crust.", "https://dotnetmastery.blob.core.windows.net/mango/13.jpg", "Honey Pie", 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
