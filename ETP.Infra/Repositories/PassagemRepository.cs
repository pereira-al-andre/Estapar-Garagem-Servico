using ETP.Domain.Entities;
using ETP.Domain.Repository;
using ETP.Infra.Persistence;
using ETP.Infra.Repositories.Common;

namespace ETP.Infra.Repositories
{
    public sealed class PassagemRepository : Repository<Passagem>, IPassagemRepository
    {
        public PassagemRepository(SqlServerDBContext context) : base(context)
        { }
    }
}
