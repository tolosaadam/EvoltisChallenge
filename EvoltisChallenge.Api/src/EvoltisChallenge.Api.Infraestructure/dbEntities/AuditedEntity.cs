using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.dbEntities;

public class AuditedEntity<TId> : Entity<TId>
{
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt {  get; set; }
}
