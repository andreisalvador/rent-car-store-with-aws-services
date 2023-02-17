using Amazon.SimpleNotificationService;
using Amazon.SQS;
using LocalStack.Client.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RentCarStore.Core.LocalStack
{
    public static class LocalStackExtensions
    {
        public static IServiceCollection AddLocalStackAwsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalStack(configuration);
            services.AddAwsService<IAmazonSQS>();
            services.AddAwsService<IAmazonSimpleNotificationService>();
            return services;
        }
    }
}
