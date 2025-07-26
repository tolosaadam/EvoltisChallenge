using Microsoft.EntityFrameworkCore;

namespace EvoltisChallenge.Api.Domain
{
    public class TechnicalTestDbContext : DbContext
    {
        //Reutilizar este dbContext o crear uno a medida
        public TechnicalTestDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
