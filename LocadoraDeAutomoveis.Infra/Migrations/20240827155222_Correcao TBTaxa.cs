using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeAutomoveis.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTBTaxa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoCobrancaEnum",
                table: "TBTaxa",
                newName: "TipoCobranca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoCobranca",
                table: "TBTaxa",
                newName: "TipoCobrancaEnum");
        }
    }
}
