using EvoltisChallenge.Api.Application.Commands.Product.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Create;

public class CreateProductCommandValidatorTests
{
    [Theory]
    [InlineData("xxxx", "xxxx", 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", true)]
    [InlineData("", "xxxx", 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("xxxx", null, 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("xxxx", "xxxx", 0, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("xxxx", "xxxx", 0, "", false)]
    public async Task ValidatorTest(string name, string description, double price, string pCategoryIdString, bool isValid)
    {

        // Arrange
        var pCategoryId = string.IsNullOrWhiteSpace(pCategoryIdString)
            ? Guid.Empty
            : Guid.Parse(pCategoryIdString);

        var validator = new CreateProductCommandValidator();
        var request = new CreateProductCommand(name, description, price, pCategoryId);

        // Act
        var result = await validator.ValidateAsync(request);

        // Assert
        Assert.Equal(isValid, result.IsValid);
    }
}
