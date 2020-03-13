using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Importador.Shared
{
    public interface IUnitOfWork
    {
        void Rollback();

        Task CommitAsync();

        void Commit();
       // IDbContextTransaction BeginTransaction(ICapPublisher capPublisher, bool autoCommit = true);
        IDbContextTransaction BeginTransaction();
    }
}
