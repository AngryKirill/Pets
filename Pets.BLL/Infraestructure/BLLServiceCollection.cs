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
            services.AddScoped<IGenericService<Pet>, GenericService<Pet, PetEntity>>();
            services.AddScoped<IGenericService<Food>, GenericService<Food, FoodEntity>>();
            services.AddDALServices(configuration);
        }
    }
}
