using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class MojRegisteredUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaplataRecepcioner_Korisnik_korisnikID",
                table: "NaplataRecepcioner");

            migrationBuilder.DropForeignKey(
                name: "FK_OdjavaRezervacije_Korisnik_korisnikID",
                table: "OdjavaRezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikID",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_Korisnik_uplatiocID",
                table: "Uplata");

            migrationBuilder.RenameColumn(
                name: "uplatiocID",
                table: "Uplata",
                newName: "uplatiocId");

            migrationBuilder.RenameIndex(
                name: "IX_Uplata_uplatiocID",
                table: "Uplata",
                newName: "IX_Uplata_uplatiocId");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "Rezervacija",
                newName: "korisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_korisnikID",
                table: "Rezervacija",
                newName: "IX_Rezervacija_korisnikId");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "OdjavaRezervacije",
                newName: "korisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_OdjavaRezervacije_korisnikID",
                table: "OdjavaRezervacije",
                newName: "IX_OdjavaRezervacije_korisnikId");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "NaplataRecepcioner",
                newName: "korisnikId");

            migrationBuilder.RenameIndex(
                name: "IX_NaplataRecepcioner_korisnikID",
                table: "NaplataRecepcioner",
                newName: "IX_NaplataRecepcioner_korisnikId");

            migrationBuilder.AlterColumn<string>(
                name: "uplatiocId",
                table: "Uplata",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "Rezervacija",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "OdjavaRezervacije",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "korisnikId",
                table: "NaplataRecepcioner",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_NaplataRecepcioner_AspNetUsers_korisnikId",
                table: "NaplataRecepcioner",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdjavaRezervacije_AspNetUsers_korisnikId",
                table: "OdjavaRezervacije",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_AspNetUsers_korisnikId",
                table: "Rezervacija",
                column: "korisnikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_AspNetUsers_uplatiocId",
                table: "Uplata",
                column: "uplatiocId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NaplataRecepcioner_AspNetUsers_korisnikId",
                table: "NaplataRecepcioner");

            migrationBuilder.DropForeignKey(
                name: "FK_OdjavaRezervacije_AspNetUsers_korisnikId",
                table: "OdjavaRezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_AspNetUsers_korisnikId",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_AspNetUsers_uplatiocId",
                table: "Uplata");

            migrationBuilder.RenameColumn(
                name: "uplatiocId",
                table: "Uplata",
                newName: "uplatiocID");

            migrationBuilder.RenameIndex(
                name: "IX_Uplata_uplatiocId",
                table: "Uplata",
                newName: "IX_Uplata_uplatiocID");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "Rezervacija",
                newName: "korisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_korisnikId",
                table: "Rezervacija",
                newName: "IX_Rezervacija_korisnikID");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "OdjavaRezervacije",
                newName: "korisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_OdjavaRezervacije_korisnikId",
                table: "OdjavaRezervacije",
                newName: "IX_OdjavaRezervacije_korisnikID");

            migrationBuilder.RenameColumn(
                name: "korisnikId",
                table: "NaplataRecepcioner",
                newName: "korisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_NaplataRecepcioner_korisnikId",
                table: "NaplataRecepcioner",
                newName: "IX_NaplataRecepcioner_korisnikID");

            migrationBuilder.AlterColumn<int>(
                name: "uplatiocID",
                table: "Uplata",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "korisnikID",
                table: "Rezervacija",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "korisnikID",
                table: "OdjavaRezervacije",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "korisnikID",
                table: "NaplataRecepcioner",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_NaplataRecepcioner_Korisnik_korisnikID",
                table: "NaplataRecepcioner",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OdjavaRezervacije_Korisnik_korisnikID",
                table: "OdjavaRezervacije",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Korisnik_korisnikID",
                table: "Rezervacija",
                column: "korisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_Korisnik_uplatiocID",
                table: "Uplata",
                column: "uplatiocID",
                principalTable: "Korisnik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
