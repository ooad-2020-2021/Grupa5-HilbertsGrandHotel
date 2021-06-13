using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class datumSobe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "datumOdjave",
                table: "Soba",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "datumPrijave",
                table: "Soba",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datumOdjave",
                table: "Soba");

            migrationBuilder.DropColumn(
                name: "datumPrijave",
                table: "Soba");
        }
    }
}
