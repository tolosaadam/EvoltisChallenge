using EvoltisChallenge.Api.Infraestructure.dbEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Infraestructure.dbEntities;

public class Entity<TId> : IEntity<TId>
{
    public TId Id { get; set; } = default!;
}
