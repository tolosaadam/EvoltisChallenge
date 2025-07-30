using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Domain.Interfaces;

public interface IDomainEntity<TId>
{
    TId Id { get; }
}

