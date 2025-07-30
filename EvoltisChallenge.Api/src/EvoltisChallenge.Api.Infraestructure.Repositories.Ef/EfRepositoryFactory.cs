using AutoMapper;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.Repositories.Ef;

public class EfRepositoryFactory(AppDbContext context, IMapper mapper) : IEfRepositoryFactory
{
    private readonly AppDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public IEfProductRepository CreateProductRepository() =>
        new EfProductRepository(_context, _mapper);

    public IEfProductCategoryRepository CreateProductCategoryRepository() =>
        new EfProductCategoryRepository(_context, _mapper);
}
