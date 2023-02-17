using FluentValidation;
using LocalStack.Client.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarStore.Core.LocalStack;
using RentCarStore.Core.Messaging.Extensions;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Notification.Handlers;
using RentCarStore.Core.Notification.Notifiers;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Garage.Application.Mappings;
using RentCarStore.Garage.Application.Services;
using RentCarStore.Garage.Application.Services.Interfaces;
using RentCarStore.Garage.Data;
using RentCarStore.Garage.Data.Repositories;
using RentCarStore.Garage.Domain;
using RentCarStore.Garage.Domain.Repositories;
using RentCarStore.Garage.Domain.Services;
using RentCarStore.Garage.Domain.Services.Interfaces;
using RentCarStore.Garage.Domain.Validators;
using System.Reflection;

namespace RentCarStore.Garage.Ioc
{
    public static class Bootstraper
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration, Assembly startupAssembly)
        {
            AddMapster();
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddNotification(services);
            AddValidators(services);
            AddApplicationServices(services);
            AddDomainServices(services);
            services.AddMessaging();
            services.AddLocalStackAwsService(configuration);

            services.AddMediatR(startupAssembly);
        }

        private static void AddDomainServices(IServiceCollection services)
        {
            services.AddScoped<ICarServices, CarServices>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<Car>, CarValidator>();
        }

        private static void AddNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotifier, Notifier>();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ICarApplicationServices, CarApplicationServices>();
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