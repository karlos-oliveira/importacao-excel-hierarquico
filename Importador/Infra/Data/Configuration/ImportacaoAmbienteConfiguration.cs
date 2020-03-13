using Importador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Importador.Infra.Data.Configuration
{

    public class ImportacaoAmbienteConfiguration : IEntityTypeConfiguration<ImportacaoAmbiente>
    {
        public void Configure(EntityTypeBuilder<ImportacaoAmbiente> builder)
        {
            builder.ToTable("ImportacaoAmbiente");

            builder.Property(x => x.IdImportacao).IsRequired();
            builder.Property(x => x.DataImportacaoUTC).IsRequired();

            builder.Ignore(x => x.Filhos);

            builder.HasKey(x => x.IdImportacao);
        }
    }
}
