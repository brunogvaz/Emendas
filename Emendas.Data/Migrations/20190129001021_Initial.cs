using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emendas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empenhos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoEmpenho = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empenhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<int>(nullable: false),
                    Sigla = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoTrabalhos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoTrabalhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parlamentars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CodParlamentar = table.Column<int>(nullable: false),
                    TipoParlamentar = table.Column<int>(nullable: false),
                    PartidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parlamentars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parlamentars_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodEmenda = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    ParlamentarId = table.Column<int>(nullable: false),
                    PlanoTrabalhoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emendas_Parlamentars_ParlamentarId",
                        column: x => x.ParlamentarId,
                        principalTable: "Parlamentars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emendas_PlanoTrabalhos_PlanoTrabalhoId",
                        column: x => x.PlanoTrabalhoId,
                        principalTable: "PlanoTrabalhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmendaEmpenhos",
                columns: table => new
                {
                    EmendaId = table.Column<int>(nullable: false),
                    EmpenhoId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ValorEmpenhado = table.Column<decimal>(nullable: false),
                    ValorPago = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmendaEmpenhos", x => new { x.EmendaId, x.EmpenhoId });
                    table.ForeignKey(
                        name: "FK_EmendaEmpenhos_Empenhos_EmendaId",
                        column: x => x.EmendaId,
                        principalTable: "Empenhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmendaEmpenhos_Emendas_EmpenhoId",
                        column: x => x.EmpenhoId,
                        principalTable: "Emendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmendaEmpenhos_EmpenhoId",
                table: "EmendaEmpenhos",
                column: "EmpenhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Emendas_ParlamentarId",
                table: "Emendas",
                column: "ParlamentarId");

            migrationBuilder.CreateIndex(
                name: "IX_Emendas_PlanoTrabalhoId",
                table: "Emendas",
                column: "PlanoTrabalhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parlamentars_PartidoId",
                table: "Parlamentars",
                column: "PartidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "EmendaEmpenhos");

            migrationBuilder.DropTable(
                name: "Empenhos");

            migrationBuilder.DropTable(
                name: "Emendas");

            migrationBuilder.DropTable(
                name: "Parlamentars");

            migrationBuilder.DropTable(
                name: "PlanoTrabalhos");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
