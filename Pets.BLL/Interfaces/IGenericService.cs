namespace Pets.BLL.Interfaces
{
    public interface IGenericService<TModel> 
        where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
        IEnumerable<TModel> Find(Func<TModel, Boolean> predicate);
        Task Create(TModel item);
        Task Update(TModel item);
        Task Delete(int id);
    }
}
