using Importador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Configuration
{

    public class TipoAmbienteConfiguration : IEntityTypeConfiguration<TipoAmbiente>
    {
        public void Configure(EntityTypeBuilder<TipoAmbiente> builder)
        {
            builder.ToTable("TipoAmbiente");

            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.IsAtivo);

            builder.HasKey(x => x.Id);
        }
    }
}
