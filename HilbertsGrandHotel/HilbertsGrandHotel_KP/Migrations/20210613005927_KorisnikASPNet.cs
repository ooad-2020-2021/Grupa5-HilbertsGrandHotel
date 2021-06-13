using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class KorisnikASPNet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mojRegisteredUserId",
                table: "Korisnik",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_mojRegisteredUserId",
                table: "Korisnik",
                column: "mojRegisteredUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_AspNetUsers_mojRegisteredUserId",
                table: "Korisnik",
                column: "mojRegisteredUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_AspNetUsers_mojRegisteredUserId",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_mojRegisteredUserId",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "mojRegisteredUserId",
                table: "Korisnik");
        }
    }
}
