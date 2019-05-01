using Microsoft.EntityFrameworkCore.Migrations;

namespace OzelDers.DAL.Migrations
{
    public partial class fiyatUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Egitmen");

            migrationBuilder.AddColumn<decimal>(
                name: "Fiyat",
                table: "AraTablo",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "AraTablo");

            migrationBuilder.AddColumn<decimal>(
                name: "Fiyat",
                table: "Egitmen",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
