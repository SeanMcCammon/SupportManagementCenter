using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class CorrispondenceAddMigrationGetSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketCorrespondenceModel",
                columns: table => new
                {
                    CorrispondenceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    SupportTicketModelTicketId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCorrespondenceModel", x => x.CorrispondenceId);
                    table.ForeignKey(
                        name: "FK_TicketCorrespondenceModel_supportTickets_SupportTicketModelTicketId",
                        column: x => x.SupportTicketModelTicketId,
                        principalTable: "supportTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketCorrespondenceModel_SupportTicketModelTicketId",
                table: "TicketCorrespondenceModel",
                column: "SupportTicketModelTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketCorrespondenceModel");
        }
    }
}
