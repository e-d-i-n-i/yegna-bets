using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Ticket_TicketCodeId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "TicketCodeId",
                table: "Transaction",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TicketCodeId",
                table: "Transaction",
                newName: "IX_Transaction_TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Ticket_TicketId",
                table: "Transaction",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Ticket_TicketId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "Transaction",
                newName: "TicketCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TicketId",
                table: "Transaction",
                newName: "IX_Transaction_TicketCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Ticket_TicketCodeId",
                table: "Transaction",
                column: "TicketCodeId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
