using EvoltisChallenge.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.dbEntities;

public class ProductCategoryDb : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public ICollection<ProductDb>? Products { get; set; }
}
