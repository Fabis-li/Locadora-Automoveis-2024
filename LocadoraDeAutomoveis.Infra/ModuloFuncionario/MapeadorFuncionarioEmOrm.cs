using LocadoraDeAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeAutomoveis.Infra.ModuloFuncionario
{
    public class MapeadorFuncionarioEmOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> fBuilder)
        {
            fBuilder.ToTable("TBFuncionario");

            fBuilder.Property(f => f.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            fBuilder.Property(f => f.NomeCompleto)
                .HasColumnType("varchar(100)")
                .IsRequired();

            fBuilder.Property(f => f.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            fBuilder.Property(f => f.Admissao)
                .HasColumnType("datetime2")
                .IsRequired();

            fBuilder.Property(f => f.Salario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            fBuilder.Property(f => f.EmpresaId)
                .HasColumnType("int")
                .IsRequired();

            fBuilder.HasOne(f => f.Empresa)
                .WithMany()
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            fBuilder.Property(f => f.UsuarioId)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
