using FluentValidation;
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
using RentCarStore.Finance.Application.Messaging.Contracts.Handlers;
using RentCarStore.Finance.Application.Messaging.Contracts.Handlers.Interfaces;
using RentCarStore.Finance.Application.Messaging.Garage.Handlers;
using RentCarStore.Finance.Application.Messaging.Garage.Handlers.Interface;
using RentCarStore.Finance.Application.Services;
using RentCarStore.Finance.Application.Services.Interfaces;
using RentCarStore.Finance.Data;
using RentCarStore.Finance.Data.Repositories;
using RentCarStore.Finance.Domain;
using RentCarStore.Finance.Domain.Repositories.Interfaces;
using RentCarStore.Finance.Domain.Services;
using RentCarStore.Finance.Domain.Services.Interfaces;
using RentCarStore.Finance.Domain.Validators;
using System.Reflection;

namespace RentCarStore.Finance.Ioc
{
    public static class Bootstraper
    {
        public static void Resolve(IServiceCollection services, IConfiguration configuration, Assembly startupAssembly)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddDomainServices(services);
            AddValidators(services);
            AddNotification(services);
            AddApplicationServices(services);
            AddEventHandlers(services);

            services.AddMessaging();
            services.AddLocalStackAwsService(configuration);
            services.AddMediatR(startupAssembly);
        }

        private static void AddEventHandlers(IServiceCollection services)
        {
            services.AddScoped<IGarageEventHandler, GarageEventHandler>();
            services.AddScoped<IContractsEventHandler, ContractsEventHandler>();
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IPriceListApplicationService, PriceListApplicationService>();
            services.AddScoped<IInvoiceApplicationService, InvoiceApplicationService>();
        }

        private static void AddNotification(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotifier, Notifier>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddSingleton<IValidator<Invoice>, InvoiceValidator>();
            services.AddSingleton<IValidator<Car>, CarValidator>();
            services.AddSingleton<IValidator<PriceList>, PriceListValidator>();
        }

        private static void AddDomainServices(IServiceCollection services)
        {
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IPriceListService, PriceListService>();  
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IPriceListRepository, PriceListRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<FinanceContext>();
            services.AddDbContext<FinanceContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Database")));
        }
    }
}