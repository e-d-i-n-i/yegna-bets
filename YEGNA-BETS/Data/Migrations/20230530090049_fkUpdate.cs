using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class fkUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_BetterId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_AspNetUsers_EncoderId",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "EncoderId",
                table: "Package",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_EncoderId",
                table: "Package",
                newName: "IX_Package_UserId");

            migrationBuilder.RenameColumn(
                name: "BetterId",
                table: "Bet",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_BetterId",
                table: "Bet",
                newName: "IX_Bet_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Encoder",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Better",
                table: "Bet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_AspNetUsers_UserId",
                table: "Package",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_UserId",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_AspNetUsers_UserId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Encoder",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Better",
                table: "Bet");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Package",
                newName: "EncoderId");

            migrationBuilder.RenameIndex(
                name: "IX_Package_UserId",
                table: "Package",
                newName: "IX_Package_EncoderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bet",
                newName: "BetterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserId",
                table: "Bet",
                newName: "IX_Bet_BetterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_BetterId",
                table: "Bet",
                column: "BetterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_AspNetUsers_EncoderId",
                table: "Package",
                column: "EncoderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
