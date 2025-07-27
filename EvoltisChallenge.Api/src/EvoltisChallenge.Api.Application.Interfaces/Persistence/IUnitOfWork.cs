using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Interfaces.Persistence;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IEfProductRepository Products { get; }
    IEfProductCategoryRepository ProductCategories { get; }
    int SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
