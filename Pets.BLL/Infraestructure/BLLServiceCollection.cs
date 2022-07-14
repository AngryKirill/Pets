using Microsoft.Extensions.Configuration;
using Pets.BLL.Interfaces;
using Pets.BLL.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BLLServiceCollection
    {
        public static void AddBLLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPetService, PetService>();
            services.AddDALServices(configuration);
        }
    }
}
