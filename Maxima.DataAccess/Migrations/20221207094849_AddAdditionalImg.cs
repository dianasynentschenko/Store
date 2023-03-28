using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class AddAdditionalImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.CreateTable(
                name: "AdditionalImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TovarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalImg_Product_TovarId",
                        column: x => x.TovarId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_TovarId",
                table: "Size",
                column: "TovarId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalImg_TovarId",
                table: "AdditionalImg",
                column: "TovarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Size_Product_TovarId",
                table: "Size",
                column: "TovarId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Size_Product_TovarId",
                table: "Size");

            migrationBuilder.DropTable(
                name: "AdditionalImg");

            migrationBuilder.DropIndex(
                name: "IX_Size_TovarId",
                table: "Size");

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplaySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TestSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TovarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_Product_TovarId",
                        column: x => x.TovarId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Test_TovarId",
                table: "Test",
                column: "TovarId");
        }
    }
}
