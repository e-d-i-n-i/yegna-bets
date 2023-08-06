using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Package");

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
