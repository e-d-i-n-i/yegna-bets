using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changedPatternsTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Pattern",
                newName: "Timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Pattern",
                newName: "FullName");
        }
    }
}
