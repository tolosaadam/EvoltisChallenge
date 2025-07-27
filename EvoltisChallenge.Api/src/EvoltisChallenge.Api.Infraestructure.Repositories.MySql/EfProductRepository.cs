using AutoMapper;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Infraestructure.dbEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.Repositories.Ef;

public class EfProductRepository(
    AppDbContext context,
    IMapper autoMapper)
    : EfRepository<Domain.Product, ProductDb, Guid>(autoMapper), IEfProductRepository
{
    protected override DbSet<ProductDb> DbSet => context.Set<ProductDb>();

    public async Task<IEnumerable<Domain.Product>> GetAllAsync(bool includeCategory, CancellationToken cancellationToken = default)
    {
        return MapToDomainModel(
            await DbSet
            .AsNoTracking()
            .Include(x => x.Category)
            .ToListAsync(cancellationToken)
        );
    }
}
