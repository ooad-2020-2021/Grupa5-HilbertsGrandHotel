using Microsoft.EntityFrameworkCore.Migrations;

namespace HilbertsGrandHotel_KP.Migrations
{
    public partial class dodavanjeASPUSera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aspUserId",
                table: "Sef",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aspUserId",
                table: "Recepcioner",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aspUserId",
                table: "Osoblje",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sef_aspUserId",
                table: "Sef",
                column: "aspUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcioner_aspUserId",
                table: "Recepcioner",
                column: "aspUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Osoblje_aspUserId",
                table: "Osoblje",
                column: "aspUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Osoblje_AspNetUsers_aspUserId",
                table: "Osoblje",
                column: "aspUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recepcioner_AspNetUsers_aspUserId",
                table: "Recepcioner",
                column: "aspUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sef_AspNetUsers_aspUserId",
                table: "Sef",
                column: "aspUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osoblje_AspNetUsers_aspUserId",
                table: "Osoblje");

            migrationBuilder.DropForeignKey(
                name: "FK_Recepcioner_AspNetUsers_aspUserId",
                table: "Recepcioner");

            migrationBuilder.DropForeignKey(
                name: "FK_Sef_AspNetUsers_aspUserId",
                table: "Sef");

            migrationBuilder.DropIndex(
                name: "IX_Sef_aspUserId",
                table: "Sef");

            migrationBuilder.DropIndex(
                name: "IX_Recepcioner_aspUserId",
                table: "Recepcioner");

            migrationBuilder.DropIndex(
                name: "IX_Osoblje_aspUserId",
                table: "Osoblje");

            migrationBuilder.DropColumn(
                name: "aspUserId",
                table: "Sef");

            migrationBuilder.DropColumn(
                name: "aspUserId",
                table: "Recepcioner");

            migrationBuilder.DropColumn(
                name: "aspUserId",
                table: "Osoblje");
        }
    }
}
