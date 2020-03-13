using Importador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Infra.Data.Configuration
{

    public class AmbienteConfiguration : IEntityTypeConfiguration<Ambiente>
    {
        public void Configure(EntityTypeBuilder<Ambiente> builder)
        {
            builder.ToTable("Ambiente");

            builder.Property(x => x.Id);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.IdPai);
            builder.Property(x => x.Observacao);
            builder.Property(x => x.IdTipoAmbiente);
            builder.Property(x => x.IdImportacao);
            builder.Property(x => x.IsAtivo);

            builder.Ignore(x => x.Filhos);
            builder.Ignore(x => x.TipoAmbiente);

            builder.HasKey(x => x.Id);
        }
    }
}
