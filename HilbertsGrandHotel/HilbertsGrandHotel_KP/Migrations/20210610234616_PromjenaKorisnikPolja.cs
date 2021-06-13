using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class PromjenaKorisnikPolja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soba_Korisnik_korisnikID",
                table: "Soba");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "Soba",
                newName: "korisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Soba_korisnikID",
                table: "Soba",
                newName: "IX_Soba_korisnikId");

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "Soba",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Soba_AspNetUsers_korisnikId",
                table: "Soba",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soba_AspNetUsers_korisnikId",
                table: "Soba");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "Soba",
                newName: "korisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Soba_korisnikId",
                table: "Soba",
                newName: "IX_Soba_korisnikID");

            migrationBuilder.AlterColumn<int>(
                name: "korisnikID",
                table: "Soba",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Soba_Korisnik_korisnikID",
                table: "Soba",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
