﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Armadar.ExchangerService.Migrations
{
    public partial class AddingisActivecolumntotheExchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Exchanges",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Exchanges");
        }
    }
}
