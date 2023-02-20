using Amazon.SQS.Model;

namespace RentCarStore.Core.Messaging.Interfaces
{
    public interface ISqsConsumer
    {
        Task<List<Message>> GetMessagesAsync(string queueName, CancellationToken cancellationToken = default!);
        Task DeleteMessageAsync(string queueName, string receiptHandle, CancellationToken cancellationToken = default!);
    }
}
