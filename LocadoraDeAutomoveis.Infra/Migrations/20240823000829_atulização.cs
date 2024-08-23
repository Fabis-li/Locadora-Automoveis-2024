using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class atulização : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovel_Id",
                table: "TBAutomovel");

            migrationBuilder.DropIndex(
                name: "IX_TBAutomovel_GrupoAutomovel_Id",
                table: "TBAutomovel");

            migrationBuilder.DropColumn(
                name: "Combustivel",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "GrupoAutomovel_Id",
                table: "TBAutomovel",
                newName: "TipoCombustivel");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoAutomovelId",
                table: "TBAutomovel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
                principalTable: "TBGrpAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivel",
                table: "TBAutomovel",
                newName: "GrupoAutomovel_Id");

            migrationBuilder.AlterColumn<int>(
                name: "GrupoAutomovelId",
                table: "TBAutomovel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Combustivel",
                table: "TBAutomovel",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrupoAutomovel_Id",
                table: "TBAutomovel",
                column: "GrupoAutomovel_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomovel_TBGrpAutomoveis_GrupoAutomovelId",
                table: "TBAutomovel",
                column: "GrupoAutomovelId",
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
    }
}
