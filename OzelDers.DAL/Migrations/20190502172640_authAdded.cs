using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OzelDers.DAL.Migrations
{
    public partial class authAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Egitmen",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Egitmen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoyadAd",
                table: "Egitmen",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eMail",
                table: "Egitmen",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Egitmen");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Egitmen");

            migrationBuilder.DropColumn(
                name: "SoyadAd",
                table: "Egitmen");

            migrationBuilder.DropColumn(
                name: "eMail",
                table: "Egitmen");
        }
    }
}
