using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarStore.Garage.Application.Mappings;
using RentCarStore.Garage.Application.Services;
using RentCarStore.Garage.Data;
using RentCarStore.Garage.Data.Repositories;
using RentCarStore.Garage.Data.Repositories.Interfaces;
using RentCarStore.Garage.Domain.Services;

namespace RentCarStore.Garage.Ioc
{
    public static class Bootstraper
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration)
        {
            AddMapster();
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddApplicationServices(services);
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GarageContext>();
            services.AddDbContext<GarageContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Database")));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICarRepository, CarRepository>();
        }

        private static void AddMapster()
        {
            var globalSettings = TypeAdapterConfig.GlobalSettings;

            globalSettings.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);
            globalSettings.Scan(typeof(DtoToEntityMapping).Assembly);
        }
    }
}