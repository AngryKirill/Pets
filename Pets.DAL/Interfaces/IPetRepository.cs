using Pets.DAL.Entities;

namespace Pets.DAL.Interfaces
{
    public interface IPetRepository
    {
        IEnumerable<PetEntity> GetAll();
        PetEntity GetById(int id);
        IEnumerable<PetEntity> Find(Func<PetEntity, Boolean> predicate);
        void Create(PetEntity item);
        void Update(PetEntity item);
        void Delete(int id);
    }
}
