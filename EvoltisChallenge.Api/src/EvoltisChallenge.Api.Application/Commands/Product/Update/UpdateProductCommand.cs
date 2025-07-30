using AutoMapper;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Commands.Product.Update;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Description,
    double Price,
    Guid ProductCategoryId) : IRequest, ITransaction, IValidate;

public class UpdateProductCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper autoMapper)
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _autoMapper = autoMapper;

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new EntityNotFoundException(nameof(Domain.Product), request.Id);
        }

        var pCategory = await _unitOfWork.ProductCategories.GetByIdAsync(request.ProductCategoryId, cancellationToken);

        if (pCategory is null)
        {
            throw new RelatedEntityNotFoundException(
                nameof(Domain.Product),
                nameof(Domain.ProductCategory),
                request.ProductCategoryId);
        }

        var pToUpdate = _autoMapper.Map<Domain.Product>(request);

        pToUpdate.ModifiedAt = DateTime.UtcNow;

        _unitOfWork.Products.Update(pToUpdate);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
