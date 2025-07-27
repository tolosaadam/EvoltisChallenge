using AutoMapper;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvoltisChallenge.Api.Application.Commands.Product.Create;

public record CreateProductCommand(
    string Name,
    string Description,
    double Price,
    Guid ProductCategoryId) : IRequest<Guid>, ITransaction, IValidate;

public class CreateProductCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper autoMapper)
    : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _autoMapper = autoMapper;

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var pCategory = await _unitOfWork.ProductCategories.GetByIdAsync(request.ProductCategoryId, cancellationToken);

        if (pCategory is null)
        {
            throw new RelatedEntityNotFoundException(
                nameof(Domain.Product),
                nameof(Domain.ProductCategory),
                request.ProductCategoryId);
        }

        var product = _autoMapper.Map<Domain.Product>(request);

        product.CreatedAt = DateTime.UtcNow;
        product.ModifiedAt = DateTime.UtcNow;

        var getId = await _unitOfWork.Products.AddAsync(product, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var id = getId();

        return id;
    }
}
