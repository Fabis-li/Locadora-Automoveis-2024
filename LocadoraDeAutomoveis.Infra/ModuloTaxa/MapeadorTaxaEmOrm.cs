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

            tBuilder.Property(t => t.TipoCobranca)
                .HasColumnType("int")
                .IsRequired();

            tBuilder.Property(c => c.EmpresaId)
                .IsRequired()
                .HasColumnName("Empresa_Id")
                .HasColumnType("int");

            tBuilder.HasOne(g => g.Empresa)
                .WithMany()
                .HasForeignKey(g => g.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
