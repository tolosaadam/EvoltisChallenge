using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain;

public class DomainEntity<TId>
{
    public TId Id { get; set; } = default!;
}
