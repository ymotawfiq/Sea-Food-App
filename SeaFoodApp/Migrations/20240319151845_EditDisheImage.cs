using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeaFoodApp.Migrations
{
    /// <inheritdoc />
    public partial class EditDisheImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "322900b3-5113-4563-ac54-06da8d8bb5e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e541b2b-e997-4d73-9d38-5c5f3376a805");

            migrationBuilder.RenameColumn(
                name: "ImageUel",
                table: "Dishes",
                newName: "ImageUrl");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e5d9b90a-45f5-4341-bca1-d93d3a3a2db8", "1", "Admin", "Admin" },
                    { "f205a483-fe6a-4f16-ac2c-e774e347665b", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d9b90a-45f5-4341-bca1-d93d3a3a2db8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f205a483-fe6a-4f16-ac2c-e774e347665b");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Dishes",
                newName: "ImageUel");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "322900b3-5113-4563-ac54-06da8d8bb5e1", "2", "User", "User" },
                    { "4e541b2b-e997-4d73-9d38-5c5f3376a805", "1", "Admin", "Admin" }
                });
        }
    }
}
