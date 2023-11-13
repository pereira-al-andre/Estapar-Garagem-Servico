using ETP.Domain.Entities;
using System.Linq.Expressions;

namespace ETP.Domain.Repositories.Common
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        public TEntity? Find(Guid id);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter);
        public TEntity? Find(Guid id, string includes);
        public TEntity? Find(Expression<Func<TEntity, bool>> filter, string includes);
        public IEnumerable<TEntity> All();
        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter);
        public IEnumerable<TEntity> All(string includes);
        public IEnumerable<TEntity> All(Expression<Func<TEntity, bool>> filter, string includes);
        public TEntity Create(TEntity entity);
    }
}
