using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain;

public class ProductCategory : DomainEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
