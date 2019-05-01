using Microsoft.EntityFrameworkCore.Migrations;

namespace OzelDers.DAL.Migrations
{
    public partial class derskonusuAdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DersKonusuAd",
                table: "AraTablo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersKonusuAd",
                table: "AraTablo");
        }
    }
}
