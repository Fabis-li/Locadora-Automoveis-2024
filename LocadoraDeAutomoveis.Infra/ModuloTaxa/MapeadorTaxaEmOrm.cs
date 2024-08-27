using LocadoraDeAutomoveis.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloTaxa
{
    public class MapeadorTaxaEmOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> tBuilder)
        {
            tBuilder.ToTable("TBTaxa");

            tBuilder.Property(t => t.Id)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            tBuilder.Property(t => t.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            tBuilder.Property(t => t.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            tBuilder.Property(t => t.TipoCobrancaEnum)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
