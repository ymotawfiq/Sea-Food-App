using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SeaFoodApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66a0e3bb-3fb3-404b-85c0-97dceda8be05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c090a835-bc79-412b-a4b0-0f94e11b5380");

            migrationBuilder.DropColumn(
                name: "TimeToPrepareInHours",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d66948f-eca2-45d2-960c-a36223291cb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03842c5-c84a-4a0e-9bef-9cc38a8c1ecb");

            migrationBuilder.AddColumn<float>(
                name: "TimeToPrepareInHours",
                table: "Dishes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66a0e3bb-3fb3-404b-85c0-97dceda8be05", "2", "User", "User" },
                    { "c090a835-bc79-412b-a4b0-0f94e11b5380", "1", "Admin", "Admin" }
                });
        }
    }
}
