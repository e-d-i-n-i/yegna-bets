using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedPossiblity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibility_Match_MatchCodeId",
                table: "Possibility");

            migrationBuilder.RenameColumn(
                name: "MatchCodeId",
                table: "Possibility",
                newName: "BetCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibility_MatchCodeId",
                table: "Possibility",
                newName: "IX_Possibility_BetCodeId");

            migrationBuilder.AddColumn<string>(
                name: "AwayTeam",
                table: "Possibility",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTeam",
                table: "Possibility",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "OddForAwayTeam",
                table: "Possibility",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OddForDraw",
                table: "Possibility",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OddForHomeTeam",
                table: "Possibility",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Bet_BetCodeId",
                table: "Possibility",
                column: "BetCodeId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibility_Bet_BetCodeId",
                table: "Possibility");

            migrationBuilder.DropColumn(
                name: "AwayTeam",
                table: "Possibility");

            migrationBuilder.DropColumn(
                name: "HomeTeam",
                table: "Possibility");

            migrationBuilder.DropColumn(
                name: "OddForAwayTeam",
                table: "Possibility");

            migrationBuilder.DropColumn(
                name: "OddForDraw",
                table: "Possibility");

            migrationBuilder.DropColumn(
                name: "OddForHomeTeam",
                table: "Possibility");

            migrationBuilder.RenameColumn(
                name: "BetCodeId",
                table: "Possibility",
                newName: "MatchCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibility_BetCodeId",
                table: "Possibility",
                newName: "IX_Possibility_MatchCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Match_MatchCodeId",
                table: "Possibility",
                column: "MatchCodeId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
