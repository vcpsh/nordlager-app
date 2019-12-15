using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nordlager.Backend.Migrations
{
    public partial class DefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "News",
                nullable: false,
                defaultValueSql: "now()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Documents",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "News");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Documents",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "now()");
        }
    }
}
