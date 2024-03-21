using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeaFoodApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDisheImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d66948f-eca2-45d2-960c-a36223291cb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03842c5-c84a-4a0e-9bef-9cc38a8c1ecb");

            migrationBuilder.AddColumn<string>(
                name: "ImageUel",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "322900b3-5113-4563-ac54-06da8d8bb5e1", "2", "User", "User" },
                    { "4e541b2b-e997-4d73-9d38-5c5f3376a805", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322900b3-5113-4563-ac54-06da8d8bb5e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e541b2b-e997-4d73-9d38-5c5f3376a805");

            migrationBuilder.DropColumn(
                name: "ImageUel",
                table: "Dishes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d66948f-eca2-45d2-960c-a36223291cb0", "2", "User", "User" },
                    { "a03842c5-c84a-4a0e-9bef-9cc38a8c1ecb", "1", "Admin", "Admin" }
                });
        }
    }
}
