﻿using LocadoraDeAutomoveis.Dominio.ModuloAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoreDeAutomoveis.Infra.ModuloAutomovel
{
    public class MapeadorAutomovelEmOrm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> aBuilder)
        {
            aBuilder.ToTable("TBAutomovel");

            aBuilder.Property(a => a.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            aBuilder.Property(a => a.Modelo)
                .IsRequired()
                .HasColumnType("varchar(100)");

            aBuilder.Property(a => a.Marca)
                .IsRequired()
                .HasColumnType("varchar(100)");

            aBuilder.Property(a => a.Cor)
                .IsRequired()
                .HasColumnType("varchar(50)");

            aBuilder.Property(a => a.Placa)
                .IsRequired()
                .HasColumnType("varchar(20)");

            aBuilder.Property(a => a.Combustivel)
                .IsRequired()
                .HasColumnType("varchar(50)");

            aBuilder.Property(a => a.Ano)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.Property(a => a.CapacidadeCombustivel)
                .IsRequired()
                .HasColumnType("int");

            aBuilder.Property(a => a.FotoVeiculo)
                .IsRequired()
                .HasColumnType("varchar(250)");

            aBuilder.HasOne(a => a.GrupoAutomoveis)
                .WithMany()
                .HasForeignKey("Automovel_Id")
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}