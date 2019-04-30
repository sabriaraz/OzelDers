using Microsoft.EntityFrameworkCore.Migrations;

namespace OzelDers.DAL.Migrations
{
    public partial class iki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Egitmen_DersKonusu_DersKonusuId",
                table: "Egitmen");

            migrationBuilder.DropIndex(
                name: "IX_Egitmen_DersKonusuId",
                table: "Egitmen");

            migrationBuilder.DropColumn(
                name: "DersKonusuId",
                table: "Egitmen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DersKonusuId",
                table: "Egitmen",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Egitmen_DersKonusuId",
                table: "Egitmen",
                column: "DersKonusuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Egitmen_DersKonusu_DersKonusuId",
                table: "Egitmen",
                column: "DersKonusuId",
                principalTable: "DersKonusu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
