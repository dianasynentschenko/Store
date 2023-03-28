using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxima.DataAccess.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TovarId",
                table: "Size",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TovarId",
                table: "Size");
        }
    }
}
