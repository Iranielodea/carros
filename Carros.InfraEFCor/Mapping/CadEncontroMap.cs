using Carros.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Mapping
{
    public class CadEncontroMap : IEntityTypeConfiguration<CadEncontro>
    {
        public void Configure(EntityTypeBuilder<CadEncontro> builder)
        {
            builder.ToTable("CAD_ENCONTRO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
            builder.Property(x => x.NumeroEncontro).HasColumnName("NUM_ENCONTRO");
            builder.Property(x => x.EventoAtual).HasColumnName("EVENTO_ATUAL");
        }
    }
}
