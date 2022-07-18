using Microsoft.Extensions.Configuration;
using Pets.BLL.Interfaces;
using Pets.BLL.Models;
using Pets.BLL.Services;
using Pets.DAL.Entities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLLServiceCollection
    {
        public static void AddBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenericService<Pet, PetEntity>, GenericService<Pet, PetEntity>>();
            services.AddScoped<IGenericService<Food, FoodEntity>, GenericService<Food, FoodEntity>>();
            services.AddDALServices(configuration);
        }
    }
}
