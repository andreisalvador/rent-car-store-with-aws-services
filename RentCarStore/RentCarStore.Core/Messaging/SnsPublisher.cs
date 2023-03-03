using Amazon.Runtime.Internal.Transform;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using CommunityToolkit.HighPerformance.Buffers;
using RentCarStore.Core.Messaging.Helper;
using RentCarStore.Core.Messaging.Interfaces;
using System.Text.Json;

namespace RentCarStore.Core.Messaging
{
    public class SnsPublisher : ISnsPublisher
    {
        private readonly IAmazonSimpleNotificationService _sns;

        public SnsPublisher(IAmazonSimpleNotificationService sns) => _sns = sns;

        public Task<PublishResponse> PublishAsync<TMessage>(string topicName, TMessage message, Dictionary<string, MessageAttributeValue> messageAttributes = null!, CancellationToken cancellationToken = default!) where TMessage : class
        {
            string messageBody = JsonSerializer.Serialize(message);

            string? topicArnBase = Environment.GetEnvironmentVariable("TOPIC_ARN_BASE");

            if (topicArnBase is null) throw new InvalidOperationException("The environment variable 'TOPIC_ARN_BASE' must be set.");

            string topicArn = StringPool.Shared.GetOrAdd(string.Concat(topicArnBase, topicName));

            PublishRequest request = new()
            {
                TopicArn = topicArn,
                Message = messageBody
            };

            request.MessageAttributes = SnsMessageTypeAttribute.CreateAttributes<TMessage>();

            if (messageAttributes is not null)
                foreach (var item in messageAttributes)
                    request.MessageAttributes.Add(item);


            return _sns.PublishAsync(request, cancellationToken);
        }
    }
}
