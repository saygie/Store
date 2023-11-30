using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Link", "Order", "PhotoUrl", "Price", "Title" },
                values: new object[] { 3, "porselen kalitesiyle", true, false, "identity/account/login", 3, "8f8fbaa963f1e51d5ba74ac4bda36287.jpg", 3250.0, "Fırsat Ürünleri" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
