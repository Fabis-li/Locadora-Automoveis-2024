using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrpAutomoveisId",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "GrpAutomoveisId",
                table: "TBAutomovel",
                newName: "GrupoAutomovelId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomovel_GrpAutomoveisId",
                table: "TBAutomovel",
                newName: "IX_TBAutomovel_GrupoAutomovelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "GrupoAutomovelId",
                table: "TBAutomovel",
                newName: "GrpAutomoveisId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomovel_GrupoAutomovelId",
                table: "TBAutomovel",
                newName: "IX_TBAutomovel_GrpAutomoveisId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrpAutomoveisId",
                table: "TBAutomovel",
                column: "GrpAutomoveisId",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id");
        }
    }
}
