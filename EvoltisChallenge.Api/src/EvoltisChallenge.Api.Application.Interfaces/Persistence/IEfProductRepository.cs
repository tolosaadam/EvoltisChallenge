using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Interfaces.Persistence;

public interface IEfProductRepository : IEfRepository<Domain.Product, Guid>
{
    Task<IEnumerable<Domain.Product>> GetAllAsync(bool includeCategory, CancellationToken cancellationToken = default);
}
