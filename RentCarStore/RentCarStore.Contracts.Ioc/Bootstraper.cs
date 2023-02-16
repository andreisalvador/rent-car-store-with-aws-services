using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarStore.Contracts.Data;
using RentCarStore.Contracts.Data.Repositories;
using RentCarStore.Contracts.Domain.Repositories;

namespace RentCarStore.Contracts.Ioc
{
    public static class Bootstraper
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ContractContext>();
            services.AddDbContext<ContractContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Database")));
        }


        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IContractRepository, ContractRepository>();
        }
    }
}