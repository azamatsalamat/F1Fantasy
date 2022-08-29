using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1FantasyAPI.Migrations
{
    public partial class AddCosts3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Constructors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Constructors");
        }
    }
}
