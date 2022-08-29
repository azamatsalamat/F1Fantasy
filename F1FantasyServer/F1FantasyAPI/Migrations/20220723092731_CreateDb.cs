using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorLogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructorId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorLogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructorLogos_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConstructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racers_Constructors_ConstructorId",
                        column: x => x.ConstructorId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrixFileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrandPrixId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixFileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixFileModel_GrandPrix_GrandPrixId",
                        column: x => x.GrandPrixId,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstructorModelTeamModel",
                columns: table => new
                {
                    ConstructorsId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructorModelTeamModel", x => new { x.ConstructorsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_ConstructorModelTeamModel_Constructors_ConstructorsId",
                        column: x => x.ConstructorsId,
                        principalTable: "Constructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstructorModelTeamModel_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacerFileModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerFileModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacerFileModel_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacerModelTeamModel",
                columns: table => new
                {
                    RacersId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerModelTeamModel", x => new { x.RacersId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_RacerModelTeamModel_Racers_RacersId",
                        column: x => x.RacersId,
                        principalTable: "Racers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacerModelTeamModel_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorLogos_ConstructorId",
                table: "ConstructorLogos",
                column: "ConstructorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstructorModelTeamModel_TeamsId",
                table: "ConstructorModelTeamModel",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixFileModel_GrandPrixId",
                table: "GrandPrixFileModel",
                column: "GrandPrixId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RacerFileModel_RacerId",
                table: "RacerFileModel",
                column: "RacerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RacerModelTeamModel_TeamsId",
                table: "RacerModelTeamModel",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Racers_ConstructorId",
                table: "Racers",
                column: "ConstructorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructorLogos");

            migrationBuilder.DropTable(
                name: "ConstructorModelTeamModel");

            migrationBuilder.DropTable(
                name: "GrandPrixFileModel");

            migrationBuilder.DropTable(
                name: "RacerFileModel");

            migrationBuilder.DropTable(
                name: "RacerModelTeamModel");

            migrationBuilder.DropTable(
                name: "GrandPrix");

            migrationBuilder.DropTable(
                name: "Racers");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Constructors");
        }
    }
}
