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

            gBuilder.Property(c => c.EmpresaId)
                .IsRequired()
                .HasColumnName("Empresa_Id")
                .HasColumnType("int");

            gBuilder.HasOne(g => g.Empresa)
                .WithMany()
                .HasForeignKey(g => g.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
