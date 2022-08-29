using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class AddTeamResult3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_Teams_TeamModelId",
                table: "GrandPrix");

            migrationBuilder.DropIndex(
                name: "IX_GrandPrix_TeamModelId",
                table: "GrandPrix");

            migrationBuilder.DropColumn(
                name: "TeamModelId",
                table: "GrandPrix");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamModelId",
                table: "GrandPrix",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_TeamModelId",
                table: "GrandPrix",
                column: "TeamModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_Teams_TeamModelId",
                table: "GrandPrix",
                column: "TeamModelId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
