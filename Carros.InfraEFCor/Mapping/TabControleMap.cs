using Carros.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Mapping
{
    public class TabControleMap : IEntityTypeConfiguration<TabControle>
    {
        public void Configure(EntityTypeBuilder<TabControle> builder)
        {
            builder.ToTable("TABCONTROLE");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x => x.Sigla).HasColumnName("SIGLA");
            builder.Property(x => x.ValorInt).HasColumnName("VALORINT");
            builder.Property(x => x.ValorString).HasColumnName("VALORSTRING");
            builder.Property(x => x.ValorData).HasColumnName("VALORDATA");
        }
    }
}
