using Microsoft.EntityFrameworkCore.Migrations;

namespace Armadar.ExchangerService.Migrations
{
    public partial class fixingcolumntypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "to",
                table: "Exchanges",
                type: "varchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "operation",
                table: "Exchanges",
                type: "varchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "from",
                table: "Exchanges",
                type: "varchar(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "to",
                table: "Exchanges",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "operation",
                table: "Exchanges",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "from",
                table: "Exchanges",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)",
                oldNullable: true);
        }
    }
}
