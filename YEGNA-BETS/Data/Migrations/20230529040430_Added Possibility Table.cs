using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPossibilityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Possibility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Possibility_Match_MatchCodeId",
                        column: x => x.MatchCodeId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Possibility_MatchCodeId",
                table: "Possibility",
                column: "MatchCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Possibility");
        }
    }
}
