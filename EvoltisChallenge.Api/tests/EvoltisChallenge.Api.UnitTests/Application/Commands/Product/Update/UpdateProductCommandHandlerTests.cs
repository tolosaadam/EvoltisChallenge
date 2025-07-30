using AutoMapper;
using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Commands.Product.Update;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Update;

public class UpdateProductCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapper> _autoMapperMock = new();
    private readonly Mock<IEfProductRepository> _pRepositoryMock = new();
    private readonly Mock<IEfProductCategoryRepository> _pCategoryRepositoryMock = new();
    private UpdateProductCommandHandler _handler = null!;
    private static readonly Guid GuidMock = Guid.Parse("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9");

    public UpdateProductCommandHandlerTests()
    {
        _unitOfWorkMock
            .Setup(u => u.Products)
            .Returns(_pRepositoryMock.Object);

        _unitOfWorkMock
            .Setup(u => u.ProductCategories)
            .Returns(_pCategoryRepositoryMock.Object);

        _handler = new UpdateProductCommandHandler(
            _unitOfWorkMock.Object,
            _autoMapperMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldUpdateProduct()
    {
        // Arrange
        var command = new UpdateProductCommand(GuidMock, "Product 1", "Description", 1, GuidMock);

        var cancellationToken = CancellationToken.None;

        var pCategory = new Domain.ProductCategory
        {
            Id = GuidMock
        };

        var product = new Domain.Product
        {
            Name = "Product 1",
            Description = "",
            Price = 1,
            ProductCategoryId = GuidMock,
        };

        _unitOfWorkMock
            .Setup(r => r.Products.GetByIdAsync(command.Id, cancellationToken))
            .ReturnsAsync(product);

        _unitOfWorkMock
            .Setup(r => r.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken))
            .ReturnsAsync(pCategory);

        _autoMapperMock
            .Setup(m => m.Map<Domain.Product>(command))
            .Returns(product);

        _unitOfWorkMock
            .Setup(r => r.Products.Update(product));

        // Act
        await _handler.Handle(command, cancellationToken)!;

        // Assert
        _unitOfWorkMock.Verify(
            u => u.Products.GetByIdAsync(command.Id, cancellationToken),
            Times.Once
        );

        _unitOfWorkMock.Verify(
            u => u.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken),
            Times.Once
        );

        _autoMapperMock.Verify(m => m.Map<Domain.Product>(command), Times.Once, "Should map the update command to Domain.Product");

        _pRepositoryMock.Verify(
            r => r.Update(
                It.Is<Domain.Product>(p =>
                    p.Id == product.Id &&
                    p.Name == product.Name &&
                    p.Description == product.Description &&
                    p.Price == product.Price &&
                    p.ProductCategoryId == product.ProductCategoryId
                )
            ),
            Times.Once
        );

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowEntityNotFoundException()
    {
        // Arrange
        var command = new UpdateProductCommand(GuidMock, "Product 1", "Description", 1, GuidMock);

        var cancellationToken = CancellationToken.None;

        _unitOfWorkMock
            .Setup(r => r.Products.GetByIdAsync(command.Id, cancellationToken))
            .ReturnsAsync((Domain.Product?)null);

        // Act
        // Assert
        await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
        {
            await _handler.Handle(command, cancellationToken);
        });
    }

    [Fact]
    public async Task Handle_ShouldThrowRelatedEntityNotFoundException()
    {
        // Arrange
        var command = new UpdateProductCommand(GuidMock, "Product 1", "Description", 1, GuidMock);

        var cancellationToken = CancellationToken.None;

        var product = new Domain.Product
        {
            Name = "Product 1",
            Description = "",
            Price = 1,
            ProductCategoryId = GuidMock,
        };

        _unitOfWorkMock
            .Setup(r => r.Products.GetByIdAsync(command.Id, cancellationToken))
            .ReturnsAsync(product);

        _unitOfWorkMock
            .Setup(r => r.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken))
            .ReturnsAsync((Domain.ProductCategory?)null);

        // Act
        // Assert
        await Assert.ThrowsAsync<RelatedEntityNotFoundException>(async () =>
        {
            await _handler.Handle(command, cancellationToken);
        });
    }
}
