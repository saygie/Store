using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProductPhoto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMostSelled",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecialOffer",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "PriceWithoutDiscount",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SpecialOfferEndDate",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ParentCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "ParentCategory",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Category",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsFeatured", "Order", "PhotoUrl" },
                values: new object[] { false, 1, "1.jpg" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsFeatured", "Order", "PhotoUrl" },
                values: new object[] { false, 2, "1.jpg" });

            migrationBuilder.UpdateData(
                table: "ParentCategory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Order", "PhotoUrl" },
                values: new object[] { 1, "1.jpg" });

            migrationBuilder.UpdateData(
                table: "ParentCategory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Order", "PhotoUrl" },
                values: new object[] { 2, "2.jpg" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "IsDiscounted", "IsFeatured", "IsMostSelled", "IsNew", "IsSpecialOffer", "Price", "PriceWithoutDiscount", "SpecialOfferEndDate" },
                values: new object[] { 10, true, true, true, true, true, 2700.0, 3000.0, new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3656) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "IsDiscounted", "IsFeatured", "IsMostSelled", "IsNew", "IsSpecialOffer", "PriceWithoutDiscount", "SpecialOfferEndDate" },
                values: new object[] { 9, true, true, true, true, true, 3600.0, new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3691) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Discount", "IsDiscounted", "IsFeatured", "IsMostSelled", "IsNew", "IsSpecialOffer", "PriceWithoutDiscount", "SpecialOfferEndDate" },
                values: new object[] { "27ae0101", 23, true, true, true, true, true, 2250.0, new DateTime(2023, 12, 1, 11, 5, 15, 662, DateTimeKind.Local).AddTicks(3694) });

            migrationBuilder.UpdateData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 1,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 2,
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductPhoto",
                keyColumn: "Id",
                keyValue: 3,
                column: "Order",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProductPhoto");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsMostSelled",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsSpecialOffer",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PriceWithoutDiscount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SpecialOfferEndDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ParentCategory");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "ParentCategory");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2750.0);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "9dae0202");
        }
    }
}
