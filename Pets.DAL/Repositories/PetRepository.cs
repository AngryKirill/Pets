using Microsoft.EntityFrameworkCore;
using Pets.DAL.Contexts;
using Pets.DAL.Interfaces;
    
namespace Pets.DAL.Repositories
{
    public class PetRepository<TEntity>: IPetRepository<TEntity> where TEntity: class
    {
        private readonly PetsContext _context;

        private readonly DbSet<TEntity> _dbSet;

        public PetRepository(PetsContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TEntity item = _dbSet.Find(id);
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
