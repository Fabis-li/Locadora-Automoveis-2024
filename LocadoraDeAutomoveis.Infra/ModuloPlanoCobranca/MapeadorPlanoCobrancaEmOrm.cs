using LocadoraDeAutomoveis.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloPlanoCobranca
{
    public class MapeadorPlanoCobrancaEmOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> pBuilder)
        {
            pBuilder.ToTable("TBPlanoCobranca");

            // Configura o campo discriminador
            pBuilder.HasDiscriminator<string>("TipoPlanoCobranca")
                .HasValue<PlanoDiario>("Diario")
                .HasValue<PlanoControlado>("Controlado")
                .HasValue<PlanoLivre>("Livre");

            //Configuração das propriedades comuns
           pBuilder.Property(p => p.NomePlano)
               .IsRequired()
               .HasColumnType("varchar(100)");

           pBuilder.Property(p => p.GrupoAutomovelId)
               .IsRequired()
               .HasColumnType("int");

            pBuilder.HasOne(p => p.GrupoAutomoveis)
                .WithMany(g => g.PlanosCobranca)
                .HasForeignKey(p => p.GrupoAutomovelId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração das propriedades específicas
            pBuilder.HasKey(p => p.Id);

            //Configurações para PlanoControlado
            pBuilder.Property<PlanoControlado>(p => p.KmDisponivel)
                .HasColumnName("KmDisponivel")
                .HasColumnType("decimal(18,2)");







        }
    }
}
