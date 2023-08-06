using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUpComingMatchesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpComingMatch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwayTeam = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EncoderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpComingMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpComingMatch_AspNetUsers_EncoderId",
                        column: x => x.EncoderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpComingMatch_EncoderId",
                table: "UpComingMatch",
                column: "EncoderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpComingMatch");
        }
    }
}
