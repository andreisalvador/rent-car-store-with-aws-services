using Amazon.SQS.Model;

namespace RentCarStore.Core.Messaging.Interfaces
{
    public interface ISqsConsumer
    {
        Task<List<Message>> GetMessagesAsync(string queueName);
        Task DeleteMessageAsync(string queueName, string receiptHandle);
    }
}
