using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class SobaNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija");

            migrationBuilder.AlterColumn<int>(
                name: "sobaID",
                table: "Recenzija",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija",
                column: "sobaID",
                principalTable: "Soba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija");

            migrationBuilder.AlterColumn<int>(
                name: "sobaID",
                table: "Recenzija",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija",
                column: "sobaID",
                principalTable: "Soba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
