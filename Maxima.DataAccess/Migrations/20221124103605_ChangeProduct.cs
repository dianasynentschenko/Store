using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class ChangeProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
