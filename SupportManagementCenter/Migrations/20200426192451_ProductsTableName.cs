using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagementCenter.Migrations
{
    public partial class ProductsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsId",
                table: "ProductsId");

            migrationBuilder.RenameTable(
                name: "ProductsId",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsId",
                table: "ProductsId",
                column: "ProductId");
        }
    }
}
