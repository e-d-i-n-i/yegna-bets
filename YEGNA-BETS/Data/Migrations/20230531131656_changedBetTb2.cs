using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedBetTb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Bet_BetId",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_BetId",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "Better",
                table: "Bet");

            migrationBuilder.AddColumn<Guid>(
                name: "BetCodeId",
                table: "Match",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "IsChecked",
                table: "Bet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Match_BetCodeId",
                table: "Match",
                column: "BetCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Bet_BetCodeId",
                table: "Match",
                column: "BetCodeId",
                principalTable: "Bet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Bet_BetCodeId",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_BetCodeId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "BetCodeId",
                table: "Match");

            migrationBuilder.AlterColumn<int>(
                name: "IsChecked",
                table: "Bet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "BetId",
                table: "Bet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Better",
                table: "Bet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_BetId",
                table: "Bet",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Bet_BetId",
                table: "Bet",
                column: "BetId",
                principalTable: "Bet",
                principalColumn: "Id");
        }
    }
}
