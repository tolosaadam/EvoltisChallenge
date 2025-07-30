using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Queries.Product.GetAll;

public record GetAllProductQuery() : IRequest<IEnumerable<Domain.Product>>;

public class GetAllProductQueryHandler(
    IEfProductRepository efProductRepository)
    : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Product>>
{
    private readonly IEfProductRepository _efProductRepository = efProductRepository;

    public async Task<IEnumerable<Domain.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _efProductRepository.GetAllIncludeAsync(cancellationToken);

        return result;
    }
}