namespace Pets.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate);
        Task Create(TEntity item);
        Task Update(TEntity item);
        Task Delete(int id);
    }
}
