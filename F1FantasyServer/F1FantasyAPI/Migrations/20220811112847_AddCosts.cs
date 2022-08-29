using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class AddCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "GrandPrix");

            migrationBuilder.AddColumn<double>(
                name: "CashAvailable",
                table: "Teams",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Racers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrandPrixModelRacerModel");

            migrationBuilder.DropColumn(
                name: "CashAvailable",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Racers");

            migrationBuilder.AddColumn<string>(
                name: "Results",
                table: "GrandPrix",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
