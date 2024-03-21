using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeaFoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToDish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a81c16-e422-41b9-b72d-09aeec39bdd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "730a2514-463c-48d3-9a57-7f7f935c17d2");

            migrationBuilder.AddColumn<string>(
                name: "DishDescription",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f52d3b1-b072-4e04-8947-98f754b5b904", "1", "Admin", "Admin" },
                    { "97c7fb41-a7e6-4188-bf46-a0e1f76bda47", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f52d3b1-b072-4e04-8947-98f754b5b904");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97c7fb41-a7e6-4188-bf46-a0e1f76bda47");

            migrationBuilder.DropColumn(
                name: "DishDescription",
                table: "Dishes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71a81c16-e422-41b9-b72d-09aeec39bdd0", "2", "User", "User" },
                    { "730a2514-463c-48d3-9a57-7f7f935c17d2", "1", "Admin", "Admin" }
                });
        }
    }
}
