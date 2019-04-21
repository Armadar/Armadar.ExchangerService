using Microsoft.EntityFrameworkCore.Migrations;

namespace Armadar.ExchangerService.Migrations
{
    public partial class fixingreatecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "rate",
                table: "Exchanges",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "rate",
                table: "Exchanges",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
