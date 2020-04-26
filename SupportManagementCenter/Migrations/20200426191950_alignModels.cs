using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class alignModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesModel_supportTickets_SupportTicketModelTicketId",
                table: "EmployeesModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsModel_supportTickets_SupportTicketModelTicketId",
                table: "ProductsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsModel",
                table: "ProductsModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductsModel_SupportTicketModelTicketId",
                table: "ProductsModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesModel",
                table: "EmployeesModel");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesModel_SupportTicketModelTicketId",
                table: "EmployeesModel");

            migrationBuilder.DropColumn(
                name: "SupportTicketModelTicketId",
                table: "ProductsModel");

            migrationBuilder.DropColumn(
                name: "SupportTicketModelTicketId",
                table: "EmployeesModel");

            migrationBuilder.RenameTable(
                name: "ProductsModel",
                newName: "ProductsId");

            migrationBuilder.RenameTable(
                name: "EmployeesModel",
                newName: "AssignedEmployee");

            migrationBuilder.AddColumn<long>(
                name: "AssignedEmployeeId",
                table: "supportTickets",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsId",
                table: "ProductsId",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedEmployee",
                table: "AssignedEmployee",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsId",
                table: "ProductsId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedEmployee",
                table: "AssignedEmployee");

            migrationBuilder.DropColumn(
                name: "AssignedEmployeeId",
                table: "supportTickets");

            migrationBuilder.RenameTable(
                name: "ProductsId",
                newName: "ProductsModel");

            migrationBuilder.RenameTable(
                name: "AssignedEmployee",
                newName: "EmployeesModel");

            migrationBuilder.AddColumn<long>(
                name: "SupportTicketModelTicketId",
                table: "ProductsModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "SupportTicketModelTicketId",
                table: "EmployeesModel",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsModel",
                table: "ProductsModel",
                column: "ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesModel",
                table: "EmployeesModel",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsModel_SupportTicketModelTicketId",
                table: "ProductsModel",
                column: "SupportTicketModelTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesModel_SupportTicketModelTicketId",
                table: "EmployeesModel",
                column: "SupportTicketModelTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesModel_supportTickets_SupportTicketModelTicketId",
                table: "EmployeesModel",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsModel_supportTickets_SupportTicketModelTicketId",
                table: "ProductsModel",
                column: "SupportTicketModelTicketId",
                principalTable: "supportTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
