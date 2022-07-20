using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Interfaces;

namespace Pets.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly PetsContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PetsContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task Create(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async virtual Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public async virtual Task Delete(int id)
        {
            TEntity item = (await _dbSet.FindAsync(id))!;
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
