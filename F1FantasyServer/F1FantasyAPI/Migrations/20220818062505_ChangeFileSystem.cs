using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class ChangeFileSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "RacerImages");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "GrandPrixFlags");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "ConstructorLogos");

            migrationBuilder.AddColumn<string>(
                name: "StorageName",
                table: "RacerImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "RacerImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorageName",
                table: "GrandPrixFlags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "GrandPrixFlags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StorageName",
                table: "ConstructorLogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ConstructorLogos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageName",
                table: "RacerImages");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "RacerImages");

            migrationBuilder.DropColumn(
                name: "StorageName",
                table: "GrandPrixFlags");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "GrandPrixFlags");

            migrationBuilder.DropColumn(
                name: "StorageName",
                table: "ConstructorLogos");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "ConstructorLogos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "RacerImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "GrandPrixFlags",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "ConstructorLogos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
