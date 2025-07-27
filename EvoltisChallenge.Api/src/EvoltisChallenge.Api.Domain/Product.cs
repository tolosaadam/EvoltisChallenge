using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain;

public class Product : DomainEntity<Guid>
{
    public string? Name { get; set; }


}
