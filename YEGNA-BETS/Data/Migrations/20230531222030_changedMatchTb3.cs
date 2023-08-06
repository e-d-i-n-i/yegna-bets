using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedMatchTb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Outcome",
                table: "Match",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "Match");
        }
    }
}
