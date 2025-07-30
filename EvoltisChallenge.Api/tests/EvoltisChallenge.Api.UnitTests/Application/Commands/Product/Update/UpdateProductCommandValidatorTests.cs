using EvoltisChallenge.Api.Application.Commands.Product.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.UnitTests.Application.Commands.Product.Update;

public class UpdateProductCommandValidatorTests
{
    [Theory]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", "xxxx", "xxxx", 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", true)]
    [InlineData("", "xxxx", "xxxx", 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", "", "xxxx", 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", "xxxx", null, 1, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", "xxxx", "xxxx", 0, "d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", false)]
    [InlineData("d2719b70-bb2b-4c58-8f22-6ecb7db8a9a9", "xxxx", "xxxx", 0, "", false)]
    public async Task ValidatorTest(string idString, string name, string description, double price, string pCategoryIdString, bool isValid)
    {

        // Arrange
        var id = string.IsNullOrWhiteSpace(idString)
            ? Guid.Empty
            : Guid.Parse(idString);

        var pCategoryId = string.IsNullOrWhiteSpace(pCategoryIdString)
            ? Guid.Empty
            : Guid.Parse(pCategoryIdString);

        var validator = new UpdateProductCommandValidator();
        var request = new UpdateProductCommand(id, name, description, price, pCategoryId);

        // Act
        var result = await validator.ValidateAsync(request);

        // Assert
        Assert.Equal(isValid, result.IsValid);
    }
}
