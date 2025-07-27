using AutoMapper;
using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Commands.Product.Delete;

public record DeleteProductCommand(Guid Id) : IRequest, ITransaction, IValidate;

public class DeleteProductCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper autoMapper)
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _autoMapper = autoMapper;

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Product), request.Id);
        }

        _unitOfWork.Products.Delete(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
