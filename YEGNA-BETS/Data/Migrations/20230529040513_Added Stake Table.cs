using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStakeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stake",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalOdds = table.Column<double>(type: "float", nullable: false),
                    Probability = table.Column<double>(type: "float", nullable: false),
                    PayOut = table.Column<double>(type: "float", nullable: false),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Luck = table.Column<double>(type: "float", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stake_Possibility_WagerId",
                        column: x => x.WagerId,
                        principalTable: "Possibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stake_WagerId",
                table: "Stake",
                column: "WagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stake");
        }
    }
}
