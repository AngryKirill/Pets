using Pets.API.ViewModel;
using Pets.BLL.Models;
using Pets.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.Tests
{
    public static class TestPetData
    {
        private static List<PetEntity> pets = new List<PetEntity>()
            {
                new PetEntity { Id = 1, Name = "Tom", Age = 37, Weight = 10 },
                new PetEntity { Id = 2, Name = "Bob", Age = 41, Weight = 10 },
                new PetEntity { Id = 3, Name = "Sam", Age = 24, Weight = 11 }
            };

        public static Pet GetPetModel()
        {
            return new Pet { Id = 1, Name = "Tom", Age = 37, Weight = 10 };
        }
        public async static Task<PetEntity> GetTaskPetEntity()
        {
            return new PetEntity { Id = 1, Name = "Tom", Age = 37, Weight = 10 };
        }
        public static PetEntity GetPetEntity()
        {
            return new PetEntity { Id = 1, Name = "Tom", Age = 37, Weight = 10 };
        }
    }
}
