using Microsoft.EntityFrameworkCore.Migrations;

namespace Emendas.Data.Migrations
{
    public partial class consertarmerdafk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmendaEmpenhos_Empenhos_EmendaId",
                table: "EmendaEmpenhos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmendaEmpenhos_Emendas_EmpenhoId",
                table: "EmendaEmpenhos");

            migrationBuilder.AddForeignKey(
                name: "FK_EmendaEmpenhos_Emendas_EmendaId",
                table: "EmendaEmpenhos",
                column: "EmendaId",
                principalTable: "Emendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmendaEmpenhos_Empenhos_EmpenhoId",
                table: "EmendaEmpenhos",
                column: "EmpenhoId",
                principalTable: "Empenhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmendaEmpenhos_Emendas_EmendaId",
                table: "EmendaEmpenhos");

            migrationBuilder.DropForeignKey(
                name: "FK_EmendaEmpenhos_Empenhos_EmpenhoId",
                table: "EmendaEmpenhos");

            migrationBuilder.AddForeignKey(
                name: "FK_EmendaEmpenhos_Empenhos_EmendaId",
                table: "EmendaEmpenhos",
                column: "EmendaId",
                principalTable: "Empenhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmendaEmpenhos_Emendas_EmpenhoId",
                table: "EmendaEmpenhos",
                column: "EmpenhoId",
                principalTable: "Emendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
