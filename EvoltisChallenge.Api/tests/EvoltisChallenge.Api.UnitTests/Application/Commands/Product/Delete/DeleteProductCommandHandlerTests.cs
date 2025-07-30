using AutoMapper;
using EvoltisChallenge.Api.Application.Commands.Product.Delete;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Delete;

public class DeleteProductCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapper> _autoMapperMock = new();
    private readonly Mock<IEfProductRepository> _pRepositoryMock = new();
    private DeleteProductCommandHandler _handler = null!;
    private static readonly Guid GuidMock = Guid.Parse("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9");

    public DeleteProductCommandHandlerTests()
    {
        _unitOfWorkMock
            .Setup(u => u.Products)
            .Returns(_pRepositoryMock.Object);

        _handler = new DeleteProductCommandHandler(
            _unitOfWorkMock.Object,
            _autoMapperMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldDeleteProduct()
    {
        // Arrange
        var command = new DeleteProductCommand(GuidMock);

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
            .Setup(r => r.Products.Delete(product));

        // Act
        await _handler.Handle(command, cancellationToken)!;

        // Assert
        _unitOfWorkMock.Verify(
            u => u.Products.GetByIdAsync(command.Id, cancellationToken),
            Times.Once
        );

        _pRepositoryMock.Verify(
            r => r.Delete(
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
        var command = new DeleteProductCommand(GuidMock);

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
}
