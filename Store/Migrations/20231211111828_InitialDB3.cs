using System;
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
            migrationBuilder.AddColumn<string>(
                name: "GId",
                table: "Address",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1,
                column: "GId",
                value: "c09c96a5-4437-43f8-b6ee-7c61c0cee6ee");

            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2,
                column: "GId",
                value: "80739115-9401-4d35-a286-805e611860b4");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 12, 18, 27, 669, DateTimeKind.Local).AddTicks(9263));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 12, 18, 27, 669, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 12, 18, 27, 669, DateTimeKind.Local).AddTicks(9346));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GId",
                table: "Address");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 9, 10, 10, 504, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 9, 10, 10, 504, DateTimeKind.Local).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 12, 9, 10, 10, 504, DateTimeKind.Local).AddTicks(8854));
        }
    }
}
