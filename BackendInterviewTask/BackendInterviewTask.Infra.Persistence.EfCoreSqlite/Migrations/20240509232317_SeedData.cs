using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendInterviewTask.Infra.Persistence.EfCoreSqlite.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 1, "https://api.dicebear.com/8.x/pixel-art/png?seed=john&size=150" },
                    { 2, "https://api.dicebear.com/8.x/pixel-art/png?seed=jane&size=150" },
                    { 3, "https://api.dicebear.com/8.x/pixel-art/png?seed=aneka&size=150" },
                    { 4, "https://api.dicebear.com/8.x/pixel-art/png?seed=flix&size=150" },
                    { 5, "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
