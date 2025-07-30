using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Queries.ProductCategory.GetAll;

public record GetAllProductCategoryQuery() : IRequest<IEnumerable<Domain.ProductCategory>>;

public class GetAllProductCategoryQueryHandler(
    IEfProductCategoryRepository efPCategoryRepository)
    : IRequestHandler<GetAllProductCategoryQuery, IEnumerable<Domain.ProductCategory>>
{
    private readonly IEfProductCategoryRepository _efPCategoryRepository = efPCategoryRepository;

    public async Task<IEnumerable<Domain.ProductCategory>> Handle(GetAllProductCategoryQuery request, CancellationToken cancellationToken)
    {
        var result = await _efPCategoryRepository.GetAllAsync(cancellationToken);

        return result;
    }
}
