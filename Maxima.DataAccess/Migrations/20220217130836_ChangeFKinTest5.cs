using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class ChangeFKinTest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_ProductId",
                table: "Test");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Test",
                newName: "TovarId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_ProductId",
                table: "Test",
                newName: "IX_Test_TovarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test");

            migrationBuilder.RenameColumn(
                name: "TovarId",
                table: "Test",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Test_TovarId",
                table: "Test",
                newName: "IX_Test_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_ProductId",
                table: "Test",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
