using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Interfaces.Persistence;

public interface IEfProductCategoryRepository : IEfRepository<Domain.ProductCategory, Guid>
{
}
