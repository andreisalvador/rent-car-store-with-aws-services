using Amazon.Runtime.Internal.Transform;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using RentCarStore.Core.Messaging.Helper;
using RentCarStore.Core.Messaging.Interfaces;
using System.Text.Json;

namespace RentCarStore.Core.Messaging
{
    public class SnsPublisher : ISnsPublisher
    {
        private readonly IAmazonSimpleNotificationService _sns;

        public SnsPublisher(IAmazonSimpleNotificationService sns) => _sns = sns;


        public Task<PublishResponse> PublishAsync<TMessage>(string topicArn, TMessage message, Dictionary<string, MessageAttributeValue> messageAttributes = null!) where TMessage : class
        {
            string messageBody = JsonSerializer.Serialize(message);

            PublishRequest request = new()
            {
                TopicArn = topicArn,
                Message = messageBody
            };

            request.MessageAttributes = SnsMessageTypeAttribute.CreateAttributes<TMessage>();

            if (messageAttributes is not null)
                foreach (var item in messageAttributes)
                    request.MessageAttributes.Add(item);

            return _sns.PublishAsync(topicArn, messageBody);
        }
    }
}
