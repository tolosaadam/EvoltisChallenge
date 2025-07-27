using EvoltisChallenge.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.dbEntities;

public class ProductDb : AuditedEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public Guid ProductCategoryId { get; set; }
    public ProductCategoryDb? Category { get; set; }
}
