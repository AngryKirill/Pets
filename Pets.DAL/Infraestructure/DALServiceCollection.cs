using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pets.DAL.Contexts;
using Pets.DAL.Interfaces;
using Pets.DAL.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DALServiceCollection
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddDbContext<PetsContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
