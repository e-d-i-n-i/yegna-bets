using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YEGNA_BETS.Data.Migrations
{
    /// <inheritdoc />
    public partial class fkUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_EncoderId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_AspNetUsers_UserId",
                table: "Interaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_AspNetUsers_UserId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_EncoderId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_EncoderId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_UpComingMatch_AspNetUsers_EncoderId",
                table: "UpComingMatch");

            migrationBuilder.RenameColumn(
                name: "EncoderId",
                table: "UpComingMatch",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UpComingMatch_EncoderId",
                table: "UpComingMatch",
                newName: "IX_UpComingMatch_UserId");

            migrationBuilder.RenameColumn(
                name: "EncoderId",
                table: "Ticket",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EncoderId",
                table: "Ticket",
                newName: "IX_Ticket_UserId");

            migrationBuilder.RenameColumn(
                name: "EncoderId",
                table: "News",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_News_EncoderId",
                table: "News",
                newName: "IX_News_UserId");

            migrationBuilder.RenameColumn(
                name: "EncoderId",
                table: "Club",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_EncoderId",
                table: "Club",
                newName: "IX_Club_UserId");

            migrationBuilder.AddColumn<string>(
                name: "Encoder",
                table: "UpComingMatch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Encoder",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Encoder",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Interaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Encoder",
                table: "Club",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_UserId",
                table: "Club",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_AspNetUsers_UserId",
                table: "Interaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_AspNetUsers_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UpComingMatch_AspNetUsers_UserId",
                table: "UpComingMatch",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_AspNetUsers_UserId",
                table: "Club");

            migrationBuilder.DropForeignKey(
                name: "FK_Interaction_AspNetUsers_UserId",
                table: "Interaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_AspNetUsers_UserId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_UserId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_UpComingMatch_AspNetUsers_UserId",
                table: "UpComingMatch");

            migrationBuilder.DropColumn(
                name: "Encoder",
                table: "UpComingMatch");

            migrationBuilder.DropColumn(
                name: "Encoder",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Encoder",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Encoder",
                table: "Club");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UpComingMatch",
                newName: "EncoderId");

            migrationBuilder.RenameIndex(
                name: "IX_UpComingMatch_UserId",
                table: "UpComingMatch",
                newName: "IX_UpComingMatch_EncoderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Ticket",
                newName: "EncoderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                newName: "IX_Ticket_EncoderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "EncoderId");

            migrationBuilder.RenameIndex(
                name: "IX_News_UserId",
                table: "News",
                newName: "IX_News_EncoderId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Club",
                newName: "EncoderId");

            migrationBuilder.RenameIndex(
                name: "IX_Club_UserId",
                table: "Club",
                newName: "IX_Club_EncoderId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Transaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Logs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Interaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_AspNetUsers_EncoderId",
                table: "Club",
                column: "EncoderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interaction_AspNetUsers_UserId",
                table: "Interaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_AspNetUsers_UserId",
                table: "Logs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_EncoderId",
                table: "News",
                column: "EncoderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_EncoderId",
                table: "Ticket",
                column: "EncoderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UpComingMatch_AspNetUsers_EncoderId",
                table: "UpComingMatch",
                column: "EncoderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
