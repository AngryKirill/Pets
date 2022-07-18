namespace Pets.BLL.Interfaces
{
    public interface IGenericService<TModel, TEntity> 
        where TModel : class
        where TEntity : class
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
        IEnumerable<TModel> Find(Func<TModel, Boolean> predicate);
        void Create(TModel item);
        void Update(TModel item);
        void Delete(int id);
    }
}
