using Microsoft.EntityFrameworkCore;
using Importador.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Importador.Shared;
using Importador.Infra.Data.Configuration;

namespace Importador.Infra.Data
{
    public class ImportadorDbContext : DbContext, IContext
    {
        public ImportadorDbContext(DbContextOptions<ImportadorDbContext> options) : base(options) { }

        public DbSet<ImportacaoAmbiente> ImportacaoAmbiente { get { return this.Set<ImportacaoAmbiente>(); } }
        public DbSet<Ambiente> Ambiente { get { return this.Set<Ambiente>(); } }
        public DbSet<TipoAmbiente> TipoAmbiente { get { return this.Set<TipoAmbiente>(); } }

        public int Commit()
        {
            return this.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return this.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return this.DbSet<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ImportacaoAmbienteConfiguration());
            modelBuilder.ApplyConfiguration(new AmbienteConfiguration());
            modelBuilder.ApplyConfiguration(new TipoAmbienteConfiguration());
        }
    }
}
