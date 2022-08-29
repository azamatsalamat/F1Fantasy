using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixFileModel_GrandPrix_GrandPrixId",
                table: "GrandPrixFileModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RacerFileModel_Racers_RacerId",
                table: "RacerFileModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RacerFileModel",
                table: "RacerFileModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrandPrixFileModel",
                table: "GrandPrixFileModel");

            migrationBuilder.RenameTable(
                name: "RacerFileModel",
                newName: "RacerImages");

            migrationBuilder.RenameTable(
                name: "GrandPrixFileModel",
                newName: "GrandPrixFlags");

            migrationBuilder.RenameIndex(
                name: "IX_RacerFileModel_RacerId",
                table: "RacerImages",
                newName: "IX_RacerImages_RacerId");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixFileModel_GrandPrixId",
                table: "GrandPrixFlags",
                newName: "IX_GrandPrixFlags_GrandPrixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RacerImages",
                table: "RacerImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrandPrixFlags",
                table: "GrandPrixFlags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixFlags_GrandPrix_GrandPrixId",
                table: "GrandPrixFlags",
                column: "GrandPrixId",
                principalTable: "GrandPrix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacerImages_Racers_RacerId",
                table: "RacerImages",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixFlags_GrandPrix_GrandPrixId",
                table: "GrandPrixFlags");

            migrationBuilder.DropForeignKey(
                name: "FK_RacerImages_Racers_RacerId",
                table: "RacerImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RacerImages",
                table: "RacerImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrandPrixFlags",
                table: "GrandPrixFlags");

            migrationBuilder.RenameTable(
                name: "RacerImages",
                newName: "RacerFileModel");

            migrationBuilder.RenameTable(
                name: "GrandPrixFlags",
                newName: "GrandPrixFileModel");

            migrationBuilder.RenameIndex(
                name: "IX_RacerImages_RacerId",
                table: "RacerFileModel",
                newName: "IX_RacerFileModel_RacerId");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixFlags_GrandPrixId",
                table: "GrandPrixFileModel",
                newName: "IX_GrandPrixFileModel_GrandPrixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RacerFileModel",
                table: "RacerFileModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrandPrixFileModel",
                table: "GrandPrixFileModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixFileModel_GrandPrix_GrandPrixId",
                table: "GrandPrixFileModel",
                column: "GrandPrixId",
                principalTable: "GrandPrix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacerFileModel_Racers_RacerId",
                table: "RacerFileModel",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
