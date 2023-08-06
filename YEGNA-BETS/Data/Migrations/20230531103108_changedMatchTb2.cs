using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedMatchTb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BetCodeId",
                table: "Match",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
