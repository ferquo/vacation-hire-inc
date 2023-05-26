using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VacationHireInc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRentableProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RentedProductId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RentableProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentableProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RentableProducts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("19847126-445e-48f7-97c7-1d25d71365d5"), "Truck" },
                    { new Guid("448edcd9-e7a0-47b3-975f-2e49ddb00040"), "Sedan" },
                    { new Guid("74641849-26ec-4a1c-be8c-d7b4d6ffd83c"), "Minivan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RentedProductId",
                table: "Orders",
                column: "RentedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RentableProducts_RentedProductId",
                table: "Orders",
                column: "RentedProductId",
                principalTable: "RentableProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RentableProducts_RentedProductId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "RentableProducts");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RentedProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RentedProductId",
                table: "Orders");
        }
    }
}
