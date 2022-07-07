using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.DAL.Interfaces
{
    public interface IPetRepository<Pet>
    {
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        IEnumerable<Pet> Find(Func<Pet, Boolean> predicate);
        void Create(Pet item);
        void Update(Pet item);
        void Delete(int id);
    }
}
