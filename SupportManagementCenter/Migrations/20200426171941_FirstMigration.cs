using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "supportTickets",
                columns: table => new
                {
                    TicketId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(nullable: false),
                    TicketTitle = table.Column<string>(nullable: true),
                    TicketDetails = table.Column<string>(nullable: true),
                    DateRaised = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supportTickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesModel",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    ProductExpertise = table.Column<string>(nullable: true),
                    SupportTicketModelTicketId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesModel", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeesModel_supportTickets_SupportTicketModelTicketId",
                        column: x => x.SupportTicketModelTicketId,
                        principalTable: "supportTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsModel",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ProduceDescription = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SupportTicketModelTicketId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsModel", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductsModel_supportTickets_SupportTicketModelTicketId",
                        column: x => x.SupportTicketModelTicketId,
                        principalTable: "supportTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesModel_SupportTicketModelTicketId",
                table: "EmployeesModel",
                column: "SupportTicketModelTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsModel_SupportTicketModelTicketId",
                table: "ProductsModel",
                column: "SupportTicketModelTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesModel");

            migrationBuilder.DropTable(
                name: "ProductsModel");

            migrationBuilder.DropTable(
                name: "supportTickets");
        }
    }
}
