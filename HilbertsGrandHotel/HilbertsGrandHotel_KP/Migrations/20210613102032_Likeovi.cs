using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class Likeovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "likes",
                table: "Recenzija",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "likes",
                table: "Recenzija");
        }
    }
}
