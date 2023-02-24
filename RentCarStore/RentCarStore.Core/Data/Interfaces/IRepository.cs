using RentCarStore.Core.Entites;
using System.Linq.Expressions;

namespace RentCarStore.Core.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> condition);
        Task<TEntity> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
