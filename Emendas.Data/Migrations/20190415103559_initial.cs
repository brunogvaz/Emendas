using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Emendas.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoEmpenho = table.Column<string>(nullable: true)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodEmenda = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorBloqueado = table.Column<decimal>(nullable: false),
                    ValorIndicado = table.Column<decimal>(nullable: false),
                    ValorPriorizado = table.Column<decimal>(nullable: false),
                    ValorImpedido = table.Column<decimal>(nullable: false),
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
                    BeneficiarioId = table.Column<int>(nullable: false),
                    ValorEmpenhado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmendaEmpenhos", x => new { x.EmendaId, x.EmpenhoId, x.BeneficiarioId });
                    table.ForeignKey(
                        name: "FK_EmendaEmpenhos_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmendaEmpenhos_Emendas_EmendaId",
                        column: x => x.EmendaId,
                        principalTable: "Emendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmendaEmpenhos_Empenhos_EmpenhoId",
                        column: x => x.EmpenhoId,
                        principalTable: "Empenhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmendaEmpenhos_BeneficiarioId",
                table: "EmendaEmpenhos",
                column: "BeneficiarioId");

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
                name: "EmendaEmpenhos");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Emendas");

            migrationBuilder.DropTable(
                name: "Empenhos");

            migrationBuilder.DropTable(
                name: "Parlamentars");

            migrationBuilder.DropTable(
                name: "PlanoTrabalhos");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
