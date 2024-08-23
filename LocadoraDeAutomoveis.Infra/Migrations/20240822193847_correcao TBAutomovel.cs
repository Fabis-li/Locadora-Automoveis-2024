using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class correcaoTBAutomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_Automovel_Id",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "Automovel_Id",
                table: "TBAutomovel",
                newName: "GrupoAutomovel_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomovel_Automovel_Id",
                table: "TBAutomovel",
                newName: "IX_TBAutomovel_GrupoAutomovel_Id");

            migrationBuilder.AddColumn<int>(
                name: "GrpAutomoveisId",
                table: "TBAutomovel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrpAutomoveisId",
                table: "TBAutomovel",
                column: "GrpAutomoveisId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrpAutomoveisId",
                table: "TBAutomovel",
                column: "GrpAutomoveisId",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovel_Id",
                table: "TBAutomovel",
                column: "GrupoAutomovel_Id",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrpAutomoveisId",
                table: "TBAutomovel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovel_Id",
                table: "TBAutomovel");

            migrationBuilder.DropIndex(
                name: "IX_TBAutomovel_GrpAutomoveisId",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "GrpAutomoveisId",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "GrupoAutomovel_Id",
                table: "TBAutomovel",
                newName: "Automovel_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomovel_GrupoAutomovel_Id",
                table: "TBAutomovel",
                newName: "IX_TBAutomovel_Automovel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_Automovel_Id",
                table: "TBAutomovel",
                column: "Automovel_Id",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
