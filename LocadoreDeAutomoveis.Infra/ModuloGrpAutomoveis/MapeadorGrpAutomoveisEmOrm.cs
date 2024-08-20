using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoreDeAutomoveis.Infra.ModuloGrpAutomoveis
{
    public  class MapeadorGrpAutomoveisEmOrm : IEntityTypeConfiguration<GrpAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrpAutomoveis> gBuilder)
        {
            gBuilder.ToTable("TBGrpAutomoveis");

            gBuilder.Property(g => g.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            gBuilder.Property(g => g.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            gBuilder.HasData(ObterRegistrosPadrao());
        }


        private object[] ObterRegistrosPadrao()
        {
            return
            [
                new
                {
                    Id = 1,
                    Nome = "Passeio"
                },
                new
                {
                    Id = 2,
                    Nome = "Utilitário"
                },
                new
                {
                    Id = 3,
                    Nome = "Esportivo"
                }
            ];
        }
    }
}
