using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class TBAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CondutorId = table.Column<int>(type: "int", nullable: false),
                    AutomovelId = table.Column<int>(type: "int", nullable: false),
                    PlanoCobrancaId = table.Column<int>(type: "int", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRetorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBAutomovel_AutomovelId",
                        column: x => x.AutomovelId,
                        principalTable: "TBAutomovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_AutomovelId",
                table: "TBAluguel",
                column: "AutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CondutorId",
                table: "TBAluguel",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_PlanoCobrancaId",
                table: "TBAluguel",
                column: "PlanoCobrancaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAluguel");
        }
    }
}
