using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class ChangeFKinTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "Test",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Product_TovarId",
                table: "Test",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
