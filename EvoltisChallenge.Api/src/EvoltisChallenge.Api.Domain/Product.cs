using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain;

public class Product : DomainEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public Guid ProductCategoryId { get; set; }
    public ProductCategory? Category { get; set; }
}
