using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                    table.ForeignKey(
                        name: "FK_County_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_ParentCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhood_County_CountyId",
                        column: x => x.CountyId,
                        principalTable: "County",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    PriceWithoutDiscount = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscounted = table.Column<bool>(type: "bit", nullable: false),
                    IsMostSelled = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialOffer = table.Column<bool>(type: "bit", nullable: false),
                    SpecialOfferEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhoto_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ParentCategory",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name", "Order", "PhotoUrl", "Slug" },
                values: new object[,]
                {
                    { 1, true, false, "Abajur", 1, "1.jpg", "abajur" },
                    { 2, true, false, "Lambader", 2, "2.jpg", "lambader" },
                    { 3, true, false, "Şamdan & Mumluk", 3, "3.jpg", "dekorasyon" },
                    { 4, true, false, "Ampül & Led", 4, "4.jpg", "dekorasyon" }
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "Description", "IsActive", "IsDeleted", "Link", "Order", "PhotoUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "modern ve şık", true, false, "identity/account/login", 1, "de4bd898-88b0-4cba-b8c1-c59d15f2d190.jpg", 2750.0, "Yeni Soft Koleksiyon" },
                    { 2, "sınırlı stoklarla", true, false, "identity/account/login", 2, "98a44b7e-91bd-4291-93a6-5482cb678cb2.jpg", 1950.0, "Sezon Sonu İndirimleri" },
                    { 3, "porselen kalitesiyle", true, false, "identity/account/login", 3, "8f8fbaa963f1e51d5ba74ac4bda36287.jpg", 3250.0, "Fırsat Ürünleri" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsActive", "IsDeleted", "IsFeatured", "Name", "Order", "ParentCategoryId", "PhotoUrl", "Slug" },
                values: new object[,]
                {
                    { 1, true, false, false, "Blue Blanc Serisi", 1, 1, "1.jpg", "blue-blanc-serisi" },
                    { 2, true, false, false, "Ahşap Serisi", 2, 1, "2.jpg", "ahsap-serisi" },
                    { 3, true, false, false, "Porselen Serisi", 3, 1, "3.jpg", "porselen-serisi" },
                    { 4, true, false, false, "Cam Serisi", 4, 1, "4.jpg", "cam-serisi" },
                    { 5, true, false, false, "Metal Serisi", 5, 1, "5.jpg", "metal-serisi" },
                    { 6, true, false, false, "Ahsap Serisi", 1, 2, "6.jpg", "ahsap-serisi" },
                    { 7, true, false, false, "Metal Serisi", 2, 2, "7.jpg", "metal-serisi" },
                    { 8, true, false, false, "Şamdan", 1, 3, "8.jpg", "samdan" },
                    { 9, true, false, false, "Mumluk", 2, 3, "9.jpg", "mumluk" },
                    { 10, true, false, false, "Rustik Ampül", 1, 4, "10.jpg", "rustik-ampul" },
                    { 11, true, false, false, "Led", 2, 4, "11.jpg", "led" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Code", "Description", "Discount", "IsActive", "IsDeleted", "IsDiscounted", "IsFeatured", "IsMostSelled", "IsNew", "IsSpecialOffer", "Name", "Price", "PriceWithoutDiscount", "Slug", "SpecialOfferEndDate", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "8622f51e", "modern ve şık", 10, true, false, true, true, true, true, true, "Product-1", 2700.0, 3000.0, "product-1", new DateTime(2023, 12, 3, 15, 9, 34, 775, DateTimeKind.Local).AddTicks(6368), 3 },
                    { 2, 2, "9dae0207", "modern ve şık", 9, true, false, true, true, true, true, true, "Product-2", 3300.0, 3600.0, "product-2", new DateTime(2023, 12, 3, 15, 9, 34, 775, DateTimeKind.Local).AddTicks(6388), 4 },
                    { 3, 2, "27ae0101", "modern ve şık", 23, true, false, true, true, true, true, true, "Product-3", 1750.0, 2250.0, "product-3", new DateTime(2023, 12, 3, 15, 9, 34, 775, DateTimeKind.Local).AddTicks(6391), 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductPhoto",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Order", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, true, false, 1, 1, "6e9694b3-f6ea-46ce-8637-fb933352781e.jpg" },
                    { 2, true, false, 1, 2, "cdf13471-2761-4fab-aa98-ba1bf26933a4.jpg" },
                    { 3, true, false, 1, 3, "a985a819-7a2c-49d3-8fb0-07deea42c239.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_County_CityId",
                table: "County",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_CountyId",
                table: "Neighborhood",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhoto_ProductId",
                table: "ProductPhoto",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "ProductPhoto");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ParentCategory");
        }
    }
}
