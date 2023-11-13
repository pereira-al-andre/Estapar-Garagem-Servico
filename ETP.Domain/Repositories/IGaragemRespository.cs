using ETP.Domain.Entities;
using ETP.Domain.Repositories.Common;

namespace ETP.Domain.Repository
{
    public interface IGaragemRepository : IRepository<Garagem>, IUpdatable<Garagem>
    { }
}
