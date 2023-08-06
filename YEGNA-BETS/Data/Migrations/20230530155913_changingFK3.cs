using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class changingFK3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Payment_PaymentCodeId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "PaymentCodeId",
                table: "Transaction",
                newName: "TicketCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_PaymentCodeId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Ticket_TicketCodeId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "TicketCodeId",
                table: "Transaction",
                newName: "PaymentCodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_TicketCodeId",
                table: "Transaction",
                newName: "IX_Transaction_PaymentCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Payment_PaymentCodeId",
                table: "Transaction",
                column: "PaymentCodeId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
