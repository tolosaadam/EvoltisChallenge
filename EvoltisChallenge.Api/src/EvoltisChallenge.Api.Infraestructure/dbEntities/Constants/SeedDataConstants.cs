using EvoltisChallenge.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.dbEntities.Constants;

public static class SeedDataConstants
{
    public static readonly List<ProductCategoryDb> ProductCategories =
    [
        new ProductCategoryDb { Id = Guid.Parse("12345678-1234-1234-1234-1234567890ab"), Name = "Peripherals", Description = "PC peripherals" },
        new ProductCategoryDb { Id = Guid.Parse("22345678-1234-1234-1234-1234567890ab"), Name = "Clothes", Description = "Wide clothes" },
        new ProductCategoryDb { Id = Guid.Parse("32345678-1234-1234-1234-1234567890ab"), Name = "Hardware", Description = "PC hardware" }
    ];

    public static readonly List<ProductDb> Products =
    [
        new ProductDb
        {
            Id = Guid.Parse("42345678-1234-1234-1234-1234567890ab"),
            Name = "Keyboard",
            Description = "Logitech white",
            Price = 33.5,
            CreatedAt = new DateTime(2025, 6, 10),
            ModifiedAt = new DateTime(2025, 6, 10),
            ProductCategoryId = Guid.Parse("12345678-1234-1234-1234-1234567890ab")
        },
        new ProductDb
        {
            Id = Guid.Parse("52345678-1234-1234-1234-1234567890ab"),
            Name = "Mouse",
            Description = "Logitech black",
            Price = 22.99,
            CreatedAt = new DateTime(2025, 6, 10),
            ModifiedAt = new DateTime(2025, 6, 10),
            ProductCategoryId = Guid.Parse("12345678-1234-1234-1234-1234567890ab")
        },
        new ProductDb
        {
            Id = Guid.Parse("62345678-1234-1234-1234-1234567890ab"),
            Name = "Shirt",
            Description = "Green XXL",
            Price = 15.99,
            CreatedAt = new DateTime(2025, 6, 10),
            ModifiedAt = new DateTime(2025, 6, 10),
            ProductCategoryId = Guid.Parse("22345678-1234-1234-1234-1234567890ab")
        },
        new ProductDb
        {
            Id = Guid.Parse("72345678-1234-1234-1234-1234567890ab"),
            Name = "Cap",
            Description = "New School",
            Price = 10.99,
            CreatedAt = new DateTime(2025, 6, 10),
            ModifiedAt = new DateTime(2025, 6, 10),
            ProductCategoryId = Guid.Parse("22345678-1234-1234-1234-1234567890ab")
        }
    ];
}
