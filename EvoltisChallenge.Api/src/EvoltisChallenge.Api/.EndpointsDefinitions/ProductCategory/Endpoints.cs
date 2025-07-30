using AutoMapper;
using EvoltisChallenge.Api.Application.Queries.ProductCategory.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EvoltisChallenge.Api.EndpointsDefinitions.ProductType;

public class Endpoints
{
    internal static async Task<IResult> GetAll(
    [FromServices] IMediator mediator,
    [FromServices] IMapper autoMapper,
    CancellationToken cancellationToken)
    {
        var query = new GetAllProductCategoryQuery();
        var result = await mediator.Send(query, cancellationToken);
        var mappedResult = autoMapper.Map<IEnumerable<Responses.ProductCategory.ProductCategoryResponse>>(result);
        return Results.Ok(mappedResult);
    }
}