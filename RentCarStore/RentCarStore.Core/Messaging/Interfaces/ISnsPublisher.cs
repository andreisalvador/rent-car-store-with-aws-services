using Amazon.SimpleNotificationService.Model;

namespace RentCarStore.Core.Messaging.Interfaces
{

    public interface ISnsPublisher
    {       
        Task<PublishResponse> PublishAsync<TMessage>(string topicArn, TMessage message, Dictionary<string, MessageAttributeValue> messageAttributes = null!, CancellationToken cancellationToken = default!) where TMessage : class;
    }
}
