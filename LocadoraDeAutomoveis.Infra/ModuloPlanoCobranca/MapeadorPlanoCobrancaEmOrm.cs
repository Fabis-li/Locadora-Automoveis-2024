using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaEmOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> pBuilder)
        {
            // Mapeamento da tabela
            pBuilder.ToTable("TBPlanoCobranca");

            // Configura o campo discriminador
            pBuilder.HasDiscriminator<string>("TipoPlanoCobranca")
                .HasValue<PlanoDiario>("Diario")
                .HasValue<PlanoControlado>("Controlado")
                .HasValue<PlanoLivre>("Livre");

            // Configuração das propriedades comuns
            pBuilder.Property(p => p.NomePlano)
                .IsRequired()
                .HasColumnType("varchar(100)");

            pBuilder.Property(p => p.GrupoAutomovelId)
                .IsRequired()
                .HasColumnType("int");

            pBuilder.Property(p => p.PrecoDiaria)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            pBuilder.HasMany<PlanoControlado>()
                .WithOne()
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            pBuilder.HasMany<PlanoDiario>()
                .WithOne()
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            pBuilder.HasMany<PlanoLivre>()
                .WithOne()
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            //pBuilder.Property<PlanoControlado>(p => p.KmDisponivel)
            //    .IsRequired()
            //    .HasColumnType("decimal(18,2)");




        }

    }
    
}
