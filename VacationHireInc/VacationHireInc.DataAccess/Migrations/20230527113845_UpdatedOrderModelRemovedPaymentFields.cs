using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationHireInc.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOrderModelRemovedPaymentFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaidInCurrency",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaidInCurrency",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
