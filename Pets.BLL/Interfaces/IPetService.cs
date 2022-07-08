using Pets.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.BLL.Interfaces
{
    public interface IPetService
    {
        IEnumerable<Pet> GetAll();
        Pet GetById(int id);
        IEnumerable<Pet> Find(Func<Pet, Boolean> predicate);
        void Create(Pet item);
        void Update(Pet item);
        void Delete(int id);
    }
}
