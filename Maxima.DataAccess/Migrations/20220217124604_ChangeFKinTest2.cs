using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class ChangeFKinTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Test_ProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Test",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_ProductId",
                table: "Test",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_ProductId",
                table: "Test",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_ProductId",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_ProductId",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Test");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId",
                table: "Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Test_ProductId",
                table: "Product",
                column: "ProductId",
                principalTable: "Test",
                principalColumn: "Id");
        }
    }
}
