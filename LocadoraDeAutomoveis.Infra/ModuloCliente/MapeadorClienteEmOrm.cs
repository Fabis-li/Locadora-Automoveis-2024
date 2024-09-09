using LocadoraDeAutomoveis.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloCleinte
{
    public class MapeadorClienteEmOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> cBuilder)
        {
            cBuilder.ToTable("TBCliente");

            cBuilder.Property(c => c.Id)
                .IsRequired()
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            cBuilder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Rg)
                .IsRequired()
                .HasColumnType("varchar(20)");

            cBuilder.Property(c => c.Cnh)
                .IsRequired()
                .HasColumnType("varchar(20)");

            cBuilder.Property(c => c.NumeroDocumento)
                .IsRequired()
                .HasColumnType("varchar(20)");

            cBuilder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            cBuilder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            cBuilder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Rua)
                .IsRequired()
                .HasColumnType("varchar(100)");

            cBuilder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(10)");

            cBuilder.Property(c => c.TipoCliente)
                .IsRequired()
                .HasColumnType("int");

            cBuilder.Property(c => c.EmpresaId)
                .IsRequired()
                .HasColumnName("Empresa_Id")
                .HasColumnType("int");

            cBuilder.HasOne(g => g.Empresa)
                .WithMany()
                .HasForeignKey(g => g.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
