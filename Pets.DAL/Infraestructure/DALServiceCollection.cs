using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pets.DAL.Contexts;
using Pets.DAL.Interfaces;
using Pets.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets.DAL.Infraestructure
{
    public static class DALServiceCollection
    {
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddDbContext<PetsContext>(options => options.UseSqlServer(connection));
            return services;
        }
    }
}
