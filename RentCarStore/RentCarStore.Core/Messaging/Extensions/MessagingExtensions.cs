using Microsoft.Extensions.DependencyInjection;
using RentCarStore.Core.Messaging.Interfaces;

namespace RentCarStore.Core.Messaging.Extensions
{
    public static class MessagingExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<ISqsConsumer, SqsConsumer>();
            services.AddSingleton<ISnsPublisher, SnsPublisher>();
            return services;
        }
    }
}
