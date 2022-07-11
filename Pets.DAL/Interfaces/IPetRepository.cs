using Pets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
