using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBPlanoCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePlano = table.Column<string>(type: "varchar(100)", nullable: false),
                    GrupoAutomovelId = table.Column<int>(type: "int", nullable: false),
                    TipoPlanoCobranca = table.Column<int>(type: "int", nullable: false),
                    KmDisponivel = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoDiariaDiario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoDiariaLivre = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoDiariaControlado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoPorKm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoProKmExcedido = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecoPorkmExcedido = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    PlanoDiario_PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlanoLivre_PrecoDiaria = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrpAutomoveis_GrupoAutomovelId",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrpAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_GrupoAutomovelId",
                table: "TBPlanoCobranca",
                column: "GrupoAutomovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
