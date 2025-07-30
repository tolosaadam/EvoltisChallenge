using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoltisChallenge.Api.Application.Interfaces.Persistence;

public interface IEfRepositoryFactory
{
    IEfProductRepository CreateProductRepository();
    IEfProductCategoryRepository CreateProductCategoryRepository();
}
