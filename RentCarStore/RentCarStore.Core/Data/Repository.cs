using Microsoft.EntityFrameworkCore;
using RentCarStore.Core.Data.Interfaces;
using RentCarStore.Core.Entites;
using System.Linq.Expressions;

namespace RentCarStore.Core.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public Task<bool> Exists(Expression<Func<TEntity, bool>> condition)
            => DbSet.AnyAsync(condition);

        public void Add(TEntity entity)
            => DbSet.Add(entity);

        public void Delete(TEntity entity)
            => DbSet.Remove(entity);

        public Task<TEntity> GetByIdAsync(Guid id)
            => DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Update(TEntity entity)
            => DbSet.Update(entity);

        public Task SaveChangesAsync()
            => _context.SaveChangesAsync();
    }
}
