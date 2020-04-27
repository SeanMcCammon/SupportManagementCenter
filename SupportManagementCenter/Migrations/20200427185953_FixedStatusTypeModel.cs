using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class FixedStatusTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatus_supportTickets_SupportTicketModelTicketId",
                table: "TicketStatus");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatus_SupportTicketModelTicketId",
                table: "TicketStatus");

            migrationBuilder.DropColumn(
                name: "SupportTicketModelTicketId",
                table: "TicketStatus");

            migrationBuilder.AddColumn<long>(
                name: "SupportTicketModelTicketId",
                table: "TicketHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketHistories_SupportTicketModelTicketId",
                table: "TicketHistories",
                column: "SupportTicketModelTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketHistories_supportTickets_SupportTicketModelTicketId",
                table: "TicketHistories",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketHistories_supportTickets_SupportTicketModelTicketId",
                table: "TicketHistories");

            migrationBuilder.DropIndex(
                name: "IX_TicketHistories_SupportTicketModelTicketId",
                table: "TicketHistories");

            migrationBuilder.DropColumn(
                name: "SupportTicketModelTicketId",
                table: "TicketHistories");

            migrationBuilder.AddColumn<long>(
                name: "SupportTicketModelTicketId",
                table: "TicketStatus",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatus_SupportTicketModelTicketId",
                table: "TicketStatus",
                column: "SupportTicketModelTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatus_supportTickets_SupportTicketModelTicketId",
                table: "TicketStatus",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
