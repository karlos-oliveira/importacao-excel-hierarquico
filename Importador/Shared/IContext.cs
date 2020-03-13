using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Importador.Shared
{
    public interface IContext : IDisposable
    {
        DbSet<ImportacaoAmbiente> ImportacaoAmbiente { get; }
        DbSet<Ambiente> Ambiente { get; }
        DbSet<TipoAmbiente> TipoAmbiente { get; }
       
        DatabaseFacade Database { get; }
        DbSet<T> DbSet<T>() where T : class;
        Task<int> CommitAsync();
        int Commit();

    }
}
