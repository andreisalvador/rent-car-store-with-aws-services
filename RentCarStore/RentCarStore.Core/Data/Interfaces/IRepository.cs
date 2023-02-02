using RentCarStore.Core.Entites;

namespace RentCarStore.Core.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
