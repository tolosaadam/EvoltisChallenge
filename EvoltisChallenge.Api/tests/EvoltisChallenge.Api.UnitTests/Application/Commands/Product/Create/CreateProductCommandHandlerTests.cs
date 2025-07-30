using AutoMapper;
using EvoltisChallenge.Api.Application.Commands.Product.Create;
using EvoltisChallenge.Api.Application.Interfaces.Persistence;
using EvoltisChallenge.Api.Domain.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Create;

public class CreateProductCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly Mock<IMapper> _autoMapperMock = new();
    private readonly Mock<IEfProductRepository> _pRepositoryMock = new();
    private readonly Mock<IEfProductCategoryRepository> _pCategoryRepositoryMock = new();
    private CreateProductCommandHandler _handler = null!;
    private static readonly Guid GuidMock = Guid.Parse("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9");

    public CreateProductCommandHandlerTests()
    {
        _unitOfWorkMock
            .Setup(u => u.Products)
            .Returns(_pRepositoryMock.Object);

        _unitOfWorkMock
            .Setup(u => u.ProductCategories)
            .Returns(_pCategoryRepositoryMock.Object);

        _handler = new CreateProductCommandHandler(
            _unitOfWorkMock.Object,
            _autoMapperMock.Object
        );
    }

    [Fact]
    public async Task Handle_ShouldCreateProduct()
    {
        // Arrange
        var command = new CreateProductCommand("Product 1", "Description", 1, GuidMock);

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

        static Guid idFunc() => GuidMock;

        _unitOfWorkMock
            .Setup(r => r.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken))
            .ReturnsAsync(pCategory);

        _autoMapperMock
            .Setup(m => m.Map<Domain.Product>(command))
            .Returns(product);

        _unitOfWorkMock
            .Setup(r => r.Products.AddAsync(product, cancellationToken))
            .ReturnsAsync(idFunc);

        // Act
        var result = await _handler.Handle(command, cancellationToken)!;

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        Assert.Equal(GuidMock, result);

        _unitOfWorkMock.Verify(
            u => u.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken),
            Times.Once
        );

        _autoMapperMock.Verify(m => m.Map<Domain.Product>(command), Times.Once, "Should map the create command to Domain.Product");

        _pRepositoryMock.Verify(
            r => r.AddAsync(
                It.Is<Domain.Product>(p =>
                    p.Name == product.Name &&
                    p.Description == product.Description &&
                    p.Price == product.Price &&
                    p.ProductCategoryId == product.ProductCategoryId
                ),
                cancellationToken
            ),
            Times.Once
        );

        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowRelatedEntityNotFoundException()
    {
        // Arrange
        var command = new CreateProductCommand("Product 1", "Description", 1, GuidMock);

        var cancellationToken = CancellationToken.None;

        var pType = new Domain.Product
        {
            Id = GuidMock
        };

        _unitOfWorkMock
            .Setup(r => r.ProductCategories.GetByIdAsync(command.ProductCategoryId, cancellationToken))
            .ReturnsAsync((Domain.ProductCategory?)null);

        await Assert.ThrowsAsync<RelatedEntityNotFoundException>(async () =>
        {
            await _handler.Handle(command, cancellationToken);
        });
    }
}
