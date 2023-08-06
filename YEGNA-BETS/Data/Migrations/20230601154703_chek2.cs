using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class chek2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Stake_Bet_BetCodeId",
                table: "Stake");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUser",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ApplicationUser",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "BetCodeId",
                table: "Stake",
                newName: "BetId");

            migrationBuilder.RenameIndex(
                name: "IX_Stake_BetCodeId",
                table: "Stake",
                newName: "IX_Stake_BetId");

            migrationBuilder.RenameColumn(
                name: "betCode",
                table: "Match",
                newName: "BetId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Stake",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "stakeCode",
                table: "Possibility",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stake_Bet_BetId",
                table: "Stake",
                column: "BetId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Stake_Bet_BetId",
                table: "Stake");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stake");

            migrationBuilder.DropColumn(
                name: "stakeCode",
                table: "Possibility");

            migrationBuilder.RenameColumn(
                name: "BetId",
                table: "Stake",
                newName: "BetCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Stake_BetId",
                table: "Stake",
                newName: "IX_Stake_BetCodeId");

            migrationBuilder.RenameColumn(
                name: "BetId",
                table: "Match",
                newName: "betCode");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ApplicationUser",
                table: "Transaction",
                column: "ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stake_Bet_BetCodeId",
                table: "Stake",
                column: "BetCodeId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_ApplicationUser",
                table: "Transaction",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
