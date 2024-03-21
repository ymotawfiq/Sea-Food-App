using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeaFoodApp.Migrations
{
    /// <inheritdoc />
    public partial class EditDisheImage1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d9b90a-45f5-4341-bca1-d93d3a3a2db8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f205a483-fe6a-4f16-ac2c-e774e347665b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "71a81c16-e422-41b9-b72d-09aeec39bdd0", "2", "User", "User" },
                    { "730a2514-463c-48d3-9a57-7f7f935c17d2", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71a81c16-e422-41b9-b72d-09aeec39bdd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "730a2514-463c-48d3-9a57-7f7f935c17d2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e5d9b90a-45f5-4341-bca1-d93d3a3a2db8", "1", "Admin", "Admin" },
                    { "f205a483-fe6a-4f16-ac2c-e774e347665b", "2", "User", "User" }
                });
        }
    }
}
