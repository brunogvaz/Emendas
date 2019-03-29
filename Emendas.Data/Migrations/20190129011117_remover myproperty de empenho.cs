using Microsoft.EntityFrameworkCore.Migrations;

namespace Emendas.Data.Migrations
{
    public partial class removermypropertydeempenho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Empenhos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmendaEmpenhos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Empenhos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmendaEmpenhos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
