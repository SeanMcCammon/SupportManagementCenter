using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class AddedTicketStatusHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCorrespondenceModel_supportTickets_SupportTicketModelTicketId",
                table: "TicketCorrespondenceModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCorrespondenceModel",
                table: "TicketCorrespondenceModel");

            migrationBuilder.RenameTable(
                name: "TicketCorrespondenceModel",
                newName: "TicketCorrespondence");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCorrespondenceModel_SupportTicketModelTicketId",
                table: "TicketCorrespondence",
                newName: "IX_TicketCorrespondence_SupportTicketModelTicketId");

            migrationBuilder.AlterColumn<string>(
                name: "TicketTitle",
                table: "supportTickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketDetails",
                table: "supportTickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "supportTickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCorrespondence",
                table: "TicketCorrespondence",
                column: "CorrispondenceId");

            migrationBuilder.CreateTable(
                name: "TicketHistories",
                columns: table => new
                {
                    TicketHistoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(nullable: false),
                    StatusUpdateDate = table.Column<DateTime>(nullable: false),
                    StatusUpdateTitle = table.Column<string>(nullable: true),
                    StatusUpdateDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHistories", x => x.TicketHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatus",
                columns: table => new
                {
                    StatusId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketStatusType = table.Column<string>(nullable: false),
                    SupportTicketModelTicketId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatus", x => x.StatusId);
                    table.ForeignKey(
                        name: "FK_TicketStatus_supportTickets_SupportTicketModelTicketId",
                        column: x => x.SupportTicketModelTicketId,
                        principalTable: "supportTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatus_SupportTicketModelTicketId",
                table: "TicketStatus",
                column: "SupportTicketModelTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCorrespondence_supportTickets_SupportTicketModelTicketId",
                table: "TicketCorrespondence",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketCorrespondence_supportTickets_SupportTicketModelTicketId",
                table: "TicketCorrespondence");

            migrationBuilder.DropTable(
                name: "TicketHistories");

            migrationBuilder.DropTable(
                name: "TicketStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketCorrespondence",
                table: "TicketCorrespondence");

            migrationBuilder.RenameTable(
                name: "TicketCorrespondence",
                newName: "TicketCorrespondenceModel");

            migrationBuilder.RenameIndex(
                name: "IX_TicketCorrespondence_SupportTicketModelTicketId",
                table: "TicketCorrespondenceModel",
                newName: "IX_TicketCorrespondenceModel_SupportTicketModelTicketId");

            migrationBuilder.AlterColumn<string>(
                name: "TicketTitle",
                table: "supportTickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "TicketDetails",
                table: "supportTickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerEmail",
                table: "supportTickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketCorrespondenceModel",
                table: "TicketCorrespondenceModel",
                column: "CorrispondenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketCorrespondenceModel_supportTickets_SupportTicketModelTicketId",
                table: "TicketCorrespondenceModel",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
