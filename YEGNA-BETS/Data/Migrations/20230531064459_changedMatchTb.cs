using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedMatchTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Team2",
                table: "Match",
                newName: "HomeTeam");

            migrationBuilder.RenameColumn(
                name: "Team1",
                table: "Match",
                newName: "AwayTeam");

            migrationBuilder.RenameColumn(
                name: "OddForTeam2",
                table: "Match",
                newName: "OddForHomeTeam");

            migrationBuilder.RenameColumn(
                name: "OddForTeam1",
                table: "Match",
                newName: "OddForAwayTeam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OddForHomeTeam",
                table: "Match",
                newName: "OddForTeam2");

            migrationBuilder.RenameColumn(
                name: "OddForAwayTeam",
                table: "Match",
                newName: "OddForTeam1");

            migrationBuilder.RenameColumn(
                name: "HomeTeam",
                table: "Match",
                newName: "Team2");

            migrationBuilder.RenameColumn(
                name: "AwayTeam",
                table: "Match",
                newName: "Team1");
        }
    }
}
