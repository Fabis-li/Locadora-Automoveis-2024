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
            pBuilder.HasDiscriminator<TipoPlanoCobranca>("TipoPlanoCobranca")
                .HasValue<PlanoDiario>(TipoPlanoCobranca.Diario)
                .HasValue<PlanoControlado>(TipoPlanoCobranca.Controlado) 
                .HasValue<PlanoLivre>(TipoPlanoCobranca.Livre);

            // Configuração das propriedades comuns
            pBuilder.Property(p => p.NomePlano)
                .IsRequired()
                .HasColumnType("varchar(100)");

            pBuilder.Property(p => p.GrupoAutomovelId)
                .IsRequired()
                .HasColumnType("int");

            pBuilder.Property(p => p.TipoPlanoCobranca)
                .IsRequired()
                .HasColumnName("TipoPlanoCobranca")
                .HasColumnType("int");

            pBuilder.HasOne(p => p.GrupoAutomoveis)
                .WithMany(g => g.PlanosCobranca)
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações específicas para cada tipo derivado
            pBuilder.HasKey(e => e.Id);

            // Configurações para PlanoControlado
            pBuilder.Property<decimal?>("KmDisponivel")
                .HasColumnName("KmDisponivel")
                .HasPrecision(18, 2);

            pBuilder.Property<decimal?>("PrecoDiarioControlado")
                .HasColumnName("PrecoDiariaControlado")
                .HasPrecision(18, 2);

            pBuilder.Property<decimal?>("PrecoProKmExcedido")
                .HasColumnName("PrecoProKmExcedido")
                .HasPrecision(18, 2);

            // Configurações para PlanoDiario
            pBuilder.Property<decimal?>("PrecoDiariaDiario")
                .HasColumnName("PrecoDiariaDiario")
                .HasPrecision(18, 2);

            pBuilder.Property<decimal?>("PrecoPorKm")
                .HasColumnName("PrecoPorKm")
                .HasPrecision(18, 2);

            // Configurações para PlanoLivre
            pBuilder.Property<decimal?>("PrecoDiariaLivre")
                .HasColumnName("PrecoDiariaLivre")
                .HasPrecision(18, 2);
        }

    }
    
}
