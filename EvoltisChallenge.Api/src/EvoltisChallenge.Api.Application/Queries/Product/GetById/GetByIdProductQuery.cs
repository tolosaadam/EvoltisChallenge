using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Application.Queries.ProductCategory.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Queries.Product.GetById;

public record GetByIdProductQuery(Guid Id) : IRequest<Domain.Product?>, IValidate;

public class GetByIdProductQueryHandler(
    IEfProductRepository efProductRepository)
    : IRequestHandler<GetByIdProductQuery, Domain.Product?>
{
    private readonly IEfProductRepository _efProductRepository = efProductRepository;

    public async Task<Domain.Product?> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _efProductRepository.GetByIdAsync(request.Id, cancellationToken);

        return result;
    }
}
