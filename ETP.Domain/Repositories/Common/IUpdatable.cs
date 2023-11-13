using ETP.Domain.Entities;

namespace ETP.Domain.Repositories.Common
{
    public interface IUpdatable<TEntity> where TEntity : Entity
    {
        public void Update(TEntity entity);
    }
}
