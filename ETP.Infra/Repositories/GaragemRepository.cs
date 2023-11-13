using ETP.Domain.Entities;
using ETP.Domain.Repositories.Common;
using ETP.Domain.Repository;
using ETP.Infra.Persistence;
using ETP.Infra.Repositories.Common;

namespace ETP.Infra.Repositories
{
    public class GaragemRepository : Repository<Garagem>, IGaragemRepository
    {
        public GaragemRepository(SqlServerDBContext context) : base(context)
        { }

        public void Update(Garagem entity)
        {
            try
            {
                _DbSet.Update(entity);
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
