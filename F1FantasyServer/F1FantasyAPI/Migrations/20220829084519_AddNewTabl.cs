using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class AddNewTabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixResultsModel_GrandPrix_GrandPrixId",
                table: "GrandPrixResultsModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixResultsModel_Racers_RacerId",
                table: "GrandPrixResultsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrandPrixResultsModel",
                table: "GrandPrixResultsModel");

            migrationBuilder.RenameTable(
                name: "GrandPrixResultsModel",
                newName: "GrandPrixResults");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixResultsModel_RacerId",
                table: "GrandPrixResults",
                newName: "IX_GrandPrixResults_RacerId");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixResultsModel_GrandPrixId",
                table: "GrandPrixResults",
                newName: "IX_GrandPrixResults_GrandPrixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrandPrixResults",
                table: "GrandPrixResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixResults_GrandPrix_GrandPrixId",
                table: "GrandPrixResults",
                column: "GrandPrixId",
                principalTable: "GrandPrix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixResults_Racers_RacerId",
                table: "GrandPrixResults",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixResults_GrandPrix_GrandPrixId",
                table: "GrandPrixResults");

            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixResults_Racers_RacerId",
                table: "GrandPrixResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrandPrixResults",
                table: "GrandPrixResults");

            migrationBuilder.RenameTable(
                name: "GrandPrixResults",
                newName: "GrandPrixResultsModel");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixResults_RacerId",
                table: "GrandPrixResultsModel",
                newName: "IX_GrandPrixResultsModel_RacerId");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixResults_GrandPrixId",
                table: "GrandPrixResultsModel",
                newName: "IX_GrandPrixResultsModel_GrandPrixId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrandPrixResultsModel",
                table: "GrandPrixResultsModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixResultsModel_GrandPrix_GrandPrixId",
                table: "GrandPrixResultsModel",
                column: "GrandPrixId",
                principalTable: "GrandPrix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixResultsModel_Racers_RacerId",
                table: "GrandPrixResultsModel",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
