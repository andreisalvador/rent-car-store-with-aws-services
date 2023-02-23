using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarStore.Contracts.Data;
using RentCarStore.Contracts.Data.Repositories;
using RentCarStore.Contracts.Domain;
using RentCarStore.Contracts.Domain.Repositories;
using RentCarStore.Contracts.Domain.Validators;
using RentCarStore.Core.LocalStack;
using RentCarStore.Core.Notification.Handlers;
using RentCarStore.Core.Notification.Notifiers.Interfaces;
using RentCarStore.Core.Notification.Notifiers;
using RentCarStore.Core.Notification;
using RentCarStore.Core.Messaging.Extensions;
using System.Reflection;

namespace RentCarStore.Contracts.Ioc
{
    public static class Bootstraper
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration, Assembly startupAssembly)
        {
            AddValidators(services);
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddNotification(services);

            services.AddMessaging();
            services.AddLocalStackAwsService(configuration);
            services.AddMediatR(startupAssembly);
        }

        private static void AddNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotifier, Notifier>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddSingleton<IValidator<Contract>, ContractValidator>();
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