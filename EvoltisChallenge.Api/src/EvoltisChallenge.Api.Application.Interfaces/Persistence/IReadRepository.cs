using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Interfaces.Persistence;

public interface IReadRepository<TDomainModel, TDomainId>
{
    IEnumerable<TDomainModel> GetAll();
    Task<IEnumerable<TDomainModel>> GetAllAsync(CancellationToken cancellationToken = default);
    TDomainModel? GetById(TDomainId id);
    Task<TDomainModel?> GetByIdAsync(TDomainId id, CancellationToken cancellationToken = default);
}
