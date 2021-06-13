using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class RecenzijaSoba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sobaID",
                table: "Recenzija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_sobaID",
                table: "Recenzija",
                column: "sobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija",
                column: "sobaID",
                principalTable: "Soba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_Soba_sobaID",
                table: "Recenzija");

            migrationBuilder.DropIndex(
                name: "IX_Recenzija_sobaID",
                table: "Recenzija");

            migrationBuilder.DropColumn(
                name: "sobaID",
                table: "Recenzija");
        }
    }
}
