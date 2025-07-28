using AutoMapper;
using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Commands.Product.Delete;
using EvoltisChallenge.Api.Application.Commands.Product.Update;
using EvoltisChallenge.Api.Application.Queries.Product.GetAll;
using EvoltisChallenge.Api.Application.Queries.Product.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EvoltisChallenge.Api.EndpointsDefinitions.Product;

public class Endpoints
{
    internal static async Task<IResult> GetAll(
        [FromServices] IMediator mediator,
        [FromServices] IMapper autoMapper,
        CancellationToken cancellationToken)
    {
        var query = new GetAllProductQuery();
        var result = await mediator.Send(query, cancellationToken);
        var mappedResult = autoMapper.Map<IEnumerable<Responses.Product.ProductResponse>>(result);
        return Results.Ok(mappedResult);
    }

    internal static async Task<IResult> GetById(
    [FromServices] IMediator mediator,
    [FromServices] IMapper autoMapper,
    Guid id,
    CancellationToken cancellationToken)
    {
        var query = new GetByIdProductQuery(id);
        var result = await mediator.Send(query, cancellationToken);
        var mappedResult = autoMapper.Map<Responses.Product.ProductResponse>(result);
        return Results.Ok(mappedResult);
    }

    internal static async Task<IResult> Create(
        [FromServices] IMediator mediator,
        [FromServices] IMapper autoMapper,
        Requests.Product.CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = autoMapper.Map<CreateProductCommand>(request);
        var result = await mediator.Send(command, cancellationToken);
        return Results.Created($"/products/{result}", new { id = result });
    }

    internal static async Task<IResult> Update(
        [FromServices] IMediator mediator,
        [FromServices] IMapper autoMapper,
        Guid id,
        Requests.Product.UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var command = autoMapper.Map<UpdateProductCommand>((request, id));
        await mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }

    internal static async Task<IResult> Delete(
    [FromServices] IMediator mediator,
    Guid id,
    CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        await mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }
}
