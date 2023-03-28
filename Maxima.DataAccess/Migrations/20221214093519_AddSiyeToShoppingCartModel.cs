using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class AddSiyeToShoppingCartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalImg_Product_TovarId",
                table: "AdditionalImg");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "AdditionalImg",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalImg_Product_TovarId",
                table: "AdditionalImg",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalImg_Product_TovarId",
                table: "AdditionalImg");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "TovarId",
                table: "AdditionalImg",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalImg_Product_TovarId",
                table: "AdditionalImg",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
