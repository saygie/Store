using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParentCategory",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, true, false, "Abajurlar", "abajurlar" },
                    { 2, true, false, "Lambaderler", "lambaderler" }
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Link", "Order", "PhotoUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "modern ve şık", true, false, "identity/account/login", 1, "de4bd898-88b0-4cba-b8c1-c59d15f2d190.jpg", 2750.0, "Yeni Soft Koleksiyon" },
                    { 2, "sınırlı stoklarla", true, false, "identity/account/login", 2, "98a44b7e-91bd-4291-93a6-5482cb678cb2.jpg", 1950.0, "Sezon Sonu İndirimleri" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name", "ParentCategoryId", "Slug" },
                values: new object[,]
                {
                    { 1, true, false, "Blue Blanc Serisi", 1, "blue-blanc-serisi" },
                    { 2, true, false, "Ahşap Serisi", 1, "ahsap-serisi" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Code", "Description", "IsActive", "IsDeleted", "Name", "Price", "Slug", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "8622f51e", "modern ve şık", true, false, "Product-1", 2750.0, "product-1", 3 },
                    { 2, 2, "9dae0207", "modern ve şık", true, false, "Product-2", 3300.0, "product-2", 4 },
                    { 3, 2, "9dae0202", "modern ve şık", true, false, "Product-3", 1750.0, "product-3", 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductPhoto",
                columns: new[] { "Id", "IsActive", "IsDeleted", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, true, false, 1, "6e9694b3-f6ea-46ce-8637-fb933352781e.jpg" },
                    { 2, true, false, 2, "cdf13471-2761-4fab-aa98-ba1bf26933a4.jpg" },
                    { 3, true, false, 3, "a985a819-7a2c-49d3-8fb0-07deea42c239.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParentCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParentCategory",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
