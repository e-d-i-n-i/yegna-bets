using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedPossiblityStakeTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibility_Bet_BetCodeId",
                table: "Possibility");

            migrationBuilder.DropForeignKey(
                name: "FK_Stake_Possibility_WagerId",
                table: "Stake");

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
                name: "WagerId",
                table: "Stake",
                newName: "BetCodeId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Stake",
                newName: "IsWinner");

            migrationBuilder.RenameIndex(
                name: "IX_Stake_WagerId",
                table: "Stake",
                newName: "IX_Stake_BetCodeId");

            migrationBuilder.RenameColumn(
                name: "BetCodeId",
                table: "Possibility",
                newName: "StakeCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibility_BetCodeId",
                table: "Possibility",
                newName: "IX_Possibility_StakeCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Stake_StakeCodeId",
                table: "Possibility",
                column: "StakeCodeId",
                principalTable: "Stake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stake_Bet_BetCodeId",
                table: "Stake",
                column: "BetCodeId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possibility_Stake_StakeCodeId",
                table: "Possibility");

            migrationBuilder.DropForeignKey(
                name: "FK_Stake_Bet_BetCodeId",
                table: "Stake");

            migrationBuilder.RenameColumn(
                name: "IsWinner",
                table: "Stake",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "BetCodeId",
                table: "Stake",
                newName: "WagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Stake_BetCodeId",
                table: "Stake",
                newName: "IX_Stake_WagerId");

            migrationBuilder.RenameColumn(
                name: "StakeCodeId",
                table: "Possibility",
                newName: "BetCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Possibility_StakeCodeId",
                table: "Possibility",
                newName: "IX_Possibility_BetCodeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Stake_Possibility_WagerId",
                table: "Stake",
                column: "WagerId",
                principalTable: "Possibility",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
