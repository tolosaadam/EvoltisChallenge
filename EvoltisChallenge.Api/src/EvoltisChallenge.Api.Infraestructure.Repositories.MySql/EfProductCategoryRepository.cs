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

public class EfProductCategoryRepository(
    AppDbContext context,
    IMapper autoMapper)
    : EfRepository<Domain.ProductCategory, ProductCategoryDb, Guid>(autoMapper), IEfProductCategoryRepository
{
    protected override DbSet<ProductCategoryDb> DbSet => context.Set<ProductCategoryDb>();
}
