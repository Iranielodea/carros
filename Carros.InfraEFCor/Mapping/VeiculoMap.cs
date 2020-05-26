using Carros.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("VEICULO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Ano).HasColumnName("ANO");
            builder.Property(x => x.IdMarca).HasColumnName("ID_MARCA");
            builder.Property(x => x.Modelo).HasColumnName("MODELO");
            builder.Property(x => x.Placa).HasColumnName("PLACA");
            builder.HasOne(x => x.Marca).WithMany(x => x.Veiculos).HasForeignKey(x => x.IdMarca);
        }
    }
}

