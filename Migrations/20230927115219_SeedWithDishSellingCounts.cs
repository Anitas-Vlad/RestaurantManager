using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedWithDishSellingCounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DishSellingCounts",
                columns: new[] { "Id", "DishId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Best Dish", 0 },
                    { 2, 2, "Worst", 0 },
                    { 3, 3, "Dutch Anger", 0 },
                    { 4, 4, "Fishy Stuff", 0 },
                    { 5, 5, "Moowie Woowie", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishSellingCounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DishSellingCounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DishSellingCounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DishSellingCounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DishSellingCounts",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
