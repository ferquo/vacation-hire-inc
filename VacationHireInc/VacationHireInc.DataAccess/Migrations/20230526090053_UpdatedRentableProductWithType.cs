using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationHireInc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRentableProductWithType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductType",
                table: "RentableProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RentableProducts",
                keyColumn: "Id",
                keyValue: new Guid("19847126-445e-48f7-97c7-1d25d71365d5"),
                column: "ProductType",
                value: "vechicle");

            migrationBuilder.UpdateData(
                table: "RentableProducts",
                keyColumn: "Id",
                keyValue: new Guid("448edcd9-e7a0-47b3-975f-2e49ddb00040"),
                column: "ProductType",
                value: "vechicle");

            migrationBuilder.UpdateData(
                table: "RentableProducts",
                keyColumn: "Id",
                keyValue: new Guid("74641849-26ec-4a1c-be8c-d7b4d6ffd83c"),
                column: "ProductType",
                value: "vechicle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductType",
                table: "RentableProducts");
        }
    }
}
