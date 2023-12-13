using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name" },
                values: new object[] { 2, true, false, "Adana" });

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

            migrationBuilder.InsertData(
                table: "County",
                columns: new[] { "Id", "CityId", "IsActive", "IsDeleted", "Name" },
                values: new object[] { 3, 2, true, false, "Yüreğir" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "County",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(732));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                column: "SpecialOfferEndDate",
                value: new DateTime(2023, 12, 11, 13, 30, 45, 774, DateTimeKind.Local).AddTicks(759));
        }
    }
}
