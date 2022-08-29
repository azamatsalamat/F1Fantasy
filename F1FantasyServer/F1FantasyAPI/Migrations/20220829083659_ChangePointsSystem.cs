using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class ChangePointsSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrandPrixModelRacerModel");

            migrationBuilder.AddColumn<int>(
                name: "RacerModelId",
                table: "GrandPrix",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GrandPrixResultsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrandPrixId = table.Column<int>(type: "int", nullable: false),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixResultsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixResultsModel_GrandPrix_GrandPrixId",
                        column: x => x.GrandPrixId,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrixResultsModel_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_RacerModelId",
                table: "GrandPrix",
                column: "RacerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixResultsModel_GrandPrixId",
                table: "GrandPrixResultsModel",
                column: "GrandPrixId");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixResultsModel_RacerId",
                table: "GrandPrixResultsModel",
                column: "RacerId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_Racers_RacerModelId",
                table: "GrandPrix",
                column: "RacerModelId",
                principalTable: "Racers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_Racers_RacerModelId",
                table: "GrandPrix");

            migrationBuilder.DropTable(
                name: "GrandPrixResultsModel");

            migrationBuilder.DropIndex(
                name: "IX_GrandPrix_RacerModelId",
                table: "GrandPrix");

            migrationBuilder.DropColumn(
                name: "RacerModelId",
                table: "GrandPrix");

            migrationBuilder.CreateTable(
                name: "GrandPrixModelRacerModel",
                columns: table => new
                {
                    GrandPrixId = table.Column<int>(type: "int", nullable: false),
                    ResultsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixModelRacerModel", x => new { x.GrandPrixId, x.ResultsId });
                    table.ForeignKey(
                        name: "FK_GrandPrixModelRacerModel_GrandPrix_GrandPrixId",
                        column: x => x.GrandPrixId,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrixModelRacerModel_Racers_ResultsId",
                        column: x => x.ResultsId,
                        principalTable: "Racers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixModelRacerModel_ResultsId",
                table: "GrandPrixModelRacerModel",
                column: "ResultsId");
        }
    }
}
