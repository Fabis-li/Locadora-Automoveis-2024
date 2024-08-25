using LocadoraDeAutomoveis.Dominio.ModuloGrpAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloGrupoAutomoveis
{
    public  class MapeadorGrupoAutomovelEmOrm : IEntityTypeConfiguration<GrupoAutomovel>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomovel> gBuilder)
        {
            gBuilder.ToTable("TBGrpAutomoveis");

            gBuilder.Property(g => g.Id)
                .IsRequired()
                .HasColumnType("int")
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
