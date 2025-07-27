using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain;

public class AuditedDomainEntity<TId> : DomainEntity<TId>
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
